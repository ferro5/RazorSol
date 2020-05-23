using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorSol.Models;

namespace RazorSol.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly RazorContext _context;
        [BindProperty(Name = "id",SupportsGet = true)]
        public int Id { get; set; }

        public Product Product { get; set; }
        public string PhotoName { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public DetailsModel(RazorContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
            Product = _context.Products.Find(Id);
            Photo photo = Product.Photos.SingleOrDefault(ph => ph.Status && ph.Featured);
            PhotoName = photo == null ? "no-image.png" : photo.Name;
            RelatedProducts = _context.Products.Where(p => p.Status && p.CategoryId == Product.CategoryId && p.Id != Id)
                .ToList();
        }
    }
}