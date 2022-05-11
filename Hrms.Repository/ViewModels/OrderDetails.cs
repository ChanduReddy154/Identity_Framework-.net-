using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.ViewModels
{
   public  class OrderDetails
    {

        public string UserName { get; set; }

        public string  PhoneNumber { get; set; }

        public string Email { get; set; }

        public string ItemName { get; set; }

        public decimal ItemCost { get; set; }

        public DateTime InsertedOn { get; set; }

    }
}
