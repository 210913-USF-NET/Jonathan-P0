using System;
using Models;
using StoreBL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI
{
    public class CustomerMenu
    {
        private IBL _bl;
        public CustomerMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            Console.WriteLine("\nWelcome to the Customer page");
            bool exit = false;
            string input = "";
            Customer User;
            
            do
            {
                Console.WriteLine("\n[0] Create new customer profile");
                Console.WriteLine("[1] Login returning Customer");
                Console.WriteLine("[X] Exit");
                input = Console.ReadLine();

                switch(input)
                {
                    case "0":
                        Console.WriteLine("Creating new Customer");
                        User = AddCustomer();
                        ShoppingPortal(User);
                        break;
                    case "1":
                        Console.WriteLine("Loging in");
                        User = Login();
                        ShoppingPortal(User);
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

        private Customer AddCustomer()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State Intials");
            string state = Console.ReadLine();
            Customer newbie = new Customer(name,city,state);
            string ID = RandomString();
            newbie.Cu_ID = ID;

            Customer AddedCustomer = _bl.AddCustomer(newbie);
            Console.WriteLine("New Customer profile was created");
            return AddedCustomer;
        }
        
        private string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var RandomString = new string(Enumerable.Repeat(chars,10).Select(s => s[random.Next(s.Length)]).ToArray());
            return RandomString;
        }

        private Customer Login()
        {
            Console.WriteLine("Please Enter Name");
            string searchName = Console.ReadLine();
            List<Customer> Matched = _bl.SearchCustomer(searchName);
            if(Matched == null || Matched.Count()==0)
            {
                Console.WriteLine("There are Customers with that name");
                Console.WriteLine("Creating new User in absence");
                return AddCustomer();
            }
            else{
                foreach (Customer person in Matched)
                {
                    if(person.Name.ToLower() == searchName.ToLower())
                    {
                        Console.WriteLine($"Welcome Back {person.Name}");
                        return person;
                    }
                }
                Console.WriteLine("Error has occured. Creating new user");
                return AddCustomer();
            }
        }
        private void ShoppingPortal(Customer user)
        {
            List<Store> Stores = _bl.GetAllStores();
            Store SelectedStore;
            int i = 0;
            foreach(Store store in Stores)
            {
                Console.WriteLine($"[{i}] {store.ToString()}");
                i++;
            }
            
            Console.WriteLine("\nPlease type the number associated with the store you whish to check. ");
            string input = Console.ReadLine();
            try
            {
                int attempt = int.Parse(input);
            }catch(Exception e){
                Console.WriteLine(e);
                return;
            }

            SelectedStore = Stores[int.Parse(input)];
            Order cart = new Order();
            
            List<LineItem> items = new List<LineItem>(); 
            string CustomerID = user.Cu_ID; 
            int OrderID = RandomNumber();
            int StoreID = SelectedStore.St_ID;
                     
                        
            List<Product> products = _bl.GetAllProducrts();
            List<Inventory> Stock = _bl.GetStoresInvnetory(Convert.ToString(SelectedStore.St_ID));

            Console.WriteLine("Displaying Store Stock now");
            bool ReadyPurchase = false;
            do
            {
                DisplayStock(products,Stock);
                Console.WriteLine("\nPlease enter the product Id you wish to purcase");
                string inp = Console.ReadLine();
                try
                {
                    int attempt = int.Parse(input);
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
                int index = int.Parse(input);
                Product Prod = products[index];

                Console.WriteLine("And How many do you wish to purchase");
                string num = Console.ReadLine();
                try{
                    int attempt = int.Parse(num);
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
                int numOfItems = int.Parse(num);
                LineItem newLine = new LineItem();
                newLine.LineItem_ID = RandomNumber();
                newLine.Order_ID = OrderID;
                newLine.Item = Prod;
                newLine.Quantity = numOfItems;
                items.Add(newLine);

                Console.WriteLine("\nAre you ready for purchase yes/no");
                string confirmation = Console.ReadLine();
                if(confirmation.ToLower() == "yes")
                {
                    ReadyPurchase = true;
                }

            }while(!ReadyPurchase);

            cart.LineItems = items;
            cart.Order_ID = OrderID;
            cart.Customer_ID = CustomerID;
            cart.Store_ID = StoreID;
            cart.Date = GetDate();
            cart.SumTotal();
            cart.Placed = "Placed";

            Console.WriteLine($"You're totalt comes to ${cart.Total}. Thank you for your purchase");
            _bl.AddOrder(cart);


        }
        private int RandomNumber()
        {
            Random r = new Random();
            int generated = r.Next(10000,99999);
            return generated;
        }

        private string GetDate()
        {
            string Month = DateTime.Now.ToString("mm");
            string Day = DateTime.Now.ToString("dd");
            string year = DateTime.Now.ToString("yyyy");
            return $"{Month}-{Day}-{year}";
        }


        private void DisplayStock(List<Product> products, List<Inventory> stock)
        {
            foreach(Inventory inv in stock)
            {
                foreach(Product prod in products)
                {
                    if(prod.P_ID == inv.Item_ID)
                    {
                        Console.WriteLine($"Prooduct Name: {prod.Name} Product ID: {prod.P_ID} Store Quantity: {inv.Quantity}");
                    }
                }
            }
        }
    }
}