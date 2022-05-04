using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Authentication;
using Microsoft.EntityFrameworkCore;
using Database.Models;

namespace Database.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Items> Items { get; set; }
        public DbSet<categories> categories { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ShippingInfo> ShippingInfo { get; set; }
    }
}
