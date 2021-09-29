using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Store
    {
        public string Name {get; set;}
        public string Address {get; set;}
        public List<Inventory> Inventories {get; set;}
        public int St_ID {get; set;}

        public override string ToString()
        {
            return $"Store: {this.Name} Located at:{this.Address} ID Number: {St_ID}";
        }
    }
}