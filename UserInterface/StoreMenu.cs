using System;
using BusinessLogic;
using Models;
using System.Collections.Generic;

namespace UserInterface
{
    public class StoreMenu : IMenu
    {
        private BL _restBL;
        public static List<StoreFront> searchresult;
        public StoreMenu(BL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the store select menu " + Customer.displayName.ToUpper() );
            Console.WriteLine("Please select the store");

            Console.WriteLine("\n\n List of StoreFronts");
            List<StoreFront> listOfStoreFront = _restBL.GetAllStoreFrontsBL();
            Console.ForegroundColor = ConsoleColor.White;
            if(searchresult!= null)
            {
                foreach (StoreFront rest in searchresult)
                        {
                            Console.WriteLine("====================");
                            Console.WriteLine(rest);
                            Console.WriteLine("====================");
                        } 
            }
                else
                {
                foreach (StoreFront rest in listOfStoreFront)
                            {
                                Console.WriteLine("====================");
                                Console.WriteLine(rest);
                                Console.WriteLine("====================");
                            } 
                }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[3] - Search the store (goes to products display");
            Console.WriteLine("[2] - Select the store (goes to products display");
            Console.WriteLine("[1] - go to login");
            Console.WriteLine("[0] - exit to main menu");
      
        }

        public MenuType YourChoice()
        {
            
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "3":
Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Enter store you want to search for");
                string storen=Console.ReadLine();
                List<StoreFront>test=new List<StoreFront>();
                
                try
                {
                
                     foreach(StoreFront s in _restBL.SearchStores(storen))
                    {
                        test.Add(s);

                    }
                    searchresult=test;
                    Console.WriteLine("Press Enter to continue");
                     Console.ReadLine();
                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.White;
        
                    searchresult=null;
                    Console.WriteLine("Store was unfortunately not found please enter name as shown in list above");
                    Console.WriteLine("You will be sent to Store display again ");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.StoreMenu;
                }
                
                
                    return MenuType.StoreMenu;

                case "2":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Enter store you want to enter");
                string storename=Console.ReadLine();
                StoreFront.selectedStore=storename;

                Console.WriteLine("Enter store address you want to enter");
                string storeaddress=Console.ReadLine();
                StoreFront.selectedAddress=storeaddress;
                try
                {

                     _restBL.VerifyStore();
                     Console.WriteLine("Welcome to " + StoreFront.selectedStore + "\n enter to continue");
                     
                     Console.ReadLine();
                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.White;
        
                    StoreFront.selectedStore=null;
                    StoreFront.selectedAddress=null;
                    Console.WriteLine("Store was unfortunately not found please enter name as shown in list above");
                    Console.WriteLine("You will be sent to Store display again ");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.StoreMenu;
                }
                
                
                    return MenuType.ProductDisplayMenu;
                case "1":
                    return MenuType.MainMenu;
                case "0":
                    return MenuType.LoginMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}