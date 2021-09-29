using System;
using Models;
using StoreBL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI
{
    public class MainMenu
    {
        private IBL _bl;
        public MainMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            bool exit = false;
            string input = "";
            do
            {
                Console.WriteLine("[0] Customer page");
                Console.WriteLine("[1] Admin page");
                Console.WriteLine("[X] Exit");
                input = Console.ReadLine();

                switch(input)
                {
                    case "0":
                        Console.WriteLine("Entering Customer Page");
                        new CustomerMenu(_bl).Start();
                        break;
                    case "1":
                        Console.WriteLine("Entering Admin Page");
                        new AdminMenu(_bl).Start();
                        break;
                    case "X":
                        Console.WriteLine("GoodBye");
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