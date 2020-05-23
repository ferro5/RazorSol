using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorSol.Models;

namespace RazorSol.Pages
{
    public class RegisterModel : PageModel
    {
        private RazorContext _context;

        [BindProperty]
        public Account account { get; set; }

        public RegisterModel(RazorContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            account = new Account();
        }
      

        public IActionResult OnPost()
        {
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            account.Status = true;
            _context.Accounts.Add(account);
            _context.SaveChanges();
            RoleAccount roleAccount = new RoleAccount
            {
                AccountId = account.Id,
                RoleId = 2,
                Status = true
            };
            _context.RoleAccounts.Add(roleAccount);
            _context.SaveChanges();
            return RedirectToPage("login");
        }
    }
}