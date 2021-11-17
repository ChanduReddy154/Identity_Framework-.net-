using Hrms.Repository.Models;

using System.Threading.Tasks;

namespace HRMS.API.Auth
{
    public interface IJwtTokenManager
    {
        Task<string> GenerateToken(AppUser user, string role);
    }
}
