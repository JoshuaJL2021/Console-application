using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;
using System.Security;
using System.Linq;

namespace UserInterface
{
    public class DisplayDBinfo : IMenu
    {
        private InterfaceBL parameterInter;
        public static List<StoreFront> searchresult;
        public DisplayDBinfo(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }
        public void Menu()
        {
            

            //Print all store fr
            List<StoreFront> listOfRestaurants = parameterInter.GetAllStoreFrontsBL();

            foreach (StoreFront rest in listOfRestaurants)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }

            //Print all Customer fr
            List<Customer> listOfCustomer = parameterInter.GetAllCustomersBL();

            foreach (Customer rest in listOfCustomer)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine(rest.Id);
                Console.WriteLine("====================");
            }
            List<Products> listOfProduct = parameterInter.GetAllProductsBL();

            foreach (Products rest in listOfProduct)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("Description: " +rest.Description);
                Console.WriteLine("Category: " +rest.Category);
                Console.WriteLine("====================");
            }
            




            

            


            Console.WriteLine("[x] - Go Back");







        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {


                case "x":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}