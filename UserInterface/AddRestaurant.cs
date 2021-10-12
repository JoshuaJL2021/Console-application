using System;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddCustomerMenu : IMenu
    {
        private static Customer _rest = new Customer();
        private InterfaceBL _restBL;
         
        public AddCustomerMenu(InterfaceBL p_restBL)
        {
            _restBL = p_restBL;
        }

        public void Menu()
        {
            Console.WriteLine("Adding a new Restaurant");
            Console.WriteLine("Name - " + _rest._name);
            Console.WriteLine("Address - "+ _rest._address);
            Console.WriteLine("Contact - "+ _rest._contact);
            Console.WriteLine("[4] - Add Customer");
            Console.WriteLine("[3] - Input value for Name");
            Console.WriteLine("[2] - Input value for Address");
            Console.WriteLine("[1] - Input value for contact");
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "4":
                    //Add implementation to talk to the repository method to add a restaurant
                    _restBL.AddCustomersBL(_rest);
                    return MenuType.loginconfirm;
                case "3":
                    Console.WriteLine("Type in the value for the Name");
                    _rest._name = Console.ReadLine();
                    return MenuType.AddRestaurant;
                case "2":
                    Console.WriteLine("Type in the value for the Address");
                    _rest._address = Console.ReadLine();
                    return MenuType.AddRestaurant;
                case "1":
                    Console.WriteLine("Type in the value for the Contact");
                    _rest._contact = Console.ReadLine();
                    return MenuType.AddRestaurant;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowRestaurant;
            }
        }
    }
}