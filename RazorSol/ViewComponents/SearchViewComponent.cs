using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RazorSol.ViewComponents
{
    [ViewComponent(Name = "Search")]
    public class SearchViewComponent: ViewComponent
    {
        private readonly RazorContext _context;

        public SearchViewComponent(RazorContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.categories = _context.Categories.Where(p => p.Status && p.ParentId != null).ToList();
            return View("Index");
        }
    }
}
