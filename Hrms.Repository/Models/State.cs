using System;
using System.Collections.Generic;

#nullable disable

namespace Hrms.Repository.Models
{
    public partial class State
    {
        public State()
        {
            AddressInfos = new HashSet<AddressInfo>();
            Cities = new HashSet<City>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<AddressInfo> AddressInfos { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
