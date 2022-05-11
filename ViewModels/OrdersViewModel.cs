using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
   public class OrdersViewModel
    {
        public string UserId { get; set; }
        public string ItemId { get; set; }
        public DateTime? InsertedOn { get; set; }

        public int Id { get; set; }

    }
}
