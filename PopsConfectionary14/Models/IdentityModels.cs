﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PopsConfectionary14.Models;

namespace PopsConfectionary14.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Staff> Staff { get; set; }
	    public DbSet<Cart> Cart { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OrderDetail> OrderDetail{ get; set; }

        public DbSet<Category> Categories { get; set; }

        public System.Data.Entity.DbSet<PopsConfectionary14.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<PopsConfectionary14.Models.Payment> Payments { get; set; }

       
    }
}