using System;
using Models;
using DataAccessLogic;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BL :InterfaceBL
    {

        private Repository _repo;
        /// <summary>
        /// We are defining the dependencies this class needs to operate
        /// We do it this way because we can easily switch out which implementation details we will be using
        /// </summary>
        /// <param name="p_repo"></param>
        public BL(Repository p_repo)
        {
            _repo = p_repo;
        }

        /// <summary>
        /// this method will send a customer object established in the user interface 
        /// and the end result would be equal to a customer value established in the method established in the repository class.
        /// </summary>
        /// <param name="parameterObj"></param>
        /// <returns></returns>
        public Customer AddCustomersBL(Customer parameterObj)
        {
            return _repo.AddCustomersDL(parameterObj);
        }
        /// <summary>
        /// this method returns a list established for Customer objects which is received from a repository method 
        /// </summary>
        /// <returns> all the information in the specified json file established in the method .</returns>
        public List<Customer> GetAllCustomersBL()
        {
            return _repo.GetAllCustomersDL();
        }


      public void VerifyCredentials()
        {
            List<Customer> listOfCustomers = GetAllCustomersBL();
            bool result=listOfCustomers.Exists(x => x._username == Customer.displayName);
                if (result==false)
                { throw new Exception ("User Not found");
                }
                string text= listOfCustomers.Find(x => x._username.Contains(Customer.displayName)).PrintName();
                     Customer.displayName=text;
        }

            /// <summary>
            /// this method will send a customer object established in the user interface 
            /// and the end result would be equal to a StoreFront value established in the method established in the repository class.
            /// 
            /// </summary>
            /// <param name="parameterObj"></param>
            /// <returns></returns>
        public StoreFront AddStoreFrontBL(StoreFront parameterObj)
        {
            return _repo.AddStoreFrontDL(parameterObj);
        }

        /// <summary>
        /// this method returns a list established for Customer objects which is received from a repository method 
        /// </summary>
        /// <returns> all the information in the specified json file established in the method .</returns>
        public List<StoreFront> GetAllStoreFrontsBL()
        {
            return _repo.GetAllStoreFrontDL();
            
        }

        /// <summary>
        /// this method will send a customer object established in the user interface 
        /// and the end result would be equal to a Products value established in the method established in the repository class.
        /// 
        /// </summary>
        /// <param name="parameterObj"></param>
        /// <returns></returns>
        public Products AddProductsBL(Products parameterObj)
        {
            return _repo.AddProductsDL(parameterObj);
        }


        /// <summary>
        /// this method returns a list established for Customer objects which is received from a repository method 
        /// </summary>
        /// <returns> all the information in the specified json file established in the method .</returns>
        public List<Products> GetAllProductsBL()
        {
           return _repo.GetAllProductsDL();
        }
        /// <summary>
        /// this method will send a customer object established in the user interface 
        /// and the end result would be equal to a orders value established in the method established in the repository class.
        /// 
        /// </summary>
        /// <param name="parameterObj"></param>
        /// <returns></returns>
        public Orders AddOrdersBL(Orders parameterObj)
        {
            return _repo.AddOrdersDL(parameterObj);
        }

        /// <summary>
        /// this method returns a list established for Customer objects which is received from a repository method 
        /// </summary>
        /// <returns> all the information in the specified json file established in the method .</returns>
        public List<Orders> GetAllOrdersBL()
        {
           return _repo.GetAllOrdersDL();
        }

        /// <summary>
        /// this method will send a customer object established in the user interface 
        /// and the end result would be equal to a line items value established in the method established in the repository class.
        /// 
        /// </summary>
        /// <param name="parameterObj"></param>
        /// <returns></returns>
        public LineItems AddLineItemsBL(LineItems parameterObj)
                {
                    return _repo.AddLineItemsDL(parameterObj);
                }
                
        /// <summary>
        /// this method returns a list established for Customer objects which is received from a repository method 
        /// </summary>
        /// <returns> all the information in the specified json file established in the method .</returns>
        public List<LineItems> GetAllLineItemsBL()
        {
           return _repo.GetAllLineItemsDL();
        }
        

        public Products CreateProduct()
        { 
            Products obj= new Products();
            Console.WriteLine("Type in the line item/ product name\n");
             obj._name =Console.ReadLine();
             Console.WriteLine("\nType in the line item/ products price\n");
              obj._price=Convert.ToDouble(Console.ReadLine());

            return obj;

        }

        public bool VerifyStore(string name)
        {
            List<StoreFront> listOfStores = GetAllStoreFrontsBL();
            bool result=listOfStores.Exists(x => x._name == name);
                return result;
               
        }

        public StoreFront GetStore(string name)
        {
            StoreFront obj=new StoreFront();
            List<StoreFront> listOfStores = GetAllStoreFrontsBL();
                bool result=VerifyStore(name);
                if (result==false)
                {
                     throw new Exception ("Store Not found");
                }

               obj=listOfStores.FirstOrDefault(rest => rest.Name == name);


            return obj;
        }

        public List<Products> ShowProducts(StoreFront chosen)
        {
            List<Products> listOfProduct = new List<Products>();
            chosen=GetStore(chosen._name);
            foreach(Products p in chosen.productslist)
            {
                listOfProduct.Add(p);
            }
            return listOfProduct;
        }

        public List<StoreFront> SearchStores(string name)
        {
            List<StoreFront> listOfRestaurant = _repo.GetAllStoreFrontDL();
            
            //Select method will give a list of boolean if the condition was true/false
            //Where method will give the actual element itself based on some condition
            //ToList method will convert into List that our method currently needs to return.
            //ToLower will lowercase the string to make it not case sensitive
            listOfRestaurant=listOfRestaurant.Where(rest => rest._name.ToLower().Contains(name.ToLower())).ToList();
            if(listOfRestaurant.Count<1)
            { 
                throw new Exception ("Store Not found");
            }

            return listOfRestaurant;
        }

        public Products VerifyProduct(string product,StoreFront chosen)
        {
            Products obj = new Products();
            List<Products> listOfProduct = new List<Products>();
            listOfProduct=ShowProducts(chosen);
            bool result=listOfProduct.Exists(x => x._name == product);
           if (result==false)
                {
                     throw new Exception ("Product Not found in store");
                }
                obj=listOfProduct.FirstOrDefault(rest => rest._name == product);
            return obj;
        }
        
    }
}