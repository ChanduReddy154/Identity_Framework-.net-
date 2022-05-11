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
    public class OrdersController : ControllerBase
    {

        private readonly IOrderInterface _orderInterface;
        public OrdersController(IOrderInterface orderInterface)
        {
            _orderInterface = orderInterface;
        }

        [HttpGet("GetAllItems")]
        public async Task<IActionResult> getAllItems()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _orderInterface.getAllItems();
            return Ok(result);
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> getAllOrders()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _orderInterface.getAllOrders();
            return Ok(result);
        }

        [HttpPost("AddItems")]
        public async Task<IActionResult> addItems(ItemsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _orderInterface.postItems(model);
            return Ok(result);
        }

        [HttpPost("AddOrders")]
        public async Task<IActionResult> addOrders(OrdersViewModel model)
        {
            var userId = CustomFilterAttribute.UserId;
            model.UserId = userId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _orderInterface.postOrders(model);
            return Ok(result);
        }

        [HttpGet("GetOrdersOfCurrentUser")]
        public async Task<IActionResult> getOrdersOfUser(string id)
        {
            var userId = CustomFilterAttribute.UserId;
            id = userId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _orderInterface.getOrdersOfuser(id);
            return Ok(result);
        }

    }
}
