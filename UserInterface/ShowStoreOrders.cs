using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ShowStoreOrders : IMenu
    {
        private static Customer _rest = SingletonUser.currentuser;
        private InterfaceBL parameterInter;
         
        public ShowStoreOrders(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }

        public void Menu()
        {
           Console.WriteLine("Enter the Store Id number you want to see inventory for");
            int num=Convert.ToInt32(Console.ReadLine());

            List<Orders> listOfRestaurants = parameterInter.GetStoreOrderHistory(num);
  

            foreach (Orders rest in listOfRestaurants)
            {
                Console.WriteLine("====================");
                Console.WriteLine("Order Id number: "+ rest.Id);
                Console.WriteLine("Bought from the store: "+ rest.Location.Name+ " located in " + rest.Location.Address);
                Console.WriteLine("Purchase the following:");
                foreach(LineItems s in rest.ItemsList)
                {
                    Console.WriteLine(s.ProductEstablish.Name);
                }
                Console.WriteLine("Total cost of order was: "+rest.TotalPrice);
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