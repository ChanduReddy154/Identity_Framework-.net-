using System;
using System.Collections.Generic;

#nullable disable

namespace Hrms.Repository.Models
{
    public partial class Country
    {
        public Country()
        {
            AddressInfos = new HashSet<AddressInfo>();
            States = new HashSet<State>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string TwoCharCountryCode { get; set; }
        public string ThreeCharCountryCode { get; set; }

        public virtual ICollection<AddressInfo> AddressInfos { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
