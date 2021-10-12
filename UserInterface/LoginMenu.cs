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
            Console.WriteLine("[2] - I am a new user");
            Console.WriteLine("[1] - I am a returning customer");
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
                //create
               /* Console.WriteLine("enter Full Name");
                username=Console.ReadLine();
                Console.WriteLine("enter Address");
                password=Console.ReadLine();
                Console.WriteLine("enter contact information");
                contactinformation=Console.ReadLine();*/
              //  BL bl=new BL();
              //  Customer newCustomer=new Customer(username,password,contactinformation);

              //  bl.AddCustomerBL(newCustomer);
         

                //insert verification function example:YourChoice(string username,string password);
                    return MenuType.AddCustomers;

                case "1":
                //verify if account
                /*Console.WriteLine("enter username");
                username=Console.ReadLine();
                Console.WriteLine("enter Address");
                password=Console.ReadLine();
                Customer user=new Customer(username,password,"");*/
               // BL bl2=new BL();
                //bl2.SearchCustomerBL(user);

                    return MenuType.ShowCustomers;
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