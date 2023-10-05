using Library.Data;
using Library.Data.Models;
using Library.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly LibraryDbContext data;
        public BookController(LibraryDbContext context)
        {
            this.data = context;
        }

        public async Task<IActionResult> All()
        {
            List<AllBookViewModel> books = await this.data.Books.Select(b => new AllBookViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                ImageUrl = b.ImageUrl,
                Rating = b.Rating,
                Category = b.Category.Name
            })
            .ToListAsync();

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            BookFormModel bookFormModel = new BookFormModel();
            bookFormModel.Categories = await GetCategories();

            return View(bookFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel bookFormModel)
        {
            if (!ModelState.IsValid)
            {
                bookFormModel.Categories = await GetCategories();
                return View(bookFormModel);
            }

            Book book = new Book()
            {
                Title = bookFormModel.Title,
                Author = bookFormModel.Author,
                Description = bookFormModel.Description,
                ImageUrl = bookFormModel.Url,
                Rating = bookFormModel.Rating,
                CategoryId = bookFormModel.CategoryId
            };

            await this.data.AddAsync(book);
            await this.data.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Mine()
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<int> booksIds = this.data.UsersBooks
                .Where(ub => ub.CollectorId == currentUserId).Select(ub => ub.BookId).ToList();
            List<MineBookViewModel> books = new List<MineBookViewModel>();

            foreach (var bookId in booksIds)
            {
                Book book = await this.data.Books.FirstAsync(b => b.Id == bookId);
                MineBookViewModel mineBookViewModel = new MineBookViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl,
                    Category = this.data.Categories.Find(book.CategoryId)!.Name
                };

                books.Add(mineBookViewModel);
            }

            AllMineBooksViewModel allMineBooks = new AllMineBooksViewModel();
            allMineBooks.Books = books;
            return View(allMineBooks);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Book? book = await this.data.Books.FindAsync(id);
            IdentityUserBook? bookUser = await this.data.UsersBooks.FirstOrDefaultAsync(x => x.CollectorId == currentUserId && x.BookId == book.Id);

            if (bookUser == null)
            {
                IdentityUserBook newBookUser = new IdentityUserBook()
                {
                    CollectorId = currentUserId,
                    BookId = book!.Id
                };

                await this.data.UsersBooks.AddAsync(newBookUser);
                await this.data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Book? book = await this.data.Books.FindAsync(id);
            IdentityUserBook? bookUser = await this.data.UsersBooks.FirstOrDefaultAsync(x => x.CollectorId == currentUserId && x.BookId == book.Id);

            if (bookUser != null)
            {
                this.data.UsersBooks.Remove(bookUser);
                this.data.SaveChanges();
            }

            return RedirectToAction(nameof(Mine));
        }

        private async Task<List<BookCategoryViewModel>> GetCategories()
        {
            return await this.data.Categories.Select(c => new BookCategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            })
            .ToListAsync();
        }
    }
}
