using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Auth
{
    public class StatusRequirement : IAuthorizationRequirement
    {
        protected string status { get; set; }
        public StatusRequirement(string status)
        {
            this.status = status;
        }
    }
}
