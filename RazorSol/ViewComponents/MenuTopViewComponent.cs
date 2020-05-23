using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RazorSol.ViewComponents
{
    [ViewComponent(Name = "MenuTop")]
    public class MenuTopViewComponent:ViewComponent
    {
        public string UserSession { get; set; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           ViewBag.UserSession = HttpContext.Session.GetString("username");
            return View("Index");
        }
    }
}
