using System;
using System.Collections.Generic;

#nullable disable

namespace Hrms.Repository.Models
{
    public partial class Item
    {
        public Item()
        {
            Orders = new HashSet<Order>();
        }

        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal? ItemCost { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
