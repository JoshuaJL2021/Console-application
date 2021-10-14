using System;
using BusinessLogic;
using Models;
namespace UserInterface
{
    public class LoginMenu : IMenu
    {
        
    
        public void Menu()
        {
            Console.WriteLine("Welcome to the Shopping Menu!");
            Console.WriteLine("Are you a new customer or a Returning customer?");
            Console.WriteLine("[2] - add user");
            Console.WriteLine("[1] - show me info");
            Console.WriteLine("[0] - Return to main menu");
            Console.WriteLine("[x] - Returning User");
            Console.WriteLine(Customer.username);
      
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
                //create
         

                //insert verification function example:YourChoice(string username,string password);
                    return MenuType.AddCustomers;

                case "1":
                //verify if account

                    return MenuType.ShowCustomers;
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