using System;

namespace BusinessLogic
{
    public class StoreMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Replenish inventory Menu!");
            Console.WriteLine("Please select the item you wish to replenish");
            Console.WriteLine("[2] - toys");
            Console.WriteLine("[1] - bottles");
            Console.WriteLine("[0] - exit");
      
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "2":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.MainMenu;
                case "0":
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