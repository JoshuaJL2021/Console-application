using System;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddStoreFront : IMenu
    {
        private static StoreFront _rest = new StoreFront();
        private static Orders _details = new Orders();

        private InterfaceBL parameterInter;

        public AddStoreFront(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }

        public void Menu()
        {
            Console.WriteLine("\n##################################################################################\n");
                    
            Console.WriteLine("\tAdding a new Store Front");
            Console.WriteLine("\tName of store- " + _rest.Name);
            Console.WriteLine("\tAddress of store - " + _rest.Address);

            Console.WriteLine("order history");
            foreach (Orders obj in _rest.EstablishOrders)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("\t[4] - Add StoreFront");
            Console.WriteLine("\t[3] - Input value for Name");
            Console.WriteLine("\t[2] - Input value for Address");
            Console.WriteLine("\t[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {

                case "4":
                    //Add implementation to talk to the repository method to add a restaurant
                    parameterInter.AddStoreFrontBL(_rest);

                    return MenuType.MainMenu;
                case "3":
                
                    Console.WriteLine("\tType in the value for the Name");
                    _rest.Name = Console.ReadLine();
                    return MenuType.AddStore;
                case "2":
                    Console.WriteLine("\tType in the value for the Address");
                    _rest.Address = Console.ReadLine();
                    return MenuType.AddStore;
               

                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddStore;
            }
        }
    }
}