using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;
using System.Security;
using System.Linq;

namespace UserInterface
{
    public class ShowCustomers : IMenu
    {
        private InterfaceBL _restBL;
        public static List<StoreFront> searchresult;
        public ShowCustomers(InterfaceBL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
            //Adds Store to DB
            // Console.WriteLine("Enter StoreName");
            //     string name=Console.ReadLine();
            //     Console.WriteLine("Enter Store Address");
            //     string address=Console.ReadLine();
            //     StoreFront test=new StoreFront();
            //     test._name=name;
            //     test._address=address;
            //     _restBL.AddStoreFrontBL(test);

            //Print all store fr
                List<StoreFront> listOfRestaurants = _restBL.GetAllStoreFrontsBL();

            foreach (StoreFront rest in listOfRestaurants)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine(rest.Id);
                Console.WriteLine("====================");
            }
            /// Search store function
            Console.WriteLine("Enter StoreName");
                string name=Console.ReadLine();
                List<StoreFront>test=new List<StoreFront>();
                
                try
                {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                     foreach(StoreFront s in _restBL.SearchStores(name))
                    {
                        Console.WriteLine(s);
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
                    return MenuType.ShowCustomers;
            }
        }
    }
}