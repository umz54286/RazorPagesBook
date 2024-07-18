using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using RazorPagesBook.Data;
using RazorPagesBook.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace RazorPagesBook.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesBook.Data.RazorPagesBookContext _context;

        public CreateModel(RazorPagesBook.Data.RazorPagesBookContext context)
        {
            _context = context;
        }

        //The 'OnGet' method initializes any state needed for the page.
        public IActionResult OnGet()
        {
            //The 'Page' method creates a 'PageResult' object that renders the 'Create.cshtml' page.
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // [Http] POST Request
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //The 'Book' property uses the [BindProperty] attribute to opt-in to model binding.
            _context.Book.Add(Book);
            //When the Create form posts the form values, the ASP.NET Core runtime binds the posted values to the 'Book' model.
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
