using Hrms.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Hrms.Business.BusinessInterfaces
{
    public interface IAccountsBusiness
    {

        Task<string> Register(UserViewModel model);

       // Task<UserViewModel> RegisterUser(UserViewModel model);

        Task<Dictionary<int, string>> Login(LoginViewModel model);

        Task<Dictionary<int, string>> SendOtp(string mobile);

        Task<string> VeriftOTP(VerifyViewModel model);

        Task<string> GetRolesByUser(AppUser user);

        Task<AppUser> GetUserDetails(string userDetail);

        Task<string> generateUserToken(AppUser user);
    }
}
