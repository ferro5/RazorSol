using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace RazorSol.Models
{
    public class InvoiceDetails
    {
        [Key]
        public int InvoiceId { get; set; }
        public int  ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<Product>Products { get; set; }
        public virtual Invoice Invoice { get; set; }

        public InvoiceDetails()
        {
            Products = new HashSet<Product>();
        }
    }
}
