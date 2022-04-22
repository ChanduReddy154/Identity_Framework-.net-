using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HRMS.API.Auth
{
    public class StatusHandler : AuthorizationHandler<StatusRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, StatusRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "Status")) 
            {
                return Task.FromResult(0);
            }
            var st= context.User.FindFirst(claim => claim.Type == "Status").Value;
            if (st == "Active")
            {
                context.Succeed(requirement);
            }
            return Task.FromResult(0);
        }
    }
}

