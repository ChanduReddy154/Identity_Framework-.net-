using System;
using System.Collections.Generic;

#nullable disable

namespace Hrms.Repository.Models
{
    public partial class PersonalInformation
    {
        public string UserId { get; set; }
        public Guid InfoId { get; set; }
        public string FullName { get; set; }
        public string ProfilePicturePath { get; set; }
        public string FilesPath { get; set; }
        public DateTime? InsertedOn { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
