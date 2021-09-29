using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL
{
    public interface IRepo
    {
        List<Store> GetAllStores();

        List<Product> GetAllProducrts();
        List<Customer> GetAllCustomers();

        List<Inventory> GetStoresInvnetory(string ID);

        Customer AddCustomer(Customer newbie);

        void AddOrder(Order cart);
        List<Customer> SearchCustomer(string query);

        List<Order> SearchOrders(Store store);
        List<Order> SearchOrders(string ID);
    }
}