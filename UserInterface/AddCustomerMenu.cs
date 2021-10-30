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
            Console.WriteLine("##################################################################################\n");
            Console.WriteLine("Adding a new Account");
            Console.WriteLine("---------------------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Name - " + client.CustomerName);
            Console.WriteLine("Address - " + client.Address);
            Console.WriteLine("Contact - " + client.Contact);
            Console.WriteLine("username - " + client.UserName);
            Console.WriteLine("password - " + client.Password);
            Console.WriteLine("Age - " + client._age);
            Console.WriteLine("Type: - " + client.Position);
            Console.WriteLine("Added Balance: - $" + client.Currency);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\n##################################################################################\n");
            Console.WriteLine("\t[x] - Add Customer");
            Console.WriteLine("\t[1] - Input value for Name");
            Console.WriteLine("\t[2] - Input value for Address");
            Console.WriteLine("\t[3] - Input value for contact");
            Console.WriteLine("\t[4] - Input value for age");
            Console.WriteLine("\t[5] - Enter username");
            Console.WriteLine("\t[6] - Enter password");
            Console.WriteLine("\t[7] - Enter Type");
            Console.WriteLine("\t[8] - Enter Currency");
            Console.WriteLine("\t[0] - Go Back");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n##################################################################################\n");





        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "x":
                    //Add implementation to talk to the repository method to add a restaurant
                    parameterInter.AddCustomersBL(client);
                    Console.WriteLine("\tAccount created");
                    Console.WriteLine("\tPress enter to continue");

                    return MenuType.LoginMenu;
                case "1":
                    Console.WriteLine("\tType in the value for the Name");
                    client.CustomerName = Console.ReadLine();
                    Console.WriteLine("\n##################################################################################\n");
                    return MenuType.AddCustomers;
                case "2":
                    Console.WriteLine("\tType in the value for the Address");
                    client.Address = Console.ReadLine();
                    Console.WriteLine("\n##################################################################################\n");
                    return MenuType.AddCustomers;
                case "3":
                    Console.WriteLine("\tType in the value for the Contact");
                    client.Contact = Console.ReadLine();
                    Console.WriteLine("\n##################################################################################\n");
                    return MenuType.AddCustomers;
                case "4":
                    Console.WriteLine("\tType in the value for the age");
                    client._age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n##################################################################################\n");
                    return MenuType.AddCustomers;
                case "5":
                    Console.WriteLine("\tType in the value for the username");
                    client.UserName = Console.ReadLine();
                    Console.WriteLine("\n##################################################################################\n");
                    return MenuType.AddCustomers;
                case "6":
                    Console.WriteLine("\tType in the value for the password");
                    client.Password = Console.ReadLine();
                    Console.WriteLine("\n##################################################################################\n");
                    return MenuType.AddCustomers;
                case "7":
                    Console.WriteLine("\tType in the value for the Position");
                    client.Position = Console.ReadLine();
                    Console.WriteLine("\n##################################################################################\n");
                    return MenuType.AddCustomers;

                    case "8":
                    Console.WriteLine("\tType in the value for the Currency");
                    client.Currency = Convert.ToDecimal(Console.ReadLine());
                    return MenuType.AddCustomers;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddCustomers;
            }
        }
    }
}