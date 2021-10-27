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
        /// This creates a Product and returns the value 
        /// This method is more for establishing the payment of the order
        /// </summary>
        /// <returns>It will return a  product</returns>
        Products CreateProduct();

        /// <summary>
        /// Verifies in the database if the entered store name and address is located in the database
        /// used for the search and modify store front methods.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true or false </returns>
        bool VerifyStore(string name,string address);

        /// <summary>
        /// Verifies in the database if the entered store name and address is located in the database
        /// and retrieves the found store or an exception
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns the retrieved store information from the db </returns>
        StoreFront GetStore(string name,string address);

        /// <summary>
        /// Verifies in the database if the entered store name and address is located in the database
        /// and retrieves the found store or an exception
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns the retrieved store information from the db </returns>
        List<StoreFront> SearchStores(string name);


        /// <summary>
        /// This method verifies if the stock is in the specified store as well
        /// </summary>
        /// <param name="product"></param>
        /// <param name="chosen"></param>
        /// <returns>returns the line item from the db that matches</returns>
        LineItems VerifyStock(string product, StoreFront chosen);

        /// <summary>
        /// This method receives all the line items from the specified store
        /// </summary>
        /// <param name="chosen"></param>
        /// <returns></returns>
        List<LineItems> ShowStock(StoreFront chosen);

        /// <summary>
        /// this method takes the selected store , erases the previous information from the json file
        /// enters the new information into the json file
        /// also organizes in alphabetical order.
        /// </summary>
        /// <param name="currentSelection"></param>
        /// <returns></returns>
        StoreFront ModifyStoreRecordBL(StoreFront currentSelection);

        /// <summary>
        /// Verifies in the database if the entered client user name is located in the database
        /// used for the search and modify store front methods.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns>verifies if there is an exception </returns>
        void VerifyCredentials(string name,string password);

        /// <summary>
        /// Verifies in the database if the entered information is located in the database
        /// and retrieves the found Customer or an exception
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns>returns the retrieved Customer information from the db </returns>
        Customer GetCustomer(string name,string password);

        /// <summary>
        /// this method takes the Customer  , erases the previous information from the json file
        /// that matches the user information
        /// enters the new information into the json file
        /// also organizes in alphabetical order.
        /// </summary>
        /// <param name="currentSelection"></param>
        /// <returns></returns>

        Customer ModifyCustomerRecord(Customer currentSelection);

        Products AddProductsBL(Products parameterObj);

        List<Products> GetAllProductsBL();
        LineItems AddStock(StoreFront id, Products Id, int quantity);

    }
}