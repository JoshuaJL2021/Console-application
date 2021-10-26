using System;
using Models;
using DataAccessLogic;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BL : InterfaceBL
    {

        private InterfaceRepository _repo;
        /// <summary>
        /// We are defining the dependencies this class needs to operate
        /// We do it this way because we can easily switch out which implementation details we will be using
        /// </summary>
        /// <param name="p_repo"></param>
        public BL(InterfaceRepository p_repo)
        {
            _repo = p_repo;
        }

        
        public Customer AddCustomersBL(Customer parameterObj)
        {
            return _repo.AddCustomersDL(parameterObj);
        }
        
        public List<Customer> GetAllCustomersBL()
        {
            return _repo.GetAllCustomersDL();
        }


    
        public StoreFront AddStoreFrontBL(StoreFront parameterObj)
        {
            return _repo.AddStoreFrontDL(parameterObj);
        }


        public List<StoreFront> GetAllStoreFrontsBL()
        {
            return _repo.GetAllStoreFrontDL();

        }

     
        public Orders AddOrdersBL(Orders parameterObj)
        {
            return _repo.AddOrdersDL(parameterObj);
        }

        
        public List<Orders> GetAllOrdersBL()
        {
            return _repo.GetAllOrdersDL();
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

        public Customer ModifyCustomerRecord(Customer currentSelection)
        {
            return _repo.DLModifyCustomerRecord(currentSelection);
        
        } 
        public void VerifyCredentials(String name)
        {
            _repo.VerifyCredentials(name);
            
        }
        public Customer GetCustomer(string name)
        {
            return _repo.DLGetCustomer(name);
        }
        
    }
}