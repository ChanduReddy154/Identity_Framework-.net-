using System;
using System.Collections.Generic;

#nullable disable

namespace Hrms.Repository.Models
{
    public partial class Pincode
    {
        public Pincode()
        {
            AddressInfos = new HashSet<AddressInfo>();
        }

        public int Id { get; set; }
        public string PinCode1 { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<AddressInfo> AddressInfos { get; set; }
    }
}
