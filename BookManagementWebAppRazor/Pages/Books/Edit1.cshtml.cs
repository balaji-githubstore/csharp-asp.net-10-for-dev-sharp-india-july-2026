using BookManagementWebAppRazor.Model;
using BookManagementWebAppRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementWebAppRazor.Pages.Books
{
    public class Edit1Model : PageModel
    {
        [BindProperty]
        public Book BookDetail { get; set; }


        public Edit1Model()
        {
            // _context = context;
            // demo1.id += 1;
            // _demo11 = demo1;

        }

        public void OnGet(int id)
        {
            BookDetail = BookRepository.GetById(id);
        }

        //update
        public IActionResult OnPostUpdateBook()
        {
            if (!ModelState.IsValid)
                return Page();
            BookRepository.Update(BookDetail.Id, BookDetail);
            return RedirectToPage("Index1");
        }
    }
}
