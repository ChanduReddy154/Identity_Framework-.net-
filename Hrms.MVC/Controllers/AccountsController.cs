using Hrms.Business.BusinessInterfaces;
using Hrms.Repository.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Hrms.MVC.Controllers
{
    public class AccountsController : Controller
    {

        private readonly IAccountsBusiness _accountsBusiness;
        

        public AccountsController(IAccountsBusiness accountsBusiness)
        {
            _accountsBusiness = accountsBusiness;
        }

        
        public async  Task<IActionResult> Register(UserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(model);
            }
            var result = await _accountsBusiness.Register(model);
            return View();
        }
    }
}
