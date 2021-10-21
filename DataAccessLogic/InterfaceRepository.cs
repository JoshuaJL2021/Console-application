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


        /// <summary>
        /// It will add a store front in our database
        /// </summary>
        /// <param name="p_rest">This is the store front we will be adding to the database</param>
        /// <returns>It will just return the store front we are adding</returns>
        StoreFront AddStoreFrontDL(StoreFront p_rest);
        
        /// <summary>
        /// This will return a list of store front stored in the database
        /// </summary>
        /// <returns>It will return a list of store front</returns>
        List<StoreFront> GetAllStoreFrontDL();
       
       /// <summary>
        /// It will add a store front in our database
        /// </summary>
        /// <param name="p_rest">This is the store front we will be adding to the database</param>
        /// <returns>It will just return the store front we are adding</returns>
        Products AddProductsDL(Products p_rest);
        
        /// <summary>
        /// This will return a list of product stored in the database
        /// </summary>
        /// <returns>It will return a list of product</returns>
        List<Products> GetAllProductsDL();

        /// <summary>
        /// It will add a orders in our database
        /// </summary>
        /// <param name="p_rest">This is the orders we will be adding to the database</param>
        /// <returns>It will just return the orders we are adding</returns>
        Orders AddOrdersDL(Orders p_rest);
        
        /// <summary>
        /// This will return a list of orders stored in the database
        /// </summary>
        /// <returns>It will return a list of orders</returns>
        List<Orders> GetAllOrdersDL();

        /// <summary>
        /// It will add a LineItems in our database
        /// </summary>
        /// <param name="p_rest">This is the lineitems we will be adding to the database</param>
        /// <returns>It will just return the lineitems we are adding</returns>
        LineItems AddLineItemsDL(LineItems p_rest);
        
        /// <summary>
        /// This will return a list of line items stored in the database
        /// </summary>
        /// <returns>It will return a list of line items</returns>
        List<LineItems> GetAllLineItemsDL();

        
        bool DLVerifyStore(string name);

        StoreFront DLGetStore(string name);

        

        List<StoreFront> DLSearchStores(string name);
// List<Products> DLShowProducts(StoreFront chosen);
//         Products DLVerifyProduct(string product,StoreFront chosen);

        LineItems DLVerifyStock(string product,StoreFront chosen);
        List<LineItems> DLShowStock(StoreFront chosen);
        
        StoreFront DLModifyStoreRecord(StoreFront currentSelection);

        Customer DLGetCustomer(string name);

        bool VerifyCredentials(string name);



    }
}