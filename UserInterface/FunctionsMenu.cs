using System;

namespace UserInterface
{
    //The ":" syntax is used to indicate that you will inherit another class, interface, or abstract class
    public class FunctionMenu : IMenu
    {
        /*
            Since MainMenu has inherited IMenu, it will have all the methods we have created
            in IMenu.
            This is an example of Inheritance, one of the Object Oriented Pillars
        */
        public void Menu()
        {
            Console.WriteLine("This is the function Menu");
            Console.WriteLine("What do you want to do?");

            Console.WriteLine("[1] - Go Browsing");
            Console.WriteLine("[0] - Exit the store");
            Console.WriteLine("[a] - replenish inventory");
            Console.WriteLine("[b] - MyProfile");
            Console.WriteLine("[c] add Products");
            Console.WriteLine("[d] add StoreFront");
            Console.WriteLine("[e] - show me info");
            Console.WriteLine("[g] -add line item/stock table");
            Console.WriteLine("[h] -Show Store Order History");

        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    return MenuType.LoginMenu;
                    
                case "0":
                    return MenuType.Exit;
                    case "B":
                case "b":
                    return MenuType.MyProfile;

                case "A":
                case "a":
                    return MenuType.ReplenishMenu;

                    case "c":
                    return MenuType.AddProduct;
    
                    case "d":
                    return MenuType.AddStore;
                    
                    case "e":
                    return MenuType.DisplayDB;
                    case "g":
                    return MenuType.AddLineItem;
                      case "i":
                    return MenuType.ShowCustomers;
                    case "h":
                    return MenuType.ShowStoreOrders;
                
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}