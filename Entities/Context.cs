using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Entities
{
    public class Context : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<Product> Products { get; set; }


        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Shop>()
                .HasOne(s => s.Address)
                .WithOne(a => a.Shop);

            builder.Entity<Shop>()
                .HasMany(s => s.Employees)
                .WithOne(e => e.Shop);

            builder.Entity<Client>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Client);

            builder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });

            builder.Entity<OrderProduct>()
                .HasOne<Order>(op => op.Order)
                .WithMany(o => o.OrderProduct)
                .HasForeignKey(op => op.OrderId);

            builder.Entity<OrderProduct>()
                .HasOne<Product>(op => op.Product)
                .WithMany(p => p.OrderProduct)
                .HasForeignKey(op => op.ProductId);
            

        }
    }
}
