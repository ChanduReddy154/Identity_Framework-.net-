using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
  public  class PersonalInfoViewModel 
    {
        public string UserId { get; set; }
        public Guid InfoId { get; set; }
        public string FullName { get; set; }
        public IFormFile ProfilePicturePath { get; set; }
        public string FilesPath { get; set; }
        public DateTime? InsertedOn { get; set; }

    }
}
