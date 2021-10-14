using System.Collections.Generic;
using Models;

namespace DataAccessLogic
{
    public interface InterfaceRepository
    {
        /// <summary>
        /// It will add a customer in our database
        /// </summary>
        /// <param name="p_rest">This is the customer we will be adding to the database</param>
        /// <returns>It will just return the customer we are adding</returns>
        Customer AddCustomersDL(Customer p_rest);

        /// <summary>
        /// This will return a list of customers stored in the database
        /// </summary>
        /// <returns>It will return a list of customers</returns>
        List<Customer> GetAllCustomersDL();



        StoreFront AddStoreFrontDL(StoreFront p_rest);
        

        List<StoreFront> GetAllStoreFrontDL();
       
        Products AddProductsDL(Products p_rest);
        
        List<Products> GetAllProductsDL();

        Orders AddOrdersDL(Orders p_rest);
        
        List<Orders> GetAllOrdersDL();
        LineItems AddLineItemsDL(LineItems p_rest);
        
        List<LineItems> GetAllLineItemsDL();




    }
}