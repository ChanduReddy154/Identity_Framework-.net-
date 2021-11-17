using Hrms.Business.BusinessInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hrms.MVC.Controllers
{
    public class EmployeeController : Controller

       
    {

        private readonly IEmployeeBusiness _empBusiness;

        public EmployeeController(IEmployeeBusiness empBusiness)
        {
            _empBusiness = empBusiness;
        }
        public IActionResult Index()
        {
            var result = _empBusiness.getAllEmployees();
            return View(result);
        }
    }
}
