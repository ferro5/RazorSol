using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorSol.Models;

namespace RazorSol
{
    public class RazorContext :DbContext
    {
        public RazorContext(DbContextOptions<RazorContext> context):base(context)
        {
            
        }
        public virtual DbSet<SlideShow> SlideShows { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
       public virtual DbSet<Category> Categories { get; set; }
       public virtual DbSet<Product> Products { get; set; }
       public virtual DbSet<RoleAccount> RoleAccounts { get; set; }
       public virtual DbSet<Invoice> Invoices { get; set; }
       public virtual DbSet<InvoiceDetails> InvoiceDetailses { get; set; }
       public virtual DbSet<Photo> Photos { get; set; }
       public virtual DbSet<Role> Roles { get; set; }
    }
}
