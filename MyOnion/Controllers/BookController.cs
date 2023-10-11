using Microsoft.AspNetCore.Mvc;
using MyOnion.Models;
using MyOnion.Service;

namespace MyOnion.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await bookService.FindAll();
            var books = result.Select(b => new BookViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Price = b.Price,
            }).ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateModel book)
        {
            BookDto b = new BookDto
            {
                Title = book.Title,
                Price = book.Price
            };
            await bookService.Create(b);
            return RedirectToAction("Index");
        }
    }
}
