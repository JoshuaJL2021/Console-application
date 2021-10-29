using System;
using BusinessLogic;
using Models;
using System.Collections.Generic;

namespace UserInterface
{
    public class StoreMenu : IMenu
    {
        private InterfaceBL parameterInter;
        public static List<StoreFront> searchresult;
        public StoreMenu(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the store select menu " + SingletonUser.currentuser._name.ToUpper() );
            Console.WriteLine("Please select the store");

            Console.WriteLine("\n\n List of StoreFronts");
            List<StoreFront> listOfStoreFront = parameterInter.GetAllStoreFrontsBL();
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
            Console.WriteLine("[3] - Search the store ");
            Console.WriteLine("[2] - Select the store (goes to products display");
            Console.WriteLine("[1] - goes to login");
            Console.WriteLine("[0] - exit to Main menu");
      
        }

        public MenuType YourChoice()
        {
            
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "3":

                Console.WriteLine("Enter store you want to search for");
                string storen=Console.ReadLine();
                List<StoreFront>test=new List<StoreFront>();
                
                try
                {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                     foreach(StoreFront s in parameterInter.SearchStores(storen))
                    {
                        test.Add(s);

                    }
                    searchresult=test;
                    Console.WriteLine("Click Enter to see results");
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
                Console.WriteLine("Enter the id number of store you want to enter");
            int num=Convert.ToInt32(Console.ReadLine());
               
                try
                {

                     SingletonUser.currentstore=parameterInter.GetStoreByID(num);
                     Console.WriteLine("Welcome to " + SingletonUser.currentstore._name + "\n enter to continue");
                     
                     Console.ReadLine();
                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    SingletonUser.currentstore=null;
                    Console.WriteLine("Store was unfortunately not found please enter name as shown in list above");
                    Console.WriteLine("You will be sent to Store display again ");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.StoreMenu;
                }
                
                
                    return MenuType.ProductDisplayMenu;
                case "1":
                    return MenuType.LoginMenu;
                case "0":
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