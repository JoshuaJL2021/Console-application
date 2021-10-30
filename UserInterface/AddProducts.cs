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
            Console.WriteLine("\tAdding a new Product");


            Console.WriteLine("\tName - " + temp.Name);
            Console.WriteLine("\tPrice - " + temp.Price);
            Console.WriteLine("\tDescription - " + temp.Description);
            Console.WriteLine("\tCategory - " + temp.Category);

            Console.WriteLine("\t[5] - Add Product");
            Console.WriteLine("\t[4] - Input value for Name");
            Console.WriteLine("\t[3] - Input value for Price");
            Console.WriteLine("\t[2] - Input value for Description");
            Console.WriteLine("\t[1] - Input value for Category");
            Console.WriteLine("\t[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "5":
                    //Add implementation to talk to the repository method to add a restaurant
                    parameterInter.AddProductsBL(temp);
                    temp=null;
                    return MenuType.MainMenu;
                case "4":
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("\tType in the value for the productName");
                    temp.Name = Console.ReadLine();
                    Console.WriteLine("\n##################################################################################\n");

                    return MenuType.AddProduct;
                case "3":
                    Console.WriteLine("\n##################################################################################\n");

                    Console.WriteLine("\tType in the value for the product");
                    temp.Price = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("\n##################################################################################\n");

                    return MenuType.AddProduct;
                case "2":
                    Console.WriteLine("\n##################################################################################\n");

                    Console.WriteLine("\tType in the value for the Description");
                    temp.Description = Console.ReadLine();
                    Console.WriteLine("\n##################################################################################\n");

                    return MenuType.AddProduct;
                case "1":
                    Console.WriteLine("\n##################################################################################\n");

                    Console.WriteLine("\tType in the value for the Category");
                    temp.Category = Console.ReadLine();
                    Console.WriteLine("\n##################################################################################\n");

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