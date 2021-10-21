using System;
using Models;
using DataAccessLogic;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BL : InterfaceBL
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
            Products obj = new Products();
            Console.WriteLine("Type in the line item/ product name\n");
            obj._name = Console.ReadLine();
            Console.WriteLine("\nType in the line item/ products price\n");
            obj._price = Convert.ToDouble(Console.ReadLine());

            return obj;

        }

        public bool VerifyStore(string name)
        {
            
            return _repo.DLVerifyStore(name);

        }

        public StoreFront GetStore(string name)
        {
            return _repo.DLGetStore(name);
        }

       

        public List<StoreFront> SearchStores(string name)
        {
            return _repo.DLSearchStores(name);
        }


        public LineItems VerifyStock(string product, StoreFront chosen)
        {
           return _repo.DLVerifyStock(product,chosen);
        }

        public List<LineItems> ShowStock(StoreFront chosen)
        {
            return _repo.DLShowStock(chosen);
        }

        public StoreFront ModifyStoreRecordBL(StoreFront currentSelection)
        {
            return _repo.DLModifyStoreRecord(currentSelection);
        
        } 
        public void VerifyCredentials(String name)
        {
            _repo.VerifyCredentials(name);
            
        }
        public Customer GetCustomer(string name)
        {
            return _repo.DLGetCustomer(name);
        }
        
        // public List<Products> ShowProducts(StoreFront chosen)
        // {
        //     return _repo.DLShowProducts(chosen);
        // }
        // public Products VerifyProduct(string product, StoreFront chosen)
        // {
        //     return _repo.DLVerifyProduct(product,chosen);
        // }
    }
}