using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public int Order_ID{get; set;}
        public string Customer_ID {get; set;}
        public int Store_ID {get; set;}
        public string Date {get; set;}
        public decimal Total {get; set;}
        public List<LineItem> LineItems {get; set;}

        public string Placed {get; set;}

        public void addLineItem(LineItem item)
        {
            LineItems.Add(item);
        }

        public void SumTotal(){
            decimal sum = 0;
            foreach(LineItem item in LineItems)
            {
                sum = sum + item.Item.Price;
            }
            this.Total = sum;
        }
    }
}