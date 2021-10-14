using System;
using Models;
using DataAccessLogic;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class BL :InterfaceBL
    {

        private Repository _repo;
        /// <summary>
        /// We are defining the dependencies this class needs to operate
        /// We do it this way because we can easily switch out which implementation details we will be using
        /// But later on the lecture, we can then switch our RRDL project to point to an actual database in the cloud and we don't have to touch anything else to
        /// have the implementation
        /// </summary>
        /// <param name="p_repo"></param>
        public BL(Repository p_repo)
        {
            _repo = p_repo;
        }

        public Customer AddCustomersBL(Customer p_rest)
        {
            return _repo.AddCustomersDL(p_rest);
        }

        public List<Customer> GetAllCustomersBL()
        {
            return _repo.GetAllCustomersDL();
        }
        public StoreFront AddStoreFrontBL(StoreFront p_rest)
        {
            return _repo.AddStoreFrontDL(p_rest);
        }

        public List<StoreFront> GetAllStoreFrontsBL()
        {
            return _repo.GetAllStoreFrontDL();
            
        }

        public Products AddProductsBL(Products p_rest)
        {
            return _repo.AddProductsDL(p_rest);
        }

        public List<Products> GetAllProductsBL()
        {
           return _repo.GetAllProductsDL();
        }
        public Orders AddOrdersBL(Orders p_rest)
        {
            return _repo.AddOrdersDL(p_rest);
        }

        public List<Orders> GetAllOrdersBL()
        {
           return _repo.GetAllOrdersDL();
        }
public LineItems AddLineItemsBL(LineItems p_rest)
        {
            return _repo.AddLineItemsDL(p_rest);
        }

        public List<LineItems> GetAllLineItemsBL()
        {
           return _repo.GetAllLineItemsDL();
        }

    }
}











/*
        public Customer AddCustomerBL(Customer insert)
        {
            Customer ex=new Customer();
            

            return ex;
        }
        public Customer SearchCustomerBL(Customer find)
        {

             Customer ex=new Customer();
       //     Class1 search= new Class1();
//search.SearchCustomerBL(find);
            return ex;
        }

        public string ViewStoreInventoryBL(){
            return "string";

        }

         public string PlaceOrderBL()
         {
            return "string";

        }
         public string ViewOrderHistoryBL()
         {
            return "string";

        }
        public string ReplenishInventoryBL()
         {
            return "string";

        }

       */

