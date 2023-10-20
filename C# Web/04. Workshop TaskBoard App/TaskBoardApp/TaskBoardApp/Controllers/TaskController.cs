using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext _data;
        public TaskController(TaskBoardAppDbContext context)
        {
            this._data = context;
        }

        public IActionResult Create()
        {
            TaskFormModel taskFormModel = new TaskFormModel()
            {
                Boards = GetBoards()
            };

            return View(taskFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskFormModel) 
        { 
            if (!GetBoards().Any(b => b.Id == taskFormModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskFormModel.BoardId), "Board does not exist.");
            }

            string currentUserId = GetUserId();

            if (!ModelState.IsValid)
            {
                taskFormModel.Boards = GetBoards();

                return View(taskFormModel);
            }

            Task task = new Task()
            {
                Title = taskFormModel.Title,
                Description = taskFormModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskFormModel.BoardId,
                OwnerId = currentUserId
            };

            await this._data.Tasks.AddAsync(task);
            await this._data.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Details(int id)
        {
            TaskDetailsViewModel? task = await this._data.Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board!.Name,
                    Owner = t.User.UserName
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }
            
            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Task task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskFormModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(taskFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskFormModel)
        {
            Task task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == taskFormModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskFormModel.BoardId), "Board does not exist.");
            }

            ModelState.Remove("Boards");
            if (!ModelState.IsValid)
            {
                taskFormModel.Boards = GetBoards();

                return View(taskFormModel);
            }

            task.Title = taskFormModel.Title;
            task.Description = taskFormModel.Description;
            task.BoardId = taskFormModel.BoardId;

            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Task task = await _data.Tasks.FindAsync(id);    
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskViewModel taskViewModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };

            return View(taskViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskViewModel)
        {
            Task task = await _data.Tasks.FindAsync(taskViewModel.Id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            _data.Tasks.Remove(task);
            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }

        private string GetUserId()
        {
            return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private List<TaskBoardModel> GetBoards()
        {
            return this._data.Boards.Select(b => new TaskBoardModel()
            {
                Id = b.Id,
                Name = b.Name
            })
            .ToList();
        }
    }
}
