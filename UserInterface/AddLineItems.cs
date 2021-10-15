using System;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddLineItem : IMenu
    {
        private static LineItems _rest = new LineItems();
        private InterfaceBL _restBL;
         
        public AddLineItem(InterfaceBL p_restBL)
        {
            _restBL = p_restBL;
        }

        public void Menu()
        {
            Console.WriteLine("Adding a new LineItem");
            Console.WriteLine("products Name - " + _rest._product);
            Console.WriteLine("products quantity - "+ _rest._quantity);
            
            Console.WriteLine("[4] - Add LineItem");
            Console.WriteLine("[3] - Input value for products name");
            Console.WriteLine("[2] - Input value for products quantity");
            Console.WriteLine("[0] - Go Back");
            Console.WriteLine(_rest.ToString());
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "4":
                    //Add implementation to talk to the repository method to add a restaurant
                    _restBL.AddLineItemsBL(_rest);
                   
                    return MenuType.loginconfirm;
                case "3":
                    
                    Products _prods=new Products();
                        Console.WriteLine("Type in the line item product name");
                        _prods._name =Console.ReadLine();
                        Console.WriteLine("Type in the line item price");
                        _prods._price=Convert.ToDouble(Console.ReadLine());
                    return MenuType.AddLineItem;
                case "2":
                    Console.WriteLine("Type in the value for the quantity");
                    _rest._quantity = Convert.ToInt32(Console.ReadLine());
                    return MenuType.AddLineItem;
                case "1":
                    //Console.WriteLine("Type in the value for the Contact");
                    //_rest._contact = Console.ReadLine();
                    return MenuType.AddCustomers;
                case "0":
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