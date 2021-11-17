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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmpDept>().HasNoKey();
            modelBuilder.Entity<EmpNames>().HasNoKey();
        }
    }
}
