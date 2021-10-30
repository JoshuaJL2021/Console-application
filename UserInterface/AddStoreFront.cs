using System;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddStoreFront : IMenu
    {
        private static StoreFront _rest = new StoreFront();
        
        private InterfaceBL parameterInter;
         
        public AddStoreFront(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }

        public void Menu()
        {
            Console.WriteLine("Adding a new Store Front");
            Console.WriteLine("Name of store- " + _rest._name);
            Console.WriteLine("Address of store - "+ _rest._address);
            Console.WriteLine("order history");
            foreach (Orders obj in _rest.orderslist)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("[4] - Add StoreFront");
            Console.WriteLine("[3] - Input value for Name");
            Console.WriteLine("[2] - Input value for Address");
            Console.WriteLine("[0] - Go Back");
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
                    Console.WriteLine("Type in the value for the Name");
                    _rest._name = Console.ReadLine();
                    return MenuType.AddStore;
                case "2":
                    Console.WriteLine("Type in the value for the Address");
                    _rest._address = Console.ReadLine();
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