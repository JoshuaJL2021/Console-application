using System;
using BusinessLogic;

namespace UserInterface
{
    public class ProductMenuDisplay : IMenu
    {
        private BL _restBL;
        public ProductMenuDisplay(BL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
            Console.WriteLine("Welcome to the store select menu");
            Console.WriteLine("Please select the store");

            /* List<Customer> listOfCustomers = _restBL.GetAllCustomersBL();

            foreach (Customer rest in listOfCustomers)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest._name + "\t" + rest._address + "\t" + rest._contact);
                Console.WriteLine("====================");
            }*/
            Console.WriteLine("[3] - add store (goes to products display");
            Console.WriteLine("[2] - texas (goes to products display");
            Console.WriteLine("[1] - canada (goes to order history");
            Console.WriteLine("[0] - exit");
      
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "2":
                    return MenuType.ProductDisplayMenu;
                case "1":
                    return MenuType.MainMenu;
                case "0":
                    return MenuType.LoginMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}