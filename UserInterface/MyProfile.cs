using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class MyProfile : IMenu
    {
        private static Customer client = SingletonUser.currentuser;
        private InterfaceBL parameterInter;

        public MyProfile(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }

        public void Menu()
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n##################################################################################\n");
            Console.WriteLine("\tEditing current user");
            Console.WriteLine("\tName - " + SingletonUser.currentuser.CustomerName);
            Console.WriteLine("\tAddress - " + SingletonUser.currentuser.Address);
            Console.WriteLine("\tContact - " + SingletonUser.currentuser.Contact);
            Console.WriteLine("\tusername - " + SingletonUser.currentuser.UserName);
            Console.WriteLine("\tAge - " + SingletonUser.currentuser._age);
            Console.WriteLine("\tPosition - " + SingletonUser.currentuser.Position);
            Console.WriteLine("\tAccount number - " + SingletonUser.currentuser.Id);
            Console.WriteLine("\tCurrent Balance: $" + SingletonUser.currentuser.Currency);
            SingletonUser.currentuser.MyOrders = parameterInter.GetMyOrderHistory(SingletonUser.currentuser.Id);

            Console.WriteLine("\n##################################################################################\n");



            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t[x] - Save Changes");
            Console.WriteLine("\t[1] - Change value for Name");
            Console.WriteLine("\t[2] - Change value for Address");
            Console.WriteLine("\t[3] - Change value for contact");
            Console.WriteLine("\t[4] - Change value for age");
            Console.WriteLine("\t[5] - Change username");
            Console.WriteLine("\t[6] - Change password");
            Console.WriteLine("\t[7] - View my Order History");
            Console.WriteLine("\t[8] - Add funds");
            Console.WriteLine("\t[0] - Go Back");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n##################################################################################\n");





        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "x":

                    parameterInter.ModifyCustomerRecord(SingletonUser.currentuser);

                    return MenuType.LoginMenu;
                case "1":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("\tType in the value for the Name");
                    client.CustomerName = Console.ReadLine();
                    return MenuType.MyProfile;
                case "2":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("\tType in the value for the Address");
                    client.Address = Console.ReadLine();

                    return MenuType.MyProfile;
                case "3":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("\tType in the value for the Contact");
                    client.Contact = Console.ReadLine();
                    return MenuType.MyProfile;
                case "4":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("\tType in the value for the age");
                    try
                    {
                        client._age = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("************************************************\n");
                        Console.WriteLine("you have entered something that was not a number please try again");
                        Console.WriteLine("Press Enter to continue");
                        Console.WriteLine("\n************************************************\n");
                        Console.ReadLine();
                    }

                    return MenuType.MyProfile;
                case "5":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("\tType in the value for the username");
                    client.UserName = Console.ReadLine();
                    return MenuType.MyProfile;
                case "6":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("\tType in the value for the password");

                    client.Password = Console.ReadLine();
                    return MenuType.MyProfile;

                case "7":
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (Orders history in SingletonUser.currentuser.MyOrders)
                    {
                        Console.WriteLine("====================");
                        Console.WriteLine("\tOrder Id number: " + history.Id);
                        Console.WriteLine("\tBought from the store: " + history.Location.Name + " located in " + history.Location.Address);
                        Console.WriteLine("\tPurchase the following:");
                        foreach (LineItems s in history.ItemsList)
                        {
                            Console.WriteLine("\t" + s.ProductEstablish.Name);
                        }
                        Console.WriteLine("\tTotal cost of order was: " + history.TotalPrice);
                        Console.WriteLine("====================");
                    }
                    Console.WriteLine("\tpress enter to continue");
                    Console.ReadLine();
                    return MenuType.MyProfile;

                case "8":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("\tType in the value of funds to add");
                    decimal deposit = 0;
                    try
                    {
                        deposit = Convert.ToDecimal(Console.ReadLine());
                        client.Currency = client.Currency + deposit;
                    }
                    catch (System.Exception)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("************************************************\n");
                        Console.WriteLine("you have entered something that was not a number please try again");
                        Console.WriteLine("Press Enter to continue");
                        Console.WriteLine("\n************************************************\n");
                        Console.ReadLine();
                    }

                    return MenuType.MyProfile;

                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MyProfile;
            }
        }
    }
}