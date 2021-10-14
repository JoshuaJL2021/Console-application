using System;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddOrders : IMenu
    {
        private static Orders _rest = new Orders();

        private static StoreFront _value=new StoreFront();
        private InterfaceBL _restBL;
         
        public AddOrders(InterfaceBL p_restBL)
        {
            _restBL = p_restBL;
        }

        public void Menu()
        {
            Console.WriteLine("Adding a new Order");
            Console.WriteLine("Location - " + _value._name);
            Console.WriteLine("Location address - " + _value._address);
            Console.WriteLine("Total cost of order - "+ _rest._totalprice);
            Console.WriteLine(_value);
            _rest._location=_value;
            //Console.WriteLine("Contact - "+ _rest._contact);
            Console.WriteLine("[4] - Add Customer");
            Console.WriteLine("[3] - Input value for Name");
            Console.WriteLine("[2] - Input value for Address");
            Console.WriteLine("[1] - Input value for total quantity");
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "4":
                    //Add implementation to talk to the repository method to add a restaurant
                    _restBL.AddOrdersBL(_rest);
                   
                    return MenuType.loginconfirm;
                case "3":
                    Console.WriteLine("Type in the value for the Name");
                    _value._name = Console.ReadLine();
                    return MenuType.AddOrder;
                case "2":
                    Console.WriteLine("Type in the value for the Address");
                    _value._address = Console.ReadLine();
                    return MenuType.AddOrder;
                case "1":
                    Console.WriteLine("Type in the value for the total quantity");
                    _rest._totalprice = Convert.ToDouble(Console.ReadLine());
                    return MenuType.AddOrder;
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