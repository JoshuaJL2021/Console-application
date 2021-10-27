using System;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddProduct : IMenu
    {
        private static Products _rest = new Products();
        private InterfaceBL _restBL;
         
        public AddProduct(InterfaceBL p_restBL)
        {
            _restBL = p_restBL;
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
             Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Adding a new Product");
             _rest=_restBL.CreateProduct();
            

            Console.WriteLine("Name - " + _rest._name);
            Console.WriteLine("Price - "+ _rest._price);
            Console.WriteLine("Description - "+ _rest.Description);
            Console.WriteLine("Category - "+ _rest.Category);

            Console.WriteLine("[5] - Add Product");
        //    Console.WriteLine("[4] - Input value for Name");
        //     Console.WriteLine("[3] - Input value for Price");
        //     Console.WriteLine("[2] - Input value for Description");
        //      Console.WriteLine("[1] - Input value for Category");
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "5":
                    //Add implementation to talk to the repository method to add a restaurant
                  _restBL.AddProductsBL(_rest);
                   
                   return MenuType.MainMenu;
                case "4":
                    Console.WriteLine("Type in the value for the productName");
                    _rest._name = Console.ReadLine();
                    return MenuType.AddProduct;
                case "3":
                    Console.WriteLine("Type in the value for the product");
                    _rest._price = Convert.ToDecimal(Console.ReadLine());
                    return MenuType.AddProduct;
                 case "2":
                    Console.WriteLine("Type in the value for the Description");
                    _rest.Description = Console.ReadLine();
                    return MenuType.AddProduct;
                     case "1":
                    Console.WriteLine("Type in the value for the Category");
                    _rest.Category = Console.ReadLine();
                    return MenuType.AddProduct;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddProduct;
            }
        }
    }
}