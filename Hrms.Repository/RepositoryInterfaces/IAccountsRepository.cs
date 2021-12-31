using Hrms.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.RepositoryInterfaces
{
    public interface IAccountsRepository
    {
        Task<string> Register(AppUser user, string Password, string Role);

   //     Task<AspNetUser> RegisterUser(AppUser user, string Password, string Role);

        Task<AppUser> GetByEmail(string Email);

        Task<AppUser> GetByUserName(string UserName);

        Task<AppUser> GetByPhoneNumber(string PhoneNumber);

        Task<Dictionary<int, string>> ValidatePassword(AppUser user, string Password);

        Task<string> SendOtp(AppUser user);

        Task<bool> VerifyOTP(AppUser user, string OTP);



    }
}
