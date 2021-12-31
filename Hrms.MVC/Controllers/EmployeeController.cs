using Hrms.Business.BusinessInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Hrms.MVC.Controllers
{
    public class EmployeeController : Controller

       
    {

        private readonly IEmployeeBusiness _empBusiness;
        private readonly IDepartmentBusiness _departmentBusiness;

        public EmployeeController(IEmployeeBusiness empBusiness, IDepartmentBusiness departmentBusiness)
        {
            _empBusiness = empBusiness;
            _departmentBusiness = departmentBusiness;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _empBusiness.getAllEmployees();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IList<DepartmentViewModel> depts = await _departmentBusiness.getAllDepartments();
            var deptFromDB = new SelectList(depts, "DeptId", "DeptName");
            ViewData["deptBindData"] = deptFromDB;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
             var result = _empBusiness.postEmployee(model);
            TempData["status"] = "Record added successfully";
            return RedirectToAction("Index");
        }
    }
}
