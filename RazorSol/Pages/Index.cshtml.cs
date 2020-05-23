using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorSol.Models;

namespace RazorSol.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RazorContext _context;
        public List<Product> FeaturedProducts { get; set; }
        public List<Product> LatestProducts { get; set; }
        public bool IsHome { get; set; }
        public IndexModel(ILogger<IndexModel> logger, RazorContext context)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            IsHome = true;
            FeaturedProducts = _context.Products.OrderByDescending(p=>p.Id)
                .Where(p => p.Featured && p.Status).Take(6).ToList();
            LatestProducts = _context.Products.OrderByDescending(p => p.Id)
                .Where(p =>  p.Status).Take(6).ToList();
        }
    }
}
