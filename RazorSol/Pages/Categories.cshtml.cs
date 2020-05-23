using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorSol.Models;

namespace RazorSol.Pages
{
    public class CategoriesModel : PageModel
    {
        private readonly RazorContext _context;
        [BindProperty(Name = "Id",SupportsGet = true)]
        public int Id { get; set; }

        public Category Category { get; set; }
        public List<Product> Products { get; set; }

        public CategoriesModel(RazorContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Category = _context.Categories.Find(Id);
            Products = _context.Products.Where(p => p.Status && p.CategoryId == Id).ToList();
        }
    }
}