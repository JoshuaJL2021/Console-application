using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace DataAccessLogic
{
    public class Repository : InterfaceRepository
    {
    //The repository class has a bunch of methods that we will use to get or store information from the database
    //Does not actually hold the data itself
    
        //Filepath need to reference , this format locates this specific folder in the project
        private const string _filepath = "./../DataAccessLogic/Database/";
        private string _jsonString;

        /// <summary>
        /// Add customer method which begins with receiving the whole list in the db into the created list.
        /// adds the received parameter into the list at the end.
        /// then stores the file into the designated path with the json extension hardcoded in
        /// </summary>
        /// <param name="p_rest"></param>
        /// <returns></returns>
        public Customer AddCustomersDL(Customer p_rest)
        {
            //The reason why we need to grab all the information back is because File.WriteAllText method will overwrite anything inside the JSON file
            List<Customer> listOfcustomers = GetAllCustomersDL();

            //We added the new customer from the parameter 
            listOfcustomers.Add(p_rest);
            //formats the list to the indented format.
            // serialize formats and converts the list into a json formatted string.
            _jsonString = JsonSerializer.Serialize(listOfcustomers, new JsonSerializerOptions{WriteIndented=true});

            //This is what adds the customer.json
            //adds the entire list containing the previous and new customers.
            File.WriteAllText((_filepath+"Customers.json"),_jsonString);

            //Will return a customer object from the parameter
            return p_rest;
        }


        public List<Customer> GetAllCustomersDL()
        {
            //File class will just read everything in the Resturant.json and put it in a string
            _jsonString = File.ReadAllText(_filepath+"Customers.json");

            //Since we are converting from a string to an object that C# understands we need to deserialize the string to object.
            //Json Serializer has a static method called Deserialize and thats why you don't need to instantiate it
            //The parameter of the Deserialize method needs a string variable that holds the json file
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }


        /// <summary>
        /// Add storefront method which begins with receiving the whole list in the db into the created list.
        /// adds the received parameter into the list at the end.
        /// then stores the file into the designated path with the json extension hardcoded in
        /// </summary>
        /// <param name="p_rest"></param>
        /// <returns></returns>
            public StoreFront AddStoreFrontDL(StoreFront p_rest)
        {
             //The reason why we need to grab all the information back is because File.WriteAllText method will overwrite anything inside the JSON file
            List<StoreFront> listOfstores = GetAllStoreFrontDL();

            //We added the new storefront from the parameter 
            listOfstores.Add(p_rest);

            _jsonString = JsonSerializer.Serialize(listOfstores, new JsonSerializerOptions{WriteIndented=true});

            //This is what adds the stores.json
            File.WriteAllText(_filepath+"Stores.json",_jsonString);

            //Will return a customer object from the parameter
            return p_rest;
        }

        public List<StoreFront> GetAllStoreFrontDL()
        {
             _jsonString = File.ReadAllText(_filepath+"Stores.json");

            //Since we are converting from a string to an object that C# understands we need to deserialize the string to object.
            //Json Serializer has a static method called Deserialize and thats why you don't need to instantiate it
            //The parameter of the Deserialize method needs a string variable that holds the json file
            return JsonSerializer.Deserialize<List<StoreFront>>(_jsonString);
        }

            /// <summary>
            /// Add products method which begins with receiving the whole list in the db into the created list.
            /// adds the received parameter into the list at the end.
            /// then stores the file into the designated path with the json extension hardcoded in
            /// </summary>
            /// <param name="p_rest"></param>
            /// <returns></returns>
            public Products AddProductsDL(Products p_rest)
        {
             //The reason why we need to grab all the information back is because File.WriteAllText method will overwrite anything inside the JSON file
            List<Products> listOfProducts = GetAllProductsDL();

            //We added the new Products from the parameter 
            listOfProducts.Add(p_rest);

            _jsonString = JsonSerializer.Serialize(listOfProducts, new JsonSerializerOptions{WriteIndented=true});

            //This is what adds the Products.json
            File.WriteAllText(_filepath+"Products.json",_jsonString);

            //Will return a Products object from the parameter
            return p_rest;
        }

        public List<Products> GetAllProductsDL()
        {
             _jsonString = File.ReadAllText(_filepath+"Products.json");

            //Since we are converting from a string to an object that C# understands we need to deserialize the string to object.
            //Json Serializer has a static method called Deserialize and thats why you don't need to instantiate it
            //The parameter of the Deserialize method needs a string variable that holds the json file
            return JsonSerializer.Deserialize<List<Products>>(_jsonString);
        }

        /// <summary>
        /// Add orders method which begins with receiving the whole list in the db into the created list.
        /// adds the received parameter into the list at the end.
        /// then stores the file into the designated path with the json extension hardcoded in
        /// </summary>
        /// <param name="p_rest"></param>
        /// <returns></returns>
        public Orders AddOrdersDL(Orders p_rest)
        {
             //The reason why we need to grab all the information back is because File.WriteAllText method will overwrite anything inside the JSON file
            List<Orders> listOfOrders = GetAllOrdersDL();

            //We added the new Orders from the parameter 
            listOfOrders.Add(p_rest);

            _jsonString = JsonSerializer.Serialize(listOfOrders, new JsonSerializerOptions{WriteIndented=true});

            //This is what adds the Orders.json
            File.WriteAllText(_filepath+"Orders.json",_jsonString);

            //Will return a Orders object from the parameter
            return p_rest;
        }

        public List<Orders> GetAllOrdersDL()
        {
             _jsonString = File.ReadAllText(_filepath+"Orders.json");

            //Since we are converting from a string to an object that C# understands we need to deserialize the string to object.
            //Json Serializer has a static method called Deserialize and thats why you don't need to instantiate it
            //The parameter of the Deserialize method needs a string variable that holds the json file
            return JsonSerializer.Deserialize<List<Orders>>(_jsonString);
        }
            /// <summary>
            /// Add line items method which begins with receiving the whole list in the db into the created list.
            /// adds the received parameter into the list at the end.
            /// then stores the file into the designated path with the json extension hardcoded in
            /// </summary>
            /// <param name="p_rest"></param>
            /// <returns></returns>
        public LineItems AddLineItemsDL(LineItems p_rest)
        {
             //The reason why we need to grab all the information back is because File.WriteAllText method will overwrite anything inside the JSON file
            List<LineItems> listOfLineItems = GetAllLineItemsDL();

            //We added the new LineItems from the parameter 
            listOfLineItems.Add(p_rest);

            _jsonString = JsonSerializer.Serialize(listOfLineItems, new JsonSerializerOptions{WriteIndented=true});

            //This is what adds the LineItems.json
            File.WriteAllText(_filepath+"LineItems.json",_jsonString);

            //Will return a LineItems object from the parameter
            return p_rest;
        }

        public List<LineItems> GetAllLineItemsDL()
        {
             _jsonString = File.ReadAllText(_filepath+"LineItems.json");

            //Since we are converting from a string to an object that C# understands we need to deserialize the string to object.
            //Json Serializer has a static method called Deserialize and thats why you don't need to instantiate it
            //The parameter of the Deserialize method needs a string variable that holds the json file
            return JsonSerializer.Deserialize<List<LineItems>>(_jsonString);
        }









    }
}
