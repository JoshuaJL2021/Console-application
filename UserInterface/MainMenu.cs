using System;
using Models;
namespace UserInterface
{
    //The ":" syntax is used to indicate that you will inherit another class, interface, or abstract class
    public class MainMenu : IMenu
    {
        /*
            Since MainMenu has inherited IMenu, it will have all the methods we have created
            in IMenu.
            This is an example of Inheritance, one of the Object Oriented Pillars
        */
        public void Menu()
        {
            Console.WriteLine("Welcome " + Customer.Displayname +" to the Main Menu for Lopez Shopping Center");
            Console.WriteLine("What do you want to do?");

            Console.WriteLine("[1] - Go Browsing");
            Console.WriteLine("[0] - Exit the store");
            Console.WriteLine("[x] - Test Functions");

          

        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "x":
                return MenuType.FunctionMenu;
                case "1":
                    return MenuType.LoginMenu;
                    
                case "0":
                    return MenuType.Exit;
                
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}