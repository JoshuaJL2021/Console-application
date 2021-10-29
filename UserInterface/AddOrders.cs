using System;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddOrders : IMenu
    {
        private static Orders temp = new Orders();

        private static StoreFront _value=new StoreFront();
        private InterfaceBL parameterInter;
         
        public AddOrders(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }

        public void Menu()
        {
            Console.WriteLine("Adding a new Order");
            Console.WriteLine("Location - " + _value._name);
            Console.WriteLine("Location address - " + _value._address);
            Console.WriteLine("Total cost of order - "+ temp._totalprice);
            Console.WriteLine(_value);
            temp._location=_value;
            foreach (LineItems obj in temp.itemslist)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("[4] - Add Customer");
            Console.WriteLine("[3] - Input value for Name");
            Console.WriteLine("[2] - Input value for Address");
            Console.WriteLine("[1] - Input value for total quantity");
            Console.WriteLine("[11] add to line Item list");
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "4":
                    //Add implementation to talk to the repository method to add a restaurant
                    parameterInter.AddOrdersBL(temp);
                   
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
                    temp._totalprice = Convert.ToDecimal(Console.ReadLine());
                    return MenuType.AddOrder;

                    case "11":
                    LineItems _items=new LineItems();
                    Console.WriteLine("Type in the line item product name");
                    Products _prods=new Products();
                        Console.WriteLine("Type in the line item product name");
                        _prods._name =Console.ReadLine();
                        Console.WriteLine("Type in the line item price");
                        _prods._price=Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Type in the line item quantity");
                    _items._quantity=Convert.ToInt32(Console.ReadLine());

                    temp.itemslist.Add(_items);
                   
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