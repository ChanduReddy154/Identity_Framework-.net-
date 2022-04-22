using System;
using System.Collections.Generic;

#nullable disable

namespace Hrms.Repository.Models
{
    public partial class City
    {
        public City()
        {
            AddressInfos = new HashSet<AddressInfo>();
            Pincodes = new HashSet<Pincode>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<AddressInfo> AddressInfos { get; set; }
        public virtual ICollection<Pincode> Pincodes { get; set; }
    }
}
