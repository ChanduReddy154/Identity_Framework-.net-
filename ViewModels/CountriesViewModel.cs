using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
   public class CountriesViewModel
    {
        //public CountriesViewModel()
        //{
        //    StatesList = new HashSet<StatesViewModel>();
        //}
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string TwoCharCountryCode { get; set; }
        public string ThreeCharCountryCode { get; set; }

        public List<StatesViewModel> StatesList { get; set; }

    }
}
