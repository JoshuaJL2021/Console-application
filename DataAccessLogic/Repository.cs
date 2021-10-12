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
    
        //Filepath need to reference from the startup project (RRUI) and hence why we need to go back a folder and cd into RRDL
        private const string _filepath = "./../DataAccessLogic/Database/Customers.json";
        private string _jsonString;


        public Customer AddCustomersDL(Customer p_rest)
        {
            //The reason why we need to grab all the information back is because File.WriteAllText method will overwrite anything inside the JSON file
            List<Customer> listOfcustomers = GetAllCustomersDL();

            //We added the new customer from the parameter 
            listOfcustomers.Add(p_rest);

            _jsonString = JsonSerializer.Serialize(listOfcustomers, new JsonSerializerOptions{WriteIndented=true});

            //This is what adds the customer.json
            File.WriteAllText(_filepath,_jsonString);

            //Will return a customer object from the parameter
            return p_rest;
        }


        public List<Customer> GetAllCustomersDL()
        {
            //File class will just read everything in the Resturant.json and put it in a string
            _jsonString = File.ReadAllText(_filepath);

            //Since we are converting from a string to an object that C# understands we need to deserialize the string to object.
            //Json Serializer has a static method called Deserialize and thats why you don't need to instantiate it
            //The parameter of the Deserialize method needs a string variable that holds the json file
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }













/*


        Customer AddCustomerDAL()
{
            Customer ex=new Customer();

            return ex;
        }

public Customer SearchCustomerBL(Customer find)
        {

             Customer ex=new Customer();
            //Class1 search= new Class1();
            return ex;
        }
        public string ViewStoreInventoryDAL(){
            return "string";

        }

         public string PlaceOrderDAL()
         {
            return "string";

        }
         public string ViewOrderHistoryDAL()
         {
            return "string";

        }
        public string ReplenishInventoryDAL()
         {
            return "string";

        }
*/
    }
}
