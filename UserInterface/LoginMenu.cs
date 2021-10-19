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
        Console.ForegroundColor = ConsoleColor.DarkYellow;
         //Console.BackgroundColor = ConsoleColor.DarkBlue;
            if(Customer.Displayname==null)
            {
               Console.WriteLine("Welcome to the Shopping Menu!");
            Console.WriteLine("Are you a new customer or a Returning customer?");
            Console.WriteLine("[2] - New Customer");
            Console.WriteLine("[1] - Login");
            Console.WriteLine("[0] - Return to main menu"); 

            }
            else
            {
            Console.WriteLine("Welcome to the Shopping Menu!");
            Console.WriteLine("Are you a new customer or a Returning customer?");
            Console.WriteLine("[3] - View stores");
            Console.WriteLine("[2] - New Customer");
            Console.WriteLine("[1] - Login as different user");
            Console.WriteLine("[0] - Return to main menu"); 

            }

            
            
            
      
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
           if(Customer.Displayname==null)
           {
                switch (userChoice)
            {
                case "2":
                
                    return MenuType.AddCustomers;

                case "1":
               Console.ForegroundColor = ConsoleColor.Green;
            
                Console.WriteLine("Enter username");
                Customer.Displayname=Console.ReadLine();
                try
                {
                    List<Customer> listOfCustomers = _restBL.GetAllCustomersBL();

                     _restBL.VerifyCredentials();
                     Console.WriteLine("Welcome Back " + Customer.Displayname + "\n enter to continue");
                     
                     Console.ReadLine();
                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Customer.Displayname=null;
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
                Customer.Displayname=Console.ReadLine();
                


                    return MenuType.LoginMenu;

                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
         

           
        }
        else
        {
             switch (userChoice)
            {
                case "3":
                return MenuType.StoreMenu;

                case "2":
                
                    return MenuType.AddCustomers;

                case "1":
               
            Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Enter username");
                
                Customer.Displayname=Console.ReadLine();

                try
                {
                    List<Customer> listOfCustomers = _restBL.GetAllCustomersBL();
                    
                     _restBL.VerifyCredentials();
                     Console.WriteLine("Welcome Back " + Customer.Displayname + "\n enter to continue");
                     
                     Console.ReadLine();
                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Customer.Displayname="";
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
                Customer.Displayname=Console.ReadLine();
                


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
}