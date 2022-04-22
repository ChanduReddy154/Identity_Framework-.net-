using System;
using System.Collections.Generic;

#nullable disable

namespace Hrms.Repository.Models
{
    public partial class AddressInfo
    {
        public string UserId { get; set; }
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int PinCodeId { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Pincode PinCode { get; set; }
        public virtual State State { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
