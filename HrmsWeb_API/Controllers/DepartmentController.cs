using Hrms.Business.BusinessInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace HrmsWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentBusiness _deptBusiness;

        public DepartmentController(IDepartmentBusiness deptBusiness)
        {
            _deptBusiness = deptBusiness;
        }
        [HttpGet]
        public async Task< IActionResult> getAllDepartments()
        {
            var depts = await _deptBusiness.getAllDepartments();
            return Ok(depts);
        }

        [HttpPost]
        public async Task <IActionResult> postDepartments(DepartmentViewModel depts)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _deptBusiness.PostDepartment(depts);
            return Ok(result);
        }

    }
}
