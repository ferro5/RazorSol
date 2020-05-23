using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorSol.Models;

namespace RazorSol.Pages
{
    public class ProfileModel : PageModel
    {
        private RazorContext _context;
        [BindProperty]
        public Account Account { get; set; }

        public ProfileModel(RazorContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            string username = HttpContext.Session.GetString("username");
            Account = _context.Accounts.FirstOrDefault(a => a.UserName.Equals(username));
        }
    }
}