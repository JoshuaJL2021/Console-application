using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class MyProfile : IMenu
    {
        private static Customer _rest = SingletonUser.currentuser;
        private InterfaceBL _restBL;
         
        public MyProfile(InterfaceBL p_restBL)
        {
            _restBL = p_restBL;
        }

        public void Menu()
        {
           
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Editing current user");
            Console.WriteLine("Name - " + SingletonUser.currentuser._name);
            Console.WriteLine("Address - "+ SingletonUser.currentuser._address);
            Console.WriteLine("Contact - "+ SingletonUser.currentuser._contact);
            Console.WriteLine("username - "+ SingletonUser.currentuser._username);
            foreach (Orders i in SingletonUser.currentuser.customerOrders)
            {
                Console.WriteLine(i);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[x] - Save Changes");
            Console.WriteLine("[1] - Change value for Name");
            Console.WriteLine("[2] - Change value for Address");
            Console.WriteLine("[3] - Change value for contact");
            Console.WriteLine("[4] - Change value for age");
            Console.WriteLine("[5] - Change username");
            Console.WriteLine("[6] - Change password");
            Console.WriteLine("[0] - Go Back");




            
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "x":
                    
                    _restBL.ModifyCustomerRecord(SingletonUser.currentuser);
                   
                    return MenuType.LoginMenu;
                case "1":
                    Console.WriteLine("Type in the value for the Name");
                    _rest._name = Console.ReadLine();
                    return MenuType.MyProfile;
                case "2":
                    Console.WriteLine("Type in the value for the Address");
                    _rest._address = Console.ReadLine();
                 
                    return MenuType.MyProfile;
                case "3":
                    Console.WriteLine("Type in the value for the Contact");
                    _rest._contact = Console.ReadLine();
                    return MenuType.MyProfile;
                    case "4":
                    Console.WriteLine("Type in the value for the age");
                    _rest._age = Convert.ToInt32(Console.ReadLine());
                    return MenuType.MyProfile;
                    case "5":
                    Console.WriteLine("Type in the value for the username");
                    _rest._username = Console.ReadLine();
                    return MenuType.MyProfile;
                    case "6":
                    Console.WriteLine("Type in the value for the password");
                    
                    _rest._password = Console.ReadLine();
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