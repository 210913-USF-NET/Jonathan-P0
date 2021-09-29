using System;
using Models;
using StoreBL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI
{
    public class AdminMenu
    {
        private IBL _bl;
        public AdminMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            Console.WriteLine("\nWelcome to the Admin page");
            bool exit = false;
            string input = "";
            
            do
            {
                Console.WriteLine("[0] Customer Queries");
                Console.WriteLine("[1] Store Queries");
                Console.WriteLine("[X] Exit");
                input = Console.ReadLine();

                switch(input)
                {
                    case "0":
                        Console.WriteLine("To Customer Queries page");
                        new CustomerQueriesMenu(_bl).Start();
                        break;
                    case "1":
                        Console.WriteLine("To Store Queries page");
                        new StoreQueriesMenu(_bl).Start();
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
    }
}