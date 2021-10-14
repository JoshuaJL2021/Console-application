using System;
using BusinessLogic;
using Models;
using System.Collections.Generic;
namespace UserInterface
{
    public class LoginMenu : IMenu
    {
        private BL _restBL;
        public LoginMenu(BL p_restBL)
        {
            _restBL = p_restBL;
        }
    
        public void Menu()
        {
            
            Console.WriteLine("Welcome to the Shopping Menu!");
            Console.WriteLine("Are you a new customer or a Returning customer?");
            Console.WriteLine("[2] - New Customer");
            Console.WriteLine("[1] - Login");
            Console.WriteLine("[0] - Return to main menu");
            
      
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
           // string username;
           // string password;
            //string contactinformation;

            switch (userChoice)
            {
                case "2":
                
                    return MenuType.AddCustomers;

                case "1":
               
            
                Console.WriteLine("Enter username");
                Customer.username=Console.ReadLine();
                try
                {
                     _restBL.VerifyCredentials();
                     Console.WriteLine("Welcome Back " + Customer.username + "\n enter to continue");
                     Console.ReadLine();
                }
                catch (System.Exception)
                {
                    Customer.username="";
                    Console.WriteLine("User was unfortunately not found");
                Console.WriteLine("You will be sent to the Login Menu again");
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                    return MenuType.LoginMenu;
                }
                
                
                    return MenuType.StoreMenu;
                case "0":
                    return MenuType.MainMenu;
                case "x":
                Console.WriteLine("Enter username");
                Customer.username=Console.ReadLine();
                


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