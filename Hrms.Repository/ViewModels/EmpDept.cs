﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.ViewModels
{
   public class EmpDept
    {
        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }
       // public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptLocation { get; set; }
    }
}
