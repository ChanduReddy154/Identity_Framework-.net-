using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
   public class ItemsViewModel
    {

        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal? ItemCost { get; set; }

    }
}
