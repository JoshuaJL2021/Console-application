using System.Collections.Generic;
using Models;

namespace BusinessLogic
{
    public interface InterfaceBL
    {
        /// <summary>
        /// This will return a list of customer stored in the database
        /// It will also capitalize every name of the Customer
        /// </summary>
        /// <returns>It will return a list of Customer</returns>
        List<Customer> GetAllCustomersBL();

        /// <summary>
        /// Adds a customer to the database
        /// </summary>
        /// <param name="p_rest">This is the customer we are adding</param>
        /// <returns>It returns the added customer</returns>
        Customer AddCustomersBL(Customer p_rest);

          /// <summary>
        /// This will return a list of customer stored in the database
        /// It will also capitalize every name of the Customer
        /// </summary>
        /// <returns>It will return a list of Customer</returns>
        StoreFront AddStoreFrontBL(StoreFront p_rest);
        List<StoreFront> GetAllStoreFrontsBL();

        /// <summary>
        /// Adds a customer to the database
        /// </summary>
        /// <param name="p_rest">This is the customer we are adding</param>
        /// <returns>It returns the added customer</returns>
        
Products AddProductsBL(Products p_rest);
        List<Products> GetAllProductsBL();

      
        Orders AddOrdersBL(Orders p_rest);
        List<Orders> GetAllOrdersBL();
 LineItems AddLineItemsBL(LineItems p_rest);
        List<LineItems> GetAllLineItemsBL();
    }
}