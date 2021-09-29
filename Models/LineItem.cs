using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class LineItem
    {
        public int LineItem_ID {get; set;}
        public int Order_ID {get; set;}
        public Product Item {get; set;}
        public int Quantity {get; set;}
    }
}