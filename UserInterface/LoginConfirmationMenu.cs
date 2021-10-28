using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class LoginConfirmationMenu : IMenu
    {
        private InterfaceBL _restBL;

        public LoginConfirmationMenu(InterfaceBL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
            Console.WriteLine("Enter the Store Id number you want to see inventory for");
            int num=Convert.ToInt32(Console.ReadLine());
            List<LineItems> listOfRestaurants = _restBL.GetInventory(num);

            foreach (LineItems rest in listOfRestaurants)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }







            //checks if product is in db by integer
            // List<Products> listOfRestaurants = _restBL.GetAllProductsBL();

            // foreach (Products rest in listOfRestaurants)
            // {
            //     Console.WriteLine("====================");
            //     Console.WriteLine(rest);
            //     Console.WriteLine("====================");
            // }
            // Console.WriteLine("Enter Product Id");
            // int num = Convert.ToInt32(Console.ReadLine());
            // bool result;
            // try
            // {
            //     Console.ForegroundColor = ConsoleColor.DarkYellow;
            //     result=_restBL.VerifyProduct(num);
            //     Console.WriteLine(result);
            // }
            // catch (System.Exception)
            // {
            //     Console.ForegroundColor = ConsoleColor.White;

                
            //     Console.WriteLine("product was unfortunately not found please enter name as shown in list above");
            //     Console.WriteLine("You will be sent to Store display again ");
            //     Console.WriteLine("Press Enter to continue");
            //     Console.ReadLine();
            // }
            // Console.WriteLine("Enter username");
            //     string name=Console.ReadLine();
            //     Console.WriteLine("Enter Pass");
            //     string pass=Console.ReadLine();
            // Customer test = _restBL.GetCustomer(name,pass);//verifies it received the store
            // Console.WriteLine("Your Name is : " + test + "\n ");
            // Console.WriteLine("age - "+ test._age);
            // Console.WriteLine("position - "+ test.Position);
            // Console.WriteLine("username - "+ test._username);
            // Console.WriteLine("id - "+ test.Id);
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
                    username = Console.ReadLine();
                    Console.WriteLine("enter password");
                    password = Console.ReadLine();
                    //BL bl=new BL();
                    //

                    //insert verification function example:YourChoice(string username,string password);
                    return MenuType.StoreMenu;

                case "1":
                    return MenuType.LoginMenu;
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