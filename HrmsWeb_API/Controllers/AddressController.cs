using Hrms.Business.BusinessInterfaces;
using HrmsWeb_API.ActionFilters;
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
     [CustomFilterAttribute]
    public class AddressController : ControllerBase
    {

        private readonly IAddressInterface _addressInterface;

        public AddressController(IAddressInterface addressInterface)
        {
            _addressInterface = addressInterface;
        }

        [HttpPost("PostAddress")]

        public async Task<IActionResult> postAddress(AddressViewModel add1)
        {
            var usedId = CustomFilterAttribute.UserId;
           // var role = CustomFilterAttribute.Role;
            add1.UserId = usedId;
           
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _addressInterface.PostAddress(add1);
            return Ok(result);
        }

        [HttpGet("UserAddresses")]
        public async Task<IActionResult> getallUsersAddress()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _addressInterface.getUsersAddresses();
            return Ok(result);
        }

        [HttpGet("GetAddressByUserId")]
        public async Task<IActionResult> getAddressByUserId(string id)
        {
            var userId = CustomFilterAttribute.UserId;
            id = userId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _addressInterface.getAddressByUserId(id);
            return Ok(result);
        }

        [HttpGet("ProfileById")]
        public async Task<IActionResult> getProfileById(string id)
        {
            var userId = CustomFilterAttribute.UserId;
            id = userId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _addressInterface.getProfileById(id);
            return Ok(result);
        }


        [HttpGet("Countries")]
        public async Task<IActionResult> getAllCountries()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _addressInterface.getAllCountries();
            return Ok(result);
        }

        [HttpGet("States")]
        public async Task<IActionResult> getAllStates()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _addressInterface.getAllStates();
            return Ok(result);
        }

        [HttpGet("Cities")]
        public async Task<IActionResult> getAllCities()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _addressInterface.getAllCities();
            return Ok(result);
        }

        [HttpGet("Pincodes")]
        public async Task<IActionResult> getAllPincodes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _addressInterface.getAllPinCodes();
            return Ok(result);
        }

        [HttpGet("getStatesByCountryId")]
        public async Task<IActionResult> getStatesByCountryId(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _addressInterface.getStatesByCountryId(id);
            return Ok(result);
        }

        [HttpGet("getCurrentUserName")]
        public async Task<IActionResult> getCurrentUserName(string id)
        {
            var userId = CustomFilterAttribute.UserId;
            id = userId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _addressInterface.getCurrentUserName(id);
            return Ok(result);
        }



    }
}
