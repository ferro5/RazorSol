using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorSol.Models;

namespace RazorSol.Pages
{
    public class LoginModel : PageModel
    {
        
        private readonly RazorContext _context;
        public string Message { get; set; }
        public LoginModel(RazorContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return Page();
        }
        public IActionResult OnPost(string username,string password)
        {
            if (Check(username,password)!=null)
            {
                HttpContext.Session.SetString("username",username);
                return RedirectToPage("Welcome");
            }
            else
            {
                Message = "Invalid";
                return Page();
            }
        }

        private Account Check(string username, string password)
        {
            Account account = _context.Accounts.FirstOrDefault(p => p.UserName.Equals(username));

            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }

            return null;

        }

    }
}