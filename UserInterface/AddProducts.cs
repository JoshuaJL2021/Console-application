using System;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddProduct : IMenu
    {
        private static Products temp = new Products();
        private InterfaceBL parameterInter;

        public AddProduct(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Adding a new Product");


            Console.WriteLine("Name - " + temp._name);
            Console.WriteLine("Price - " + temp._price);
            Console.WriteLine("Description - " + temp.Description);
            Console.WriteLine("Category - " + temp.Category);

            Console.WriteLine("[5] - Add Product");
            Console.WriteLine("[4] - Input value for Name");
            Console.WriteLine("[3] - Input value for Price");
            Console.WriteLine("[2] - Input value for Description");
            Console.WriteLine("[1] - Input value for Category");
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "5":
                    //Add implementation to talk to the repository method to add a restaurant
                    parameterInter.AddProductsBL(temp);

                    return MenuType.MainMenu;
                case "4":
                    Console.WriteLine("Type in the value for the productName");
                    temp._name = Console.ReadLine();
                    return MenuType.AddProduct;
                case "3":
                    Console.WriteLine("Type in the value for the product");
                    temp._price = Convert.ToDecimal(Console.ReadLine());
                    return MenuType.AddProduct;
                case "2":
                    Console.WriteLine("Type in the value for the Description");
                    temp.Description = Console.ReadLine();
                    return MenuType.AddProduct;
                case "1":
                    Console.WriteLine("Type in the value for the Category");
                    temp.Category = Console.ReadLine();
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