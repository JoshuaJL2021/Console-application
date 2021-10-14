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

        bool VerifyCredentials();

        /// <summary>
        /// Adds a store front to the database
        /// </summary>
        /// <param name="p_rest">This is the store front we are adding</param>
        /// <returns>It returns the added store front</returns>
        StoreFront AddStoreFrontBL(StoreFront p_rest);

        /// <summary>
        /// This will return a list of store fronts stored in the database
        /// It will also capitalize every name of the store front
        /// </summary>
        /// <returns>It will return a list of store fronts</returns>
        List<StoreFront> GetAllStoreFrontsBL();


        /// <summary>
        /// Adds a customer to the product
        /// </summary>
        /// <param name="p_rest">This is the product we are adding</param>
        /// <returns>It returns the product customer</returns>
        Products AddProductsBL(Products p_rest);


        /// <summary>
        /// This will return a list of products stored in the database
        /// It will also capitalize every name of the product
        /// </summary>
        /// <returns>It will return a list of product</returns>
        List<Products> GetAllProductsBL();

        /// <summary>
        /// Adds a customer to the orders
        /// </summary>
        /// <param name="p_rest">This is the product we are adding</param>
        /// <returns>It returns the product customer</returns>     
        Orders AddOrdersBL(Orders p_rest);


        /// <summary>
        /// This will return a list of orders stored in the database
        /// It will also capitalize every name of the product
        /// </summary>
        /// <returns>It will return a list of product</returns>
        List<Orders> GetAllOrdersBL();

        /// <summary>
        /// This will return a list of orders stored in the database
        /// It will also capitalize every name of the product
        /// </summary>
        /// <returns>It will return a list of product</returns>
        LineItems AddLineItemsBL(LineItems p_rest);

        /// <summary>
        /// This will return a list of line items stored in the database
        /// It will also capitalize every name of the product
        /// </summary>
        /// <returns>It will return a list of product</returns>
        List<LineItems> GetAllLineItemsBL();
    }
}
