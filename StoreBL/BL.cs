using System;
using Models;
using DL;
using System.Collections.Generic;

namespace StoreBL
{
    public class BL : IBL
    {
        private IRepo _repo;

        public BL(IRepo repo)
        {
            _repo = repo;
        }
        public List<Store> GetAllStores()
        {
            return _repo.GetAllStores();
        }
        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
        public void AddOrder(Order cart)
        {
            _repo.AddOrder(cart);
        }
        public List<Product> GetAllProducrts()
        {
            return _repo.GetAllProducrts();
        }

        public List<Inventory> GetStoresInvnetory(string ID)
        {
            return _repo.GetStoresInvnetory(ID);
        }


        public Customer AddCustomer(Customer newbie)
        {
            return _repo.AddCustomer(newbie);
        }

        public List<Customer> SearchCustomer(string query)
        {
            return _repo.SearchCustomer(query);
        }
        public List<Order> SearchOrders(Store store)
        {
            return _repo.SearchOrders(store);
        }
        public List<Order> SearchOrders(string ID)
        {
            return _repo.SearchOrders(ID);
        }
    }
}
