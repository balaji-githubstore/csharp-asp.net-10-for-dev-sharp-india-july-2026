using BookManagementWebApplication.Model;
using BookManagementWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace BookManagementWebApplication.Controllers
{
    public class BooksController : Controller
    {
        // GET: BooksController
        public IActionResult Index()
        {
            //List<Book>
            var books = BookRepository.GetAll();
            return View(books);
        }

        public IActionResult Edit(int id)
        {
            var book = BookRepository.GetById(id);
            return View(book);
        }

        //Httppost method Edit() --> update the current book price and then redirect to home 
        [HttpPost]
        public IActionResult Edit(Book updatedBook)
        {
            //validate 
            if (!ModelState.IsValid)
            {
                return View(updatedBook);
            }
            //update the price,title, is available
            BookRepository.Update(updatedBook.Id, updatedBook);
            return RedirectToAction(nameof(Index));
        }
    }
}
