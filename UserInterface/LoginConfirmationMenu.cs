using System;
using BusinessLogic;
namespace UserInterface
{
    public class LoginConfirmationMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Congrats it went through");
           Console.WriteLine("[0] - to continue to store selection");
            
      
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            string username;
            string password;
            switch (userChoice)
            {
                case "2":
                //verify credentials
                Console.WriteLine("enter username");
                username=Console.ReadLine();
                Console.WriteLine("enter password");
                password=Console.ReadLine();
                //BL bl=new BL();
                //

                //insert verification function example:YourChoice(string username,string password);
                    return MenuType.MainMenu;
                    
                case "1":
                    return MenuType.LoginMenu;
                case "0":
                    return MenuType.StoreMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}