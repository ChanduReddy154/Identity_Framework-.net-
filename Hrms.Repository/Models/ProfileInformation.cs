using System;
using System.Collections.Generic;

#nullable disable

namespace Hrms.Repository.Models
{
    public partial class ProfileInformation
    {
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
