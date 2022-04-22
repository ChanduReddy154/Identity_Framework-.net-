using Hrms.Business.BusinessInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test_MVC.Models;

namespace Test_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeBusiness _empBusiness;

        public HomeController(ILogger<HomeController> logger, IEmployeeBusiness empBusiness)
        {
            _logger = logger;
            _empBusiness = empBusiness;
        }
       

        public IActionResult Index()
        {
            var employees = _empBusiness.getAllEmployees();
            //return Ok(employees);
            return View(employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
