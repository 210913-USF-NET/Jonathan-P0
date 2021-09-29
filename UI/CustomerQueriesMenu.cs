using System;
using Models;
using StoreBL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI
{
    public class CustomerQueriesMenu : IMenu
    {
        private IBL _bl;
        public CustomerQueriesMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start()
        {
            Console.WriteLine("\nSelect a Query");
            bool exit = false;
            string input = "";

            do
            {
                Console.WriteLine("\n[0] Display All Customers");
                Console.WriteLine("[1] View Customer oder history");
                Console.WriteLine("[X] Exit");
                input = Console.ReadLine();

                switch(input)
                {
                    case "0":
                        Console.WriteLine("Displaying all Customers");
                        DisplayAllCustomers(FetchCostumers());
                        break;
                    case "1":
                        ViewCustomerHistory();
                        break;
                    case "X":
                        Console.WriteLine("Exiting \n");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }
            }while(!exit);
        }

        private void ViewCustomerHistory()
        {
            List<Customer> customers = FetchCostumers();
            if(customers.Count == 0 || customers == null)
            {
                Console.WriteLine("No Customers");
                return;
            }
            else{
                DisplayAllCustomers(customers);
                Console.WriteLine("Type in Customer ID");
                string ID = Console.ReadLine();
                foreach(Customer person in customers)
                {
                    if(person.Cu_ID == ID)
                    {
                        List<Order> orders = _bl.SearchOrders(ID);
                        if(orders.Count == 0 || orders == null)
                        {
                            Console.WriteLine("No orders from this customer");
                            return;
                        }
                        else
                        {
                            foreach(Order ord in orders)
                        {
                            Console.WriteLine($"{ord.Order_ID}  {ord.Customer_ID}  {ord.Store_ID}  ${ord.Total}  {ord.Date}");
                        }
                        }
                    }
                }
            }
            
        }

        private void DisplayAllCustomers(List<Customer> people)
        {
            if(people.Count == 0)
            {
                Console.WriteLine("No Customers");
            }
            else{
                foreach (Customer person in people)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }

        private List<Customer> FetchCostumers()
        {
            return _bl.GetAllCustomers();
        }

    }
}