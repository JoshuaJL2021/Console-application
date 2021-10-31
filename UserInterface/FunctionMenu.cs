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
            Console.WriteLine("\n##################################################################################\n");
                    
            Console.WriteLine("\tThis is the function Menu");
            Console.WriteLine("\tWhat do you want to do?");

            Console.WriteLine("\t[1] - Go Browsing");
            Console.WriteLine("\t[0] - Exit the store");
            Console.WriteLine("\t[a] - replenish inventory");
            Console.WriteLine("\t[b] - MyProfile");
            Console.WriteLine("\t[c] - add Products");
            Console.WriteLine("\t[d] - add StoreFront");
            Console.WriteLine("\t[e] - show me info");
            Console.WriteLine("\t[f] -test");
            Console.WriteLine("\t[g] -add line item/stock table");
            Console.WriteLine("\t[h] -Show Store Order History");

            Console.WriteLine("\n##################################################################################\n");
                    

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
                case "f":
                    return MenuType.loginconfirm;
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