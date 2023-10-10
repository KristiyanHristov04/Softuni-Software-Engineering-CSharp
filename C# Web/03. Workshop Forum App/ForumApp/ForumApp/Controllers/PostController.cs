using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models.Post;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext _data;

        public PostController(ForumAppDbContext data)
        {
            this._data = data;
        }
        public IActionResult All()
        {
            List<PostViewModel> posts = this._data.Posts
                .Select(p => new PostViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
            })
            .ToList();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PostFormModel postFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(postFormModel);
            }

            Post post = new Post()
            {
                Title = postFormModel.Title,
                Content = postFormModel.Content
            };

            this._data.Posts.Add(post);
            this._data.SaveChanges();
            return RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            Post post = this._data.Posts.Find(id)!;
            PostFormModel postFormModel = new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content
            };


            return View(postFormModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, PostFormModel postFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(postFormModel);
            }

            Post postToEdit = this._data.Posts.Find(id)!;
            postToEdit.Title = postFormModel.Title;
            postToEdit.Content = postFormModel.Content;
            this._data.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Post post = this._data.Posts.Find(id)!;
            this._data.Remove(post);
            this._data.SaveChanges();
            return RedirectToAction("All");
        }
    }
}
