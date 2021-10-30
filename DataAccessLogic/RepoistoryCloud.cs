using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Entity = DataAccessLogic.Entities;
using Model = Models;

namespace DataAccessLogic
{
    public class RespositoryCloud : InterfaceRepository
    {
        private Entity.P0DatabaseContext _context;
        public RespositoryCloud(Entity.P0DatabaseContext p_context)
        {
            _context = p_context;
        }

        public Customer AddCustomersDL(Customer parameterobj)
        {
            _context.Customers.Add
            (
                new Entity.Customer()
                {
                    FirstName = parameterobj.CustomerName,
                    Email = parameterobj.Contact,
                    UserName = parameterobj.UserName,
                    Password = parameterobj.Password,
                    Category = parameterobj.Position,
                    Age = parameterobj._age,
                    Address = parameterobj.Address,
                    CurrentCurrency=parameterobj.Currency

                }
            );

            //This method will save the changes made to the database
            _context.SaveChanges();

            return parameterobj;
        }
        public List<Customer> GetAllCustomersDL()
        {
            List<Customer> test = _context.Customers.Select(client =>
                   new Model.Customer()
                   {

                       Id = client.CustomerId,
                       CustomerName = client.FirstName,
                       Contact = client.Email,
                       UserName = client.UserName,
                       Password = client.Password,
                       Position = client.Category,
                       Address = client.Address,
                       _age = client.Age,
                       Currency=client.CurrentCurrency
                   }
            ).ToList();
            return test;
        }
        public Customer DLGetCustomer(string name, string password)
        {
            Customer obj = new Customer();
            List<Customer> listOfStores = GetAllCustomersDL();
            bool result = VerifyCredentials(name, password);
            if (result == false)
            {
                throw new Exception("Customer Not found");
            }

            obj = listOfStores.FirstOrDefault(rest => rest.UserName == name && rest.Password == password);


            return obj;
        }
        public Models.Customer DLModifyCustomerRecord(Models.Customer currentSelection)
        {
            Models.Customer test = DLGetCustomer(currentSelection.UserName, currentSelection.Password);

            _context.Customers.Update
            (
                new Entity.Customer()
                {
                    FirstName = currentSelection.CustomerName,
                    Email = currentSelection.Contact,
                    UserName = currentSelection.UserName,
                    Password = currentSelection.Password,
                    Category = currentSelection.Position,
                    Age = currentSelection._age,
                    Address = currentSelection.Address,
                    CustomerId = currentSelection.Id,
                    CurrentCurrency=currentSelection.Currency
                }
            );

            //This method will save the changes made to the database
            _context.SaveChanges();

            //Will return a customer object from the parameter
            return currentSelection;
        }

        public bool VerifyCredentials(string name, string password)
        {
            List<Customer> listOfCustomers = GetAllCustomersDL();
            bool result = true;
            Customer obj = listOfCustomers.FirstOrDefault(client => client.UserName == name && client.Password == password);
            if (obj == null)
            {
                result = false;
            }

            return result;
        }




        public StoreFront AddStoreFrontDL(StoreFront parameterobj)
        {
            _context.StoreFronts.Add
           (
               new Entity.StoreFront()
               {
                   StoreName = parameterobj.Name,
                   Location = parameterobj.Address


               }
           );

            //This method will save the changes made to the database
            _context.SaveChanges();

            return parameterobj;
        }





        public List<StoreFront> DLSearchStores(string name)
        {
            List<StoreFront> listofstores = GetAllStoreFrontDL();

            //Select method will give a list of boolean if the condition was true/false
            //Where method will give the actual element itself based on some condition
            //ToList method will convert into List that our method currently needs to return.
            //ToLower will lowercase the string to make it not case sensitive
            listofstores = listofstores.Where(store => store.Name.ToLower().Contains(name.ToLower())).ToList();
            if (listofstores.Count < 1)
            {
                throw new Exception("Store Not found");
            }

            return listofstores;
        }
        public List<StoreFront> GetAllStoreFrontDL()
        {
            List<StoreFront> test = _context.StoreFronts.Select(storeobj =>
                   new Model.StoreFront()
                   {

                       Id = storeobj.StoreId,
                       Name = storeobj.StoreName,
                       Address = storeobj.Location
                   }
            ).ToList();
            return test;
        }

        public LineItems DLVerifyStock(int productnum, StoreFront chosen)
        {
            LineItems obj = new LineItems();
            List<LineItems> listofline = new List<LineItems>();
            listofline = GetInventory(chosen.Id);
            bool result = listofline.Exists(x => x.ProductEstablish.Id == productnum);
            if (result == false)
            {
                throw new Exception("Product Not found in store");
            }
            obj = listofline.FirstOrDefault(prodobj => prodobj.ProductEstablish.Id == productnum);
            return obj;
        }


        public Orders AddOrdersDL(Orders parameterobj,StoreFront store,Customer client)
        {
            _context.OrdersRecords.Add
            (
                new Entity.OrdersRecord()
                {
                    Total = parameterobj.TotalPrice,
                    CustomerId=client.Id,
                    StoreId=store.Id


                });
            _context.SaveChanges();
            return parameterobj;
        }


        public List<Orders> GetAllOrdersDL()
        {
            List<Orders> test = _context.OrdersRecords.Select(rest =>
                   new Model.Orders()
                   {

                       Id = rest.OrderId,
                       TotalPrice = rest.Total,
                   }
            ).ToList();
            return test;
        }






        public LineItems AddStockToDB(StoreFront store, Products prod, int quantity)
        {
            LineItems test = new LineItems();
            _context.Stocks.Add
           (
               new Entity.Stock()
               {
                   StoreId = store.Id,
                   ProductId = prod.Id,
                   InStock = quantity


               }
           );

            //This method will save the changes made to the database
            _context.SaveChanges();

            return test;
        }

        public List<Models.Products> GetAllProductsDL()
        {
            List<Models.Products> test = _context.Products.Select(prodobj =>
                   new Model.Products()
                   {

                       Id = prodobj.ProductId,
                       Name = prodobj.Name,
                       Price = prodobj.Price,
                       Description = prodobj.Description,
                       Category = prodobj.Category

                   }
            ).ToList();
            return test;
        }

        public Products AddProductsDL(Products parameterObj)
        {
            _context.Products.Add
            (
                new Entity.Product()
                {
                    Name = parameterObj.Name,
                    Price = parameterObj.Price,
                    Description = parameterObj.Description,
                    Category = parameterObj.Category,


                }
            );

            //This method will save the changes made to the database
            _context.SaveChanges();

            return parameterObj;
        }

        public bool VerifyProduct(int identification)
        {
            Entity.Product looking = _context.Products.Find(identification);
            bool result = true;
            if (looking == null)
            {
                result = false;
            }
            return result;

        }
        public Products GetProduct(int obj)
        {
            Models.Products test = new Models.Products();
            bool result = VerifyProduct(obj);
            if (result == false)
            {
                throw new Exception("Product Was not found with entered ID number");
            }
            else
            {
                Entity.Product looking = _context.Products.Find(obj);
                test.Name = looking.Name;
                test.Id = looking.ProductId;
                test.Price = looking.Price;
                test.Category = looking.Category;
                test.Description = looking.Description;
                return test;
            }



        }

        public List<LineItems> GetInventory(int obj)
        {
            // var innerJoinResult = from s in _context.StoreFronts // outer sequence
            // 				  join st in _context.Stocks //inner sequence 
            // 				  on s.StoreId equals st.StoreId // key selector 
            //                   where s.StoreId==obj
            // 				  select new { // result selector 
            // 								StoreName = s.StoreName, 
            //                                 StoreLocation=s.Location,
            //                                 StockItem=st.Product.Name,
            //                                 StockItemPrice=st.Product.Price,
            // 								storequantity = st.InStock 
            // 							};


            var result = from compl in _context.Stocks
                                   where compl.StoreId == obj
                                   select new { compl.Product, compl.InStock };


            //Mapping the Queryable<Entity.Review> into a list<Model.Review>
            List<Model.LineItems> listofItems = new List<Model.LineItems>();

            foreach (var row in result)
            {
                LineItems test = new LineItems();
                test.ProductEstablish = new Model.Products()
                {
                    Price = row.Product.Price,
                    Name = row.Product.Name,
                    Id = row.Product.ProductId,
                    Description = row.Product.Description,
                    Category = row.Product.Category

                };
                test.Quantity = row.InStock;

                listofItems.Add(test);
            }

            return listofItems;
        }

        public StoreFront GetStoreByID(int number)
        {
            Models.StoreFront test = new Models.StoreFront();
            bool result = VerifyStorebyID(number);
            if (result == false)
            {
                throw new Exception("Product Was not found with entered ID number");
            }
            else
            {
                Entity.StoreFront looking = _context.StoreFronts.Find(number);
                test.Name = looking.StoreName;
                test.Id = looking.StoreId;
                test.Name = looking.Location;
                return test;
            }

        }
        public bool VerifyStorebyID(int number)
        {
            Entity.StoreFront looking = _context.StoreFronts.Find(number);

            bool result = true;
            if (looking == null)
            {
                result = false;
            }
            return result;

        }

        public void InsertHistory(int store, int prod, int order, int customer,int quantity)
        {
            _context.OrderHistories.Add
           (
               new Entity.OrderHistory()
               {
                   StoreId = store,
                   ProductId = prod,
                   OrderId = order,
                   CustomerId = customer,
                   LineQuantity=quantity
                   



               }
           );

            //This method will save the changes made to the database
            _context.SaveChanges();
        }

        public Orders GetOrderID(Orders obj)
        {
            List<Model.Orders> test = new List<Model.Orders>();
            test = GetAllOrdersDL();
            IEnumerable<Orders> query = test.OrderBy(x => x.Id);
            Models.Orders temp = query.Last();
            obj.Id = temp.Id;
            return obj;
        }

        public void ModifyStockTable(int storenumber, int productnumber, int quantity)
        {

            _context.Stocks.Update
            (
                new Entity.Stock()
                {
                    StoreId = storenumber,
                    ProductId = productnumber,
                    InStock = quantity

                }
            );

            //This method will save the changes made to the database
            _context.SaveChanges();
        }

        public List<Orders> GetMyOrderHistory(int objId)
        {
            var innerJoinResult2 = from compl in _context.OrderHistories
                                   where compl.CustomerId == objId
                                   select new { compl.Order, compl.Product, compl.Store };


            //Mapping the Queryable<Entity.rowiew> into a list<Model.Review>
            List<Model.Orders> listofItems = new List<Model.Orders>();

            foreach (var row in innerJoinResult2)
            {
                LineItems test = new LineItems();
                Model.Orders mine = new Orders();
                
                test.ProductEstablish = new Model.Products()
                {
                    Price = row.Product.Price,
                    Name = row.Product.Name,
                    Id = row.Product.ProductId,
                    Description = row.Product.Description,
                    Category = row.Product.Category

                };
                mine.Id = row.Order.OrderId;
                mine.TotalPrice = row.Order.Total;
                mine.ItemsList.Add(test);
                mine.Location = new Model.StoreFront()
                {
                    Name = row.Store.StoreName,
                    Address = row.Store.Location,
                    Id = row.Store.StoreId
                };

                listofItems.Add(mine);
            }
           

            return listofItems;
        }

        public List<Orders> GetStoreOrderHistory(int objId)
        {
            var result = from compl in _context.OrderHistories
                                   where compl.StoreId == objId
                                   select new { compl.Order, compl.Product, compl.Store };


            //Mapping the Queryable<Entity.Review> into a list<Model.Review>
            List<Model.Orders> listofItems = new List<Model.Orders>();

            foreach (var rev in result)
            {
                LineItems test = new LineItems();
                Model.Orders mine = new Orders();
                
                test.ProductEstablish = new Model.Products()
                {
                    Price = rev.Product.Price,
                    Name = rev.Product.Name,
                    Id = rev.Product.ProductId,
                    Description = rev.Product.Description,
                    Category = rev.Product.Category

                };
                mine.Id = rev.Order.OrderId;
                mine.TotalPrice = rev.Order.Total;
                mine.ItemsList.Add(test);
                mine.Location = new Model.StoreFront()
                {
                    Name = rev.Store.StoreName,
                    Address = rev.Store.Location,
                    Id = rev.Store.StoreId
                };

                listofItems.Add(mine);
            }
           

            return listofItems;
        }
    }
}
