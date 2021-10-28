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

        public Customer AddCustomersDL(Customer p_rest)
        {
            _context.Customers.Add
            (
                new Entity.Customer()
                {
                    FirstName = p_rest._name,
                    Email = p_rest._contact,
                    UserName = p_rest._username,
                    Password = p_rest._password,
                    Category = p_rest.Position,
                    Age = p_rest._age,
                    Address = p_rest._address

                }
            );

            //This method will save the changes made to the database
            _context.SaveChanges();

            return p_rest;
        }
        public List<Customer> GetAllCustomersDL()
        {
            List<Customer> test = _context.Customers.Select(rest =>
                   new Model.Customer()
                   {

                       Id = rest.CustomerId,
                       CustomerName = rest.FirstName,
                       Contact = rest.Email,
                       UserName = rest.UserName,
                       Password = rest.Password,
                       Position = rest.Category,
                       Address = rest.Address,
                       _age = rest.Age,
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

            obj = listOfStores.FirstOrDefault(rest => rest._username == name && rest._password == password);


            return obj;
        }
        public Models.Customer DLModifyCustomerRecord(Models.Customer currentSelection)
        {
            Models.Customer test = DLGetCustomer(currentSelection._username, currentSelection._password);

            _context.Customers.Update
            (
                new Entity.Customer()
                {
                    FirstName = currentSelection._name,
                    Email = currentSelection._contact,
                    UserName = currentSelection._username,
                    Password = currentSelection._password,
                    Category = currentSelection.Position,
                    Age = currentSelection._age,
                    Address = currentSelection._address,
                    CustomerId = currentSelection.Id
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
            Customer obj = listOfCustomers.FirstOrDefault(rest => rest._username == name && rest._password == password);
            if (obj == null)
            {
                result = false;
            }

            return result;
        }




        public StoreFront AddStoreFrontDL(StoreFront p_rest)
        {
            _context.StoreFronts.Add
           (
               new Entity.StoreFront()
               {
                   StoreName = p_rest._name,
                   Location = p_rest._address


               }
           );

            //This method will save the changes made to the database
            _context.SaveChanges();

            return p_rest;
        }


        public StoreFront DLGetStore(string name, string address)
        {
            StoreFront obj = new StoreFront();
            List<StoreFront> listOfStores = GetAllStoreFrontDL();
            bool result = DLVerifyStore(name, address);
            if (result == false)
            {
                throw new Exception("Store Not found");
            }

            obj = listOfStores.FirstOrDefault(rest => rest._name == name && rest._address == address);


            return obj;
        }
        public bool DLVerifyStore(string name, string addre)
        {
            List<StoreFront> listOfCustomers = GetAllStoreFrontDL();
            bool result = true;
            StoreFront obj = listOfCustomers.FirstOrDefault(rest => rest._name == name && rest._address == addre);
            if (obj == null)
            {
                result = false;
            }

            return result;
        }

        public StoreFront DLModifyStoreRecord(StoreFront currentSelection)
        {
            throw new System.NotImplementedException();
        }

        public List<StoreFront> DLSearchStores(string name)
        {
            List<StoreFront> listOfRestaurant = GetAllStoreFrontDL();

            //Select method will give a list of boolean if the condition was true/false
            //Where method will give the actual element itself based on some condition
            //ToList method will convert into List that our method currently needs to return.
            //ToLower will lowercase the string to make it not case sensitive
            listOfRestaurant = listOfRestaurant.Where(rest => rest._name.ToLower().Contains(name.ToLower())).ToList();
            if (listOfRestaurant.Count < 1)
            {
                throw new Exception("Store Not found");
            }

            return listOfRestaurant;
        }
        public List<StoreFront> GetAllStoreFrontDL()
        {
            List<StoreFront> test = _context.StoreFronts.Select(rest =>
                   new Model.StoreFront()
                   {

                       Id = rest.StoreId,
                       _name = rest.StoreName,
                       _address = rest.Location
                   }
            ).ToList();
            return test;
        }
        public List<LineItems> DLShowStock(StoreFront chosen)
        {
            throw new System.NotImplementedException();
        }

        public LineItems DLVerifyStock(string product, StoreFront chosen)
        {
            throw new System.NotImplementedException();
        }


        public Orders AddOrdersDL(Orders p_rest)
        {
            throw new System.NotImplementedException();
        }


        public List<Orders> GetAllOrdersDL()
        {
            throw new System.NotImplementedException();
        }

        // public List<Model.Restaurant> GetAllRestaurant()
        // {
        //     //Method Syntax
        //     return _context.Restaurants.Select(rest => 
        //         new Model.Restaurant()
        //         {
        //             Name = rest.RestName,
        //             State = rest.RestState,
        //             City = rest.RestCity,
        //             Id = rest.RestId
        //         }
        //     ).ToList();


        //     //Query Syntax
        //     // var result = (from rest in _context.Restaurants
        //     //             select rest);

        //     // List<Model.Restaurant> listOfRest = new List<Model.Restaurant>();
        //     // foreach (var rest in result)
        //     // {
        //     //     listOfRest.Add(new Model.Restaurant(){
        //     //         Name = rest.RestName,
        //     //         State = rest.RestState,
        //     //         City = rest.RestCity,
        //     //         Id = rest.RestId
        //     //     });
        //     // }

        //     // return listOfRest;
        // }







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
            List<Models.Products> test = _context.Products.Select(rest =>
                   new Model.Products()
                   {

                       Id = rest.ProductId,
                       _name = rest.Name,
                       _price = rest.Price,
                       Description = rest.Description,
                       Category = rest.Category

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
                    Name = parameterObj._name,
                    Price = parameterObj._price,
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
            Entity.Product restToFind = _context.Products.Find(identification);
            // Model.Products test=new Model.Products();
            // test._name=restToFind.Name;
            // test.Id=restToFind.ProductId;
            // test._price=restToFind.Price;
            // test.Category=restToFind.Category;
            // test.Description=restToFind.Description;
            bool result = true;
            if (restToFind == null)
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
                Entity.Product restToFind = _context.Products.Find(obj);
                test._name = restToFind.Name;
                test.Id = restToFind.ProductId;
                test._price = restToFind.Price;
                test.Category = restToFind.Category;
                test.Description = restToFind.Description;
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


            var innerJoinResult2 = from compl in _context.Stocks
                                   where compl.StoreId == obj
                                   select new { compl.Product, compl.InStock };


            //Mapping the Queryable<Entity.Review> into a list<Model.Review>
            List<Model.LineItems> listOfReview = new List<Model.LineItems>();

            foreach (var rev in innerJoinResult2)
            {
                LineItems test = new LineItems();
                test._product = new Model.Products()
                {
                    _price = rev.Product.Price,
                    _name = rev.Product.Name,
                    Id = rev.Product.ProductId,
                    Description = rev.Product.Description,
                    Category = rev.Product.Category

                };
                test._quantity = rev.InStock;

                listOfReview.Add(test);
            }

            return listOfReview;
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
                Entity.StoreFront restToFind = _context.StoreFronts.Find(number);
                test._name = restToFind.StoreName;
                test.Id = restToFind.StoreId;
                test._address = restToFind.Location;
                return test;
            }

        }
        public bool VerifyStorebyID(int number)
        {
            Entity.StoreFront restToFind = _context.StoreFronts.Find(number);
            // Model.Products test=new Model.Products();
            // test._name=restToFind.Name;
            // test.Id=restToFind.ProductId;
            // test._price=restToFind.Price;
            // test.Category=restToFind.Category;
            // test.Description=restToFind.Description;
            bool result = true;
            if (restToFind == null)
            {
                result = false;
            }
            return result;

        }

    }
}