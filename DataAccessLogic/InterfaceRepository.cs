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
        Orders AddOrdersDL(Orders p_rest);

        /// <summary>
        /// This will return a list of orders stored in the database
        /// </summary>
        /// <returns>It will return a list of orders</returns>
        List<Orders> GetAllOrdersDL();


        /// <summary>
        /// Verifies in the database if the entered store name and address is located in the database
        /// used for the search and modify store front methods.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true or false </returns>
        bool DLVerifyStore(string name,string address);
        /// <summary>
        /// Verifies in the database if the entered store name and address is located in the database
        /// and retrieves the found store or an exception
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns the retrieved store information from the db </returns>
        StoreFront DLGetStore(string name,string address);
        /// <summary>
        /// Verifies in the database if the entered store name and address is located in the database
        /// and retrieves the found store or an exception
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns the retrieved store information from the db </returns>
        List<StoreFront> DLSearchStores(string name);
        /// <summary>
        /// This method verifies if the stock is in the specified store as well
        /// </summary>
        /// <param name="product"></param>
        /// <param name="chosen"></param>
        /// <returns>returns the line item from the db that matches</returns>
        LineItems DLVerifyStock(int productnum, StoreFront chosen);
        /// <summary>
        /// This method receives all the line items from the specified store
        /// </summary>
        /// <param name="chosen"></param>
        /// <returns></returns>
        List<LineItems> DLShowStock(StoreFront chosen);

        /// <summary>
        /// this method takes the selected store , erases the previous information from the json file
        /// enters the new information into the json file
        /// also organizes in alphabetical order.
        /// </summary>
        /// <param name="currentSelection"></param>
        /// <returns></returns>
        StoreFront DLModifyStoreRecord(StoreFront currentSelection);
        /// <summary>
        /// Verifies in the database if the entered client user name is located in the database
        /// used for the search and modify Customer front methods.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns true or false </returns>
        bool VerifyCredentials(string name,string password);
        /// <summary>
        /// Verifies in the database if the entered information is located in the database
        /// and retrieves the found store or an exception
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns the retrieved Customer information from the db </returns>
        Customer DLGetCustomer(string name,string password);

        /// <summary>
        /// this method takes the Customer  , erases the previous information from the json file
        /// that matches the user information
        /// enters the new information into the json file
        /// also organizes in alphabetical order.
        /// </summary>
        /// <param name="currentSelection"></param>
        /// <returns></returns>
        Customer DLModifyCustomerRecord(Customer currentSelection);

        LineItems AddStockToDB(StoreFront store, Products prod, int quantity);

        List<Products> GetAllProductsDL();

         Products AddProductsDL(Products parameterObj);

         bool VerifyProduct(int identification);
         Products GetProduct(int obj);

         List<LineItems> GetInventory(int obj);
         StoreFront GetStoreByID(int number);
          bool VerifyStorebyID(int number);

          void InsertHistory(int store, int prod, int order, int customer);
        Orders GetOrderID(Orders obj);
         void ModifyStockTable(int storenumber, int productnumber,int quantity);
    }
}