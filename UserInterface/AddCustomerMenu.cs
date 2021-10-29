using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddCustomerMenu : IMenu
    {
        private static Customer client = new Customer();
        private InterfaceBL parameterInter;
         
        public AddCustomerMenu(InterfaceBL parameterBL)
        {
            parameterInter = parameterBL;
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Adding a new Restaurant");
            Console.WriteLine("Name - " + client._name);
            Console.WriteLine("Address - "+ client._address);
            Console.WriteLine("Contact - "+ client._contact);
            Console.WriteLine("username - "+ client._username);
            Console.WriteLine("password - "+ client._password);
            Console.WriteLine("Age - "+ client._age);
            Console.WriteLine("password - "+ client.Position);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[x] - Add Customer");
            Console.WriteLine("[1] - Input value for Name");
            Console.WriteLine("[2] - Input value for Address");
            Console.WriteLine("[3] - Input value for contact");
            Console.WriteLine("[4] - Input value for age");
            Console.WriteLine("[5] - Enter username");
            Console.WriteLine("[6] - Enter password");
            Console.WriteLine("[7] - Enter Position");
            Console.WriteLine("[0] - Go Back");




            
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "x":
                    //Add implementation to talk to the repository method to add a restaurant
                    parameterInter.AddCustomersBL(client);
                   
                    return MenuType.LoginMenu;
                case "1":
                    Console.WriteLine("Type in the value for the Name");
                    client._name = Console.ReadLine();
                    return MenuType.AddCustomers;
                case "2":
                    Console.WriteLine("Type in the value for the Address");
                    client._address = Console.ReadLine();
                    return MenuType.AddCustomers;
                case "3":
                    Console.WriteLine("Type in the value for the Contact");
                    client._contact = Console.ReadLine();
                    return MenuType.AddCustomers;
                    case "4":
                    Console.WriteLine("Type in the value for the age");
                    client._age = Convert.ToInt32(Console.ReadLine());
                    return MenuType.AddCustomers;
                    case "5":
                    Console.WriteLine("Type in the value for the username");
                    client._username = Console.ReadLine();
                    return MenuType.AddCustomers;
                    case "6":
                    Console.WriteLine("Type in the value for the password");
                    
                    client._password = Console.ReadLine();
                    return MenuType.AddCustomers;
                    case "7":
                    Console.WriteLine("Type in the value for the Position");
                    
                    client.Position = Console.ReadLine();
                    return MenuType.AddCustomers;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.LoginMenu;
            }
        }
    }
}