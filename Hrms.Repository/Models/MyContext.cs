using Hrms.Repository.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.Models
{
    public partial class MyContext : HrmsDBContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<HrmsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmpDept> EmployeeDetails { get; set; }

        public virtual DbSet<EmpNames> EmployeeNames { get; set; }

        public virtual DbSet<UserAddress> AddressUsers { get; set; }

        public virtual DbSet<OrderDetails> OrderDetails { get; set; }


        public virtual DbSet<CurrentUser> CurrentUserName { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmpDept>().HasNoKey();
            modelBuilder.Entity<EmpNames>().HasNoKey();
            modelBuilder.Entity<UserAddress>().HasNoKey();
            modelBuilder.Entity<CurrentUser>().HasNoKey();
            modelBuilder.Entity<OrderDetails>().HasNoKey();
        }
    }
}
