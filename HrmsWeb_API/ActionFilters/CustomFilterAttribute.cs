using HRMS.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ViewModels;

namespace HrmsWeb_API.ActionFilters
{
    public class CustomFilterAttribute : ActionFilterAttribute
    {
        public static string UserId { get; set; }

        public static string Email { get; set; }

        public static string Role { get; set; }
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var authorization = context.HttpContext.Request.Headers[HeaderNames.Authorization];
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                var scheme = headerValue.Scheme;
                var parameter = headerValue.Parameter;
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(parameter);
                var tokenS = jsonToken as JwtSecurityToken;
                //var companyId = tokenS.Claims.First(claim => claim.Type == "companyId").Value;
                //if (!string.IsNullOrEmpty(companyId))
                //    CompanyId = Convert.ToInt64(companyId);
                UserId = tokenS.Claims.First(claim => claim.Type == "id").Value;
                Email = tokenS.Claims.First(claim => claim.Type == "Email").Value;
                Role = tokenS.Claims.First(claim => claim.Type == "role").Value;
                //  Status = tokenS.Claims.First(claim => claim.Type == "status").Value;
            }

            if (!context.ModelState.IsValid)
            {
                var res = new BadRequestObjectResult(new ApiBadRequestResponse(context.ModelState));
                context.Result = res;
            }
            return base.OnActionExecutionAsync(context, next);
        }

    }
}
