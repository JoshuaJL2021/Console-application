using System;

namespace UserInterface
{
    public class ConfirmPurchaseMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Here is your total purchase:");
            Console.WriteLine("Below is our current list of products");
           /* List<Customer> listOfCustomers = parameterInter.GetAllCustomersBL();

            foreach (Customer rest in listOfCustomers)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest._name + "\t" + rest._address + "\t" + rest._contact);
                Console.WriteLine("====================");
            }*/
            Console.WriteLine("[0] - Go main Menu");
            Console.WriteLine("[2] -go to purchase display");
            Console.WriteLine("[1] - canada (goes to order history");
      
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "2":
                    return MenuType.ConfirmPurchaseMenu;
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