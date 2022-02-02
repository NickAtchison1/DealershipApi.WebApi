﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace DealershipApi.Data.DataModels
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
       /*[ForeignKey(nameof(Dealership))]
       public int DealershipId { get; set; }
       public virtual Dealership Dealership { get; set; }*/
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
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

        public DbSet<Dealership> Dealerships { get; set; }
        public DbSet<SalesPerson> SalesPeople { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();
               // .Remove<OneToManyCascadeDeleteConvention>();

            
            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());

            //modelBuilder
            //    .Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Transaction>()
            //    .HasRequired(t => t.SalesPerson)
            //    .WithMany()
            //    .HasForeignKey(t => t.SalesPersonId)
            //    .WillCascadeOnDelete(false);

        }

        public Task aveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
        {
            public IdentityUserLoginConfiguration()
            {
                HasKey(iul => iul.UserId);
            }
        }

        public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
        {
            public IdentityUserRoleConfiguration()
            {
                HasKey(iur => iur.UserId);
            }
        }
    }
}