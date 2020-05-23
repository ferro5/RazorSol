using System.ComponentModel.DataAnnotations;

namespace RazorSol.Models
{
    public class RoleAccount
    {
        [Key]
        public int RoleId { get; set; }
        public int AccountId { get; set; }
        public bool Status { get; set; }
    }
}