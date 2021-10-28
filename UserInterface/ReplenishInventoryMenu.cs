using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ReplenishInventoryMenu : IMenu
    {
        private Orders _details = new Orders();

        private InterfaceBL _restBL;

        public ReplenishInventoryMenu(InterfaceBL p_restBL)
        {
            _restBL = p_restBL;
        }

        public void Menu()
        {

            Console.WriteLine("==========Store Replenish Menu=========");
            Console.WriteLine("List of stores");
            List<StoreFront> listOfstores = _restBL.GetAllStoreFrontsBL();
            foreach (StoreFront s in listOfstores)
            {
                Console.WriteLine("\t\t\t\t" + s);
            }

            Console.WriteLine("Enter the Store Id number you want to see inventory for");
            int num = Convert.ToInt32(Console.ReadLine());
            StoreFront store = _restBL.GetStoreByID(num);
            Console.WriteLine("Your store is : " + store + "\n ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Your store current Line Products :\n ");
            foreach (LineItems p in _restBL.GetInventory(store.Id))
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("----------------------------------");
            int amount = 0;
            LineItems _lines = new LineItems();
            LineItems current = new LineItems();
            bool loop = true;
            while (loop == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Enter the Id of the product from the store to add to your cart");
                int productsname = Convert.ToInt32(Console.ReadLine());
                string cancel;
                try
                {

                    _lines = _restBL.VerifyStock(productsname, store);
                    loop = false;
                    if (_details.itemslist.Exists(x => x._product._name == _lines._product._name))
                    {
                        Console.WriteLine("This item is already in the cart");

                    }
                    else
                    {
                        Console.WriteLine("Enter the amount of the product you want to add to your inventory");
                        amount = Convert.ToInt32(Console.ReadLine());
                        _lines._quantity = _lines._quantity + amount;
                        _details.itemslist.Add(_lines);

                    }

                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("please try again you have entered the information wrong");
                    loop = true;
                    Console.WriteLine("Would you like to not try again \ntype yes or no\n?");
                    cancel = Console.ReadLine();


                    if (cancel == "yes" || cancel == "Yes" || cancel == "YES")
                    {
                        loop = false;
                    }
                    else
                    {

                        loop = true; ;

                    }
                }//end of catch

                string checkout;
                Console.WriteLine("\nDo you wish to add more items to check out? \ntype yes or no\n");
                checkout = Console.ReadLine();


                if (checkout == "yes" || checkout == "Yes" || checkout == "YES")
                {
                    loop = true;
                }
                else
                {

                    loop = false;

                }
            }//end of while
            foreach (LineItems s in _details.itemslist)
            {
                _restBL.ModifyStockTable(store.Id, s._product.Id, s._quantity);
            }




            Console.WriteLine("Record has been updated");




            Console.WriteLine("[5] - Main Menu");


            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "5":

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