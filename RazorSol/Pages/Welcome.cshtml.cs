using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSol.Pages
{
    public class WelcomeModel : PageModel
    {
        public string UserName { get;  set; }

        public IActionResult OnGet()
        {
            string usernameSession = HttpContext.Session.GetString("username");
            if (usernameSession == null)
            {

                return RedirectToPage("login");
            }
            else
            {
                UserName = usernameSession;
                return Page();
            }
        }
    }
}