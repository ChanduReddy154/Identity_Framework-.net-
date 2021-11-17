using Hrms.Business.BusinessInterfaces;
using Hrms.Repository.Models;
using HRMS.API.Auth;
using HRMS.Utilities;
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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsBusiness _accountsBusiness;
        private readonly IJwtTokenManager _jwtTokenManager;

        public AccountsController(IAccountsBusiness accountsBusiness, IJwtTokenManager jwtTokenManager)
        {
            _accountsBusiness = accountsBusiness;
            _jwtTokenManager = jwtTokenManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400, "Validation Errors", ModelState));
            }
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
                var token = await _jwtTokenManager.GenerateToken(user, "admin");
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

    }
}
