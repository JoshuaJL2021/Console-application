using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ShowStoreOrders : IMenu
    {
        private static Customer _rest = SingletonUser.currentuser;
        private InterfaceBL _restBL;
         
        public ShowStoreOrders(InterfaceBL p_restBL)
        {
            _restBL = p_restBL;
        }

        public void Menu()
        {
           Console.WriteLine("Enter the Store Id number you want to see inventory for");
            int num=Convert.ToInt32(Console.ReadLine());

            List<Orders> listOfRestaurants = _restBL.GetMyOrderHistory(num);
  

            foreach (Orders rest in listOfRestaurants)
            {
                Console.WriteLine("====================");
                Console.WriteLine("Order Id number: "+ rest.Id);
                Console.WriteLine("Bought from the store: "+ rest._location.Name+ " located in " + rest._location.Address);
                Console.WriteLine("Purchase the following:");
                foreach(LineItems s in rest.itemslist)
                {
                    Console.WriteLine(s._product._name);
                }
                Console.WriteLine("Total cost of order was: "+rest._totalprice);
                Console.WriteLine("====================");
            }
            Console.WriteLine("[0] - Go Back");




            
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
               
                    
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MyProfile;
            }
        }
    }
}