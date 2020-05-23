using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorSol.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<RoleAccount> RoleAccount { get; set; }

        public Account()
        {
            RoleAccount = new HashSet<RoleAccount>();
        }
    }
    
}
