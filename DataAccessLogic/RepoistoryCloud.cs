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
                    Password=p_rest._password,
                    Category=p_rest.Position,
                    Age=p_rest._age,
                    Address=p_rest._address

                }
            );

            //This method will save the changes made to the database
            _context.SaveChanges();

            return p_rest;
        }

        public Orders AddOrdersDL(Orders p_rest)
        {
            throw new System.NotImplementedException();
        }

       

        public StoreFront AddStoreFrontDL(StoreFront p_rest)
        {
            throw new System.NotImplementedException();
        }


        public StoreFront DLGetStore(string name)
        {
            throw new System.NotImplementedException();
        }


        public StoreFront DLModifyStoreRecord(StoreFront currentSelection)
        {
            throw new System.NotImplementedException();
        }

        public List<StoreFront> DLSearchStores(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<LineItems> DLShowStock(StoreFront chosen)
        {
            throw new System.NotImplementedException();
        }

        public LineItems DLVerifyStock(string product, StoreFront chosen)
        {
            throw new System.NotImplementedException();
        }

        public bool DLVerifyStore(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAllCustomersDL()
        {
            List<Customer>test=_context.Customers.Select(rest => 
                new Model.Customer()
                {
                    
                    Id = rest.CustomerId,
                    CustomerName = rest.FirstName,
                    Contact = rest.Email,
                    UserName = rest.UserName,
                    Password=rest.Password,
                    Position=rest.Category,
                    Address=rest.Address,
                }
            ).ToList();
            return test;
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

        public List<StoreFront> GetAllStoreFrontDL()
        {
            throw new System.NotImplementedException();
        }
         public Customer DLGetCustomer(string name,string password)
        {
            Customer obj = new Customer();
            List<Customer> listOfStores = GetAllCustomersDL();
            bool result = VerifyCredentials(name,password);
            if (result == false)
            {
                throw new Exception("Customer Not found");
            }

            obj = listOfStores.FirstOrDefault(rest => rest._username == name && rest._password == password);


            return obj;
        }

        public bool VerifyCredentials(string name,string password)
        {
            List<Customer> listOfCustomers = GetAllCustomersDL();
            bool result=true;
            Customer obj = listOfCustomers.FirstOrDefault(rest => rest._username == name && rest._password == password);
            if (obj == null)
            {
                result=false;
            }
            
            return result;
        }
        public Models.Customer DLModifyCustomerRecord(Models.Customer currentSelection)
        {
            Models.Customer test = DLGetCustomer(currentSelection._username,currentSelection._password);

            _context.Customers.Update
            (
                new Entity.Customer()
                {
                    FirstName = currentSelection._name,
                    Email = currentSelection._contact,
                    UserName = currentSelection._username,
                    Password=currentSelection._password,
                    Category=currentSelection.Position,
                    Age=currentSelection._age,
                    Address=currentSelection._address,
                    CustomerId=currentSelection.Id
                }
            );

            //This method will save the changes made to the database
            _context.SaveChanges();

            //Will return a customer object from the parameter
            return currentSelection;
        }
    }
}