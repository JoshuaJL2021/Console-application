using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ShowCustomers : IMenu
    {
        private BL _restBL;
        public ShowCustomers(BL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
            Console.WriteLine("Welcome "+ Customer.username);
            Console.WriteLine("List of Customers");
            List<Customer> listOfCustomers = _restBL.GetAllCustomersBL();

            foreach (Customer rest in listOfCustomers)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest._name + "\t" + rest._address + "\t" + rest._contact);
                Console.WriteLine("====================");
                
            }

Console.WriteLine("\n\n List of StoreFronts");
            List<StoreFront> listOfStoreFront = _restBL.GetAllStoreFrontsBL();

            foreach (StoreFront rest in listOfStoreFront)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }
Console.WriteLine("\n\n List of Products");
            List<Products> listOfProduct = _restBL.GetAllProductsBL();

            foreach (Products rest in listOfProduct)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }
            Console.WriteLine("\n\n List of LineItems");
            List<LineItems> listOfLineItem = _restBL.GetAllLineItemsBL();

            foreach (LineItems rest in listOfLineItem)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }

Console.WriteLine("\n\n List of Orders");
            List<Orders> listOfOrder = _restBL.GetAllOrdersBL();

            foreach (Orders rest in listOfOrder)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }
            Console.WriteLine("[x] - Go Back");


                



        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {


                case "x":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowCustomers;
            }
        }
    }
}