using Hrms.Business.BusinessInterfaces;
using HRMS.Communication.Email;
using HRMS.Utilities;
using HrmsWeb_API.EmailSend;
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
    
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeBusiness _empBusiness;
        // private readonly IEmailSender _emailSender;
        private readonly IMailService _mailService;

        public EmployeeController(IEmployeeBusiness empBusiness, IMailService mailService)
        {
            _empBusiness = empBusiness;
            _mailService = mailService;
        }

        [HttpGet]
        public async Task <IActionResult> getAllEmployees()
        {
            var employees = await _empBusiness.getAllEmployees();
            return Ok(employees);
        }

        [HttpPost]

        public async Task <IActionResult> postEmployees(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _empBusiness.postEmployee(model);
            return Ok(result);
        }

        [HttpGet("GetElementByid")]
        public async Task <IActionResult> GetElementById(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _empBusiness.getElementById(id);
            return Ok(result);
        }

        [HttpGet("GetEmpDetails")]
        public async Task<IActionResult> getEmpDetails(int? DeptId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _empBusiness.getEmpDetails(DeptId);
            return Ok(result);
        }

        [HttpGet("GetEmpName")]

        public async Task<IActionResult> getEmpNames()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _empBusiness.getEmpNames();
            return Ok(result);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> updateEmployee(EmployeeViewModel emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _empBusiness.updateEmployee(emp);
            return Ok(result);
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail([FromForm]MailRequest mail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _mailService.SendEmailAsync(mail);
                return Ok();
            }
            catch (Exception)
            {
                
                throw;
            } 
        }
    }
}
