using BookManagementWebAppRazor.Model;
using BookManagementWebAppRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementWebAppRazor.Pages.Books
{
    public class Index1Model : PageModel
    {
        public List<Book> Books { get; set; }


        private Demo1 _demo11;
        public Index1Model(Demo1 demo1)
        {
            demo1.id += 1;
            _demo11 = demo1;

        }

        public void OnGet()
        {
            ViewData["Title"] = "BookIndexPage";
            Books = BookRepository.GetAll();

            ViewData["Title"] = "BookIndexPage";

            var loaded = HttpContext.Session.GetString("Loaded");

            if (loaded == null)
            {
                HttpContext.Session.SetString("Loaded", "Yes");
                ViewData["Message"] = "First Visit";
            }
            else
            {
                ViewData["Message"] = "Page Reloaded";
            }
        }

        public IActionResult OnPost(Book book)
        {
            BookRepository.Add(book);
            return RedirectToPage("Index1");
        }

        public IActionResult OnPostAddNewBook(Book book)
        {
            BookRepository.Add(book);
            TempData["Message"] = "New Book Added Successfully";
            return RedirectToPage("Index1");
        }
    }
}
