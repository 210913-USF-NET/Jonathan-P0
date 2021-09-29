using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Inventory
    {
        public int Inventory_ID {get; set;}
        public string Store_ID{get; set;}
        public int Item_ID {get; set;}
        public int Quantity {get; set;}
    }
}