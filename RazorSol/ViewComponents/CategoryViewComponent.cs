using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RazorSol.ViewComponents
{
    [ViewComponent(Name = "Category")]
    public class CategoryViewComponent: ViewComponent
    {
        private RazorContext _context;

        public CategoryViewComponent(RazorContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.categories = _context.Categories.Where(c => c.Status).ToList();
            return View("Index");
        }
    }
}
