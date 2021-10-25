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
            if(SingletonUser.currentuser==null)
            {
               Console.WriteLine("Welcome to the Shopping Menu!");
               Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Are you a new customer or a Returning customer?");
            Console.WriteLine("[2] - New Customer");
            Console.WriteLine("[1] - Login");
            Console.WriteLine("[0] - Return to main menu"); 

            }
            else
            {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the Shopping Menu!");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("[3] - View stores");
            Console.WriteLine("[2] - New Customer");
            Console.WriteLine("[1] - Login as different user");
            Console.WriteLine("[0] - Return to main menu"); 

            }

            
            
            
      
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
           if(SingletonUser.currentuser==null)
           {
                switch (userChoice)
            {
                case "2":
                
                    return MenuType.AddCustomers;

                case "1":
               Console.ForegroundColor = ConsoleColor.DarkYellow;
        
            
                Console.WriteLine("Enter username");
                string name=Console.ReadLine();
                try
                {

                     SingletonUser.currentuser=_restBL.GetCustomer(name);
                     Console.WriteLine("Welcome Back " + SingletonUser.currentuser._name + "\nenter to continue");
                     
                     Console.ReadLine();
                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.White;
        
                    SingletonUser.currentuser=null;
                    Console.WriteLine("User was unfortunately not found");
                Console.WriteLine("You will be sent to the Login Menu again");
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                    return MenuType.LoginMenu;
                }
                
                
                    return MenuType.StoreMenu;
                case "0":
                    return MenuType.MainMenu;

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
               
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter username");
                
                string name=Console.ReadLine();

                try
                {
                    //List<Customer> listOfCustomers = _restBL.GetAllCustomersBL();
                    
                    SingletonUser.currentuser=_restBL.GetCustomer(name);
                     Console.WriteLine("Welcome Back " + SingletonUser.currentuser._name + "\n enter to continue");
                     
                     Console.ReadLine();
                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    SingletonUser.currentuser=null;
                    Console.WriteLine("User was unfortunately not found");
                Console.WriteLine("You will be sent to the Login Menu again");
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                    return MenuType.LoginMenu;
                }
                
                
                    return MenuType.StoreMenu;
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
}