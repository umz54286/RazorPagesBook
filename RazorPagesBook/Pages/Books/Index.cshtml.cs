﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesBook.Data;
using RazorPagesBook.Models;

namespace RazorPagesBook.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesBook.Data.RazorPagesBookContext _context;

        public IndexModel(RazorPagesBook.Data.RazorPagesBookContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        // search Book
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Types { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BookType { get; set; }

        // [Http] GET Request 
        public async Task OnGetAsync()
        {
            //Book = await _context.Book.ToListAsync();

            // using System.Linq;
            //var movies = from m in _context.Book
            //             select m;
            //if (!string.IsNullOrEmpty(SearchString))
            //{
            //    movies = movies.Where(s => s.ProductName.Contains(SearchString));
            //}

            //Book = await movies.ToListAsync();

            // Use LINQ to get list of genres.
            IQueryable<string> ProductNameQuery = from m in _context.Book
                                            orderby m.Type
                                            select m.Type;

            var books = from m in _context.Book
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Type.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BookType))
            {
                books = books.Where(x => x.Type == BookType);
            }
            Types = new SelectList(await ProductNameQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();

        }
    }
}
