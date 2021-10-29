using System;
using BusinessLogic;
using Models;
using System.Collections.Generic;
namespace UserInterface
{
    public class LoginMenu : IMenu
    {
        private InterfaceBL parameterInter;
        public LoginMenu(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("##################################################################################\n");
            if (SingletonUser.currentuser == null)
            {
                Console.WriteLine("\tWelcome to the Shopping Menu!");
                Console.WriteLine("\tPlease Log in or create account?");
                Console.WriteLine("---------------------------------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\t[2] - create account");
                Console.WriteLine("\t[1] - Login");
                Console.WriteLine("\t[0] - Return to main menu");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\tWelcome to the Shopping Menu!");
                Console.WriteLine("---------------------------------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\t[3] - View stores");
                Console.WriteLine("\t[2] - create account");
                Console.WriteLine("\t[1] - Login as different user");
                Console.WriteLine("\t[0] - Return to main menu");

            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n##################################################################################\n");





        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            if (SingletonUser.currentuser == null)
            {
                switch (userChoice)
                {
                    case "2":

                        return MenuType.AddCustomers;

                    case "1":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;


                        Console.WriteLine("\tEnter username");
                        string name = Console.ReadLine();
                        Console.WriteLine("\tEnter Password");
                        string pass = Console.ReadLine();
                        try
                        {

                            SingletonUser.currentuser = parameterInter.GetCustomer(name, pass);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("************************************************\n");
                            Console.WriteLine("\tWelcome Back " + SingletonUser.currentuser._name + "\t press enter to continue\n");
                            Console.WriteLine("************************************************\n");
                            Console.ReadLine();
                        }
                        catch (System.Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.White;

                            SingletonUser.currentuser = null;
                            Console.WriteLine("************************************************\n");
                            Console.WriteLine("User was unfortunately not found");
                            Console.WriteLine("You will be sent to the Login Menu again");
                            Console.WriteLine("Press Enter to continue");
                            Console.WriteLine("\n************************************************\n");
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

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Enter username");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Pass");
                        string pass = Console.ReadLine();

                        try
                        {

                            SingletonUser.currentuser = parameterInter.GetCustomer(name, pass);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("************************************************\n");
                            Console.WriteLine("Welcome Back " + SingletonUser.currentuser._name + "\t press enter to continue\n");
                            Console.WriteLine("************************************************\n");

                            Console.ReadLine();
                        }
                        catch (System.Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            SingletonUser.currentuser = null;
                            Console.WriteLine("************************************************\n");
                            Console.WriteLine("User was unfortunately not found");
                            Console.WriteLine("You will be sent to the Login Menu again");
                            Console.WriteLine("Press Enter to continue");
                            Console.WriteLine("\n************************************************\n");
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