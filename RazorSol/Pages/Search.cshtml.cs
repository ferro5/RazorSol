using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorSol.Models;

namespace RazorSol.Pages
{
    public class SearchModel : PageModel
    {
        private readonly RazorContext _context;
        [BindProperty(Name = "CategoryId",SupportsGet = true)]
        public int CategoryId { get; set; }
        [BindProperty(Name = "Keyword", SupportsGet = true)]
        public string Keyword { get; set; }
        public List<Product> Products { get; set; }
        public SearchModel(RazorContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            if (CategoryId==-1)
            {
                Products = _context.Products.Where(p => p.Status && p.Name.Contains(Keyword)).ToList();
            }
            else
            {
                Products = _context.Products.Where(p =>p.CategoryId==CategoryId
                                                       &&  p.Status && p.Name.Contains(Keyword)).ToList();
            }
        }
    }
}