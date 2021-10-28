using System;
using Models;
using DataAccessLogic;
using System.Collections.Generic;


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
            obj._price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Type in the line item/ product Description\n");
            obj.Description = Console.ReadLine();
            Console.WriteLine("Type in the line item/ product Category\n");
            obj.Category = Console.ReadLine();


            return obj;

        }

        public bool VerifyStore(string name,string address)
        {
            
            return _repo.DLVerifyStore(name,address);

        }

        public StoreFront GetStore(string name,string address)
        {
            return _repo.DLGetStore(name,address);
        }

       

        public List<StoreFront> SearchStores(string name)
        {
            return _repo.DLSearchStores(name);
        }


        public LineItems VerifyStock(int productnum, StoreFront chosen)
        {
           return _repo.DLVerifyStock(productnum,chosen);
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
        public void VerifyCredentials(String name,string password)
        {
            _repo.VerifyCredentials(name,password);
            
        }
        public Customer GetCustomer(string name,string password)
        {
            return _repo.DLGetCustomer(name,password);
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

        public LineItems AddStock(StoreFront id, Products Id, int quantity)
        {
            return _repo.AddStockToDB(id,Id,quantity);
        }

        public bool VerifyProduct(int identification)
        {
            return _repo.VerifyProduct(identification);
        }

        public Products GetProduct(int obj)
        {
            return _repo.GetProduct(obj);
        }

        public List<LineItems> GetInventory(int obj)
        {
           return _repo.GetInventory(obj);
        }

        public StoreFront GetStoreByID(int number)
        {
            return _repo.GetStoreByID(number);
        }

        public bool VerifyStorebyID(int number)
        {
            throw new NotImplementedException();
        }

        public void InsertHistory(int store, int prod, int order, int customer)
        {
            _repo.InsertHistory(store,prod,order,customer);
        }

        public Orders GetOrderByID(Orders obj)
        {
            return _repo.GetOrderID(obj);
        }
    }
}