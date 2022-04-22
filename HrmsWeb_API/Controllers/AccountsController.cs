using Hrms.Business.BusinessInterfaces;
using Hrms.Repository.Models;
using HRMS.API.Auth;
using HRMS.Communication.Email;
using HRMS.Utilities;
using HrmsWeb_API.ActionFilters;
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
    [CustomFilterAttribute]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsBusiness _accountsBusiness;
        private readonly IJwtTokenManager _jwtTokenManager;
       // private readonly IEmailSender _emailSender;

        public AccountsController(IAccountsBusiness accountsBusiness, IJwtTokenManager jwtTokenManager) //, IEmailSender emailSender
        {
            _accountsBusiness = accountsBusiness;
            _jwtTokenManager = jwtTokenManager;
           // _emailSender = emailSender;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400, "Validation Errors", ModelState));
            }
          //  var result = await _accountsBusiness.
            var result = await _accountsBusiness.Register(model);
            return Ok(new ApiResponse(200, result));

        }

        
        [HttpPost("Login")]
            public async Task<IActionResult> LoginUser(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400, "Validation Errors", ModelState));
            }

            var result = await _accountsBusiness.Login(model);
            if(result.Keys.FirstOrDefault() == 1)
            {
                return Ok(new ApiResponse(200, result.Values.FirstOrDefault()));
            } 
            else if(result.Keys.FirstOrDefault() == 2)
            {
                AppUser user = await _accountsBusiness.GetUserDetails(model.UserName);
                string role = await _accountsBusiness.GetRolesByUser(user);
                var token = await _jwtTokenManager.GenerateToken(user, role);
                return Ok(new ApiResponse(200,"Login Success", token) );
            }
            else 
            return Ok(new ApiResponse(200, result.Values.FirstOrDefault()));
        }

        [HttpGet("Send Otp")]

        public async Task<IActionResult> sendOtp(string mobile)
        {
            if(string.IsNullOrEmpty(mobile))
            {
                return BadRequest(new ApiResponse(400, "Mobile Number is Mandatory"));
            }
            var result = await _accountsBusiness.SendOtp(mobile);
            if(result.Keys.FirstOrDefault() == 2)
            {
                return Ok(new ApiResponse(200,"OTP Sent Successfully", result.Values.FirstOrDefault()));
            }else
            {
                return Ok(new ApiResponse(200, result.Values.FirstOrDefault())); 
            }
           
        }

        [HttpPost("Verify OTP")]
        public async Task<IActionResult> VerifyOtp(VerifyViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400, "Validation Errors", ModelState));
            }

            var result = await _accountsBusiness.VeriftOTP(model);
            return Ok(new ApiResponse(200, result));

        }

        //[HttpPost("ForgotPassword")]
        //public async Task<IActionResult> forgotPassword([FromBody] ForgotPasswordViewModel forgotPassword)
        //{
        //    var user = await _accountsBusiness.GetUserDetails(forgotPassword.Email);
        //    if (user == null)
        //    {
        //        return NotFound(new ApiResponse(204, "The Email is not registered", null));
        //    }
        //    var token = await _accountsBusiness.generateUserToken(user);
        //    var emailMsg = await _emailSender.SendEmailAsync(token);
        //}

    }
}
