using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AjaxApplication.Models;
using System.Reflection.Emit;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AjaxApplication.DB
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //flunt Api relationShips Between Department And Employee -- Aurthor ENG-Mohamed Mohsen
            modelBuilder.Entity<Employee>()
            .HasRequired<Department>(s => s.Department)
            .WithMany(g => g.Employees)
            .HasForeignKey(s => s.DepartmentID)
            .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }


    }
}