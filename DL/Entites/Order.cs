using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace DL.Entites
{
    public partial class Order
    {
        public Order()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int StoreId { get; set; }
        public string DateCreated { get; set; }
        public decimal Total { get; set; }
        public string Placed { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
