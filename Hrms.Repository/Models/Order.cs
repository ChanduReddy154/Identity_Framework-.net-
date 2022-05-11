using System;
using System.Collections.Generic;

#nullable disable

namespace Hrms.Repository.Models
{
    public partial class Order
    {
        public string UserId { get; set; }
        public string ItemId { get; set; }
        public DateTime? InsertedOn { get; set; }
        public int Id { get; set; }

        public virtual Item Item { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
