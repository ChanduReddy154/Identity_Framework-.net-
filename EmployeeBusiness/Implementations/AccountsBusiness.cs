using Hrms.Business.BusinessInterfaces;
using Hrms.Repository.Models;
using Hrms.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Hrms.Business.Implementations
{
  public  class AccountsBusiness : IAccountsBusiness
    {
        private readonly IAccountsRepository _accountsRepository;

        public AccountsBusiness(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<AppUser> GetUserDetails(string userDetail)
        {
            AppUser user = null;
            user = await _accountsRepository.GetByUserName(userDetail);
            if (user == null)
            {
                user = await _accountsRepository.GetByEmail(userDetail);
            }
            if (user == null)
            {
                user = await _accountsRepository.GetByPhoneNumber(userDetail);
            }
            return user;
            throw new NotImplementedException();
        }

        public async Task<Dictionary<int, string>> Login(LoginViewModel model)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            AppUser user = null;
            user = await _accountsRepository.GetByUserName(model.UserName);
            if(user == null)
            {
                user = await _accountsRepository.GetByEmail(model.UserName);
            }
            if(user == null)
            {
                user = await _accountsRepository.GetByPhoneNumber(model.UserName);
            } if(user == null)
            {
                dict.Add(1, "Invalid User");
                // return "Invalid User";
            }
            else
            {
              var res =  await _accountsRepository.ValidatePassword(user, model.Password);
                if (res.Keys.FirstOrDefault() == 0)
                    dict.Add(2, dict.Values.FirstOrDefault());
                else
                    dict.Add(3, dict.Values.FirstOrDefault());
            }
            return dict;
            
        }

        public async Task<string> Register(UserViewModel model)
        {
            AppUser user = new AppUser()
            { 
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            
            };

            var result = await _accountsRepository.Register(user, model.Password, "admin");
            return result;
        }

        public async Task<Dictionary<int, string>> SendOtp( string mobile)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            var user = await _accountsRepository.GetByPhoneNumber(mobile);
            if(user == null)
            {
                result.Add(1, "Invalid Login");
            } else
            {
                var otp = await _accountsRepository.SendOtp(user);
                result.Add(2, otp.ToString());
            }
            return result;
        }

        public async Task<string> VeriftOTP(VerifyViewModel model)
        {
            var user = await _accountsRepository.GetByPhoneNumber(model.PhoneNumber);
            var result = await _accountsRepository.VerifyOTP(user, model.OTP);
            if(result)
            {
                return "Otp Successfully Validated";
            } else
            {
                return "Otp validation failed";
            }
        }
    }
}
