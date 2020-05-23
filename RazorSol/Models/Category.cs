using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorSol.Models
{
    public class Category
    {
        public Category()
        {
            InverseParent = new List<Category>();
            Product = new HashSet<Product>();
          
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int ParentId { get; set; }

        public  virtual Category Parent { get; set; }
        public  virtual ICollection<Category> InverseParent { get; set; }
        public virtual ICollection<Product> Product { get; set; }

        
    }
}
