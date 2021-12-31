using Hrms.Repository.Models;
using Hrms.Repository.RepositoryInterfaces;
using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.Implementations
{
   public class AccountsRepository : IAccountsRepository
    {
        private readonly HrmsIdentityContext _identityContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountsRepository(HrmsIdentityContext identityContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _identityContext = identityContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<AppUser> GetByEmail(string Email)
        {
            return await _userManager.FindByEmailAsync(Email);
        }

        public async Task<AppUser> GetByPhoneNumber(string PhoneNumber)
        {
            return await _userManager.Users.Where(x => x.PhoneNumber == PhoneNumber).SingleOrDefaultAsync();
            
        }

        public async Task<AppUser> GetByUserName(string UserName)
        {
            return await _userManager.FindByNameAsync(UserName);
        }

        public async Task<string> Register(AppUser user, string Password, string Role)
        {
            var result = await _userManager.CreateAsync(user, Password);
            if(result.Succeeded)
            {
                var roleExists = await _roleManager.RoleExistsAsync(Role);
                if(!roleExists)
                {
                    var roleCreate = await _roleManager.CreateAsync(new IdentityRole(Role));
                    if(!roleCreate.Succeeded)
                    {
                        return "User created but role creation failed.";
                    }
                }
                var newUser = await _userManager.FindByEmailAsync(user.Email);
                var roleAssign = await _userManager.AddToRoleAsync(newUser, Role);
                if(roleAssign.Succeeded) 
                {
                    return "User created successfully and assigned to role";
                }
                else
                {
                    return "User created successfully but not assigned to role";
                }
            }
            else
            {
                return "User creation failed";
            }
        }

        

        public async Task<string> SendOtp(AppUser user)
        {
            return await _userManager.GenerateUserTokenAsync(user, "Phone", "Login");
            
        }

        public async Task<Dictionary<int, string>> ValidatePassword(AppUser user, string Password)
        {
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            var result = await _signInManager.CheckPasswordSignInAsync(user, Password, true);
            if(result.Succeeded)
            {
                //return "Login Successful";
                keyValuePairs.Add(0, "Login Successful");
            }else
            {
                // return "Invalid Login";
                keyValuePairs.Add(1, "Invalid Login");
            }
            return keyValuePairs;
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyOTP(AppUser user, string OTP)
        {
            var result = await _userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultPhoneProvider, "Login", OTP);
            return result;
        }
    }
}
