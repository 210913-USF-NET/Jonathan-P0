using System;
using Models;
using DL;
using Entity = DL.Entites;
using System.Linq;
using System.Collections.Generic;

namespace DL
{
    public class DBrepo : IRepo
    {
        private Entites.PartsStoreDBContext _context;

        public DBrepo(Entites.PartsStoreDBContext context)
        {
            _context = context;
        }
        public List<Models.Store> GetAllStores()
        {
           return _context.Stores.Select(
                Store => new Models.Store(){
                    Name = Store.Name,
                    Address = Store.Address,
                    St_ID = Store.StoreId
                }
            ).ToList();
        }

        public List<Models.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                Customer => new Models.Customer(){
                    Cu_ID = Customer.CustomerId,
                    Name = Customer.Name,
                    City = Customer.City,
                    State = Customer.State
                }
            ).ToList();
        }
        public List<Models.Product> GetAllProducrts()
        {
            return _context.Products.Select(
                Prod => new Models.Product(){
                    P_ID = Prod.ProductId,
                    Name = Prod.Name,
                    Description = Prod.Description,
                    Price = Prod.Price
                }
            ).ToList();
        }

        public List<Models.Inventory> GetStoresInvnetory(string query)
        {
            return _context.Inventories.Where(
                Inv => Inv.StoreId.Contains(query)
            ).Select(
                c => new Models.Inventory(){
                    Inventory_ID = c.InventoryId,
                    Store_ID = c.StoreId,
                    Item_ID = c.ProductId,
                    Quantity = c.Quantity
                }
            ).ToList();

        }

        public Models.Customer AddCustomer(Models.Customer newbie)
        {
            Entity.Customer newCustomer = new Entity.Customer(){
                Name = newbie.Name,
                City = newbie.City ?? "",
                State = newbie.State ?? "",
                CustomerId = newbie.Cu_ID
            };

            newCustomer = _context.Add(newCustomer).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return new Models.Customer(){
                Cu_ID = newCustomer.CustomerId,
                Name = newCustomer.Name,
                City = newCustomer.City,
                State = newCustomer.State
            };

        }

        public void AddOrder(Order cart)
        {
            Entity.Order newOrder = new Entity.Order(){
                OrderId = cart.Order_ID,
                CustomerId = cart.Customer_ID,
                StoreId = cart.Store_ID,
                DateCreated = cart.Date,
                Total = cart.Total
            };
            newOrder = _context.Add(newOrder).Entity;
            
            _context.SaveChanges();

            _context.ChangeTracker.Clear();
        }

        public List<Customer> SearchCustomer(string query)
        {
            return _context.Customers.Where(
                customer => customer.Name.Contains(query)
            ).Select(
                c => new Models.Customer(){
                    Cu_ID = c.CustomerId,
                    Name = c.Name,
                    City = c.City,
                    State = c.State
                }
            ).ToList();
        }
        public List<Models.Order> SearchOrders(Store store)
        {
            return _context.Orders.Where(
                order => order.StoreId == store.St_ID).Select(
                    o => new Models.Order(){
                        Order_ID = o.OrderId,
                        Customer_ID = o.CustomerId,
                        Store_ID = o.StoreId,
                        Date = o.DateCreated,
                        Total = o.Total
                    }
                ).ToList();
        }
        public List<Models.Order> SearchOrders(string ID)
        {
            return _context.Orders.Where(
                order => order.CustomerId.Contains(ID)).Select(
                    o => new Models.Order(){
                        Order_ID = o.OrderId,
                        Customer_ID = o.CustomerId,
                        Store_ID = o.StoreId,
                        Date = o.DateCreated,
                        Total = o.Total
                    }
                ).ToList();
        }
    }
}
