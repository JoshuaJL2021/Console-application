using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ReplenishInventoryMenu : IMenu
    {

        private InterfaceBL parameterInter;

        public ReplenishInventoryMenu(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }

        public void Menu()
        {
            Console.WriteLine("\n##################################################################################\n");

            Console.WriteLine("==========Store Replenish Menu=========");
            Console.WriteLine("\tList of stores");
            List<StoreFront> listOfstores = parameterInter.GetAllStoreFrontsBL();
            foreach (StoreFront s in listOfstores)
            {
                Console.WriteLine("\t\t\t\t" + s);
            }

            Console.WriteLine("Enter the Store Id number you want to see inventory for");
            int num = Convert.ToInt32(Console.ReadLine());
            StoreFront store = parameterInter.GetStoreByID(num);
            Console.WriteLine("\tYour store is : " + store + "\n ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("\tYour store current Line Products :\n ");
            foreach (LineItems p in parameterInter.GetInventory(store.Id))
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("----------------------------------");
            int amount = 0;
            LineItems _lines = new LineItems();
            List<LineItems> mod=new List<LineItems>();
            bool loop = true;
            while (loop == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n##################################################################################\n");
                Console.WriteLine("\tEnter the Id of the product from the store to add stock");
                int productsname = Convert.ToInt32(Console.ReadLine());
                string cancel;
                try
                {

                    _lines = parameterInter.VerifyStock(productsname, store);
                    loop = false;
                    if (mod.Exists(x => x.ProductEstablish.Name == _lines.ProductEstablish.Name))
                    {
                        Console.WriteLine("\tThis item is already in the queue to restock");

                    }
                    else
                    {
                        Console.WriteLine("\n##################################################################################\n");
                        Console.WriteLine("\tEnter the amount of the product you want to add to your inventory");
                        amount = Convert.ToInt32(Console.ReadLine());
                        _lines.Quantity = _lines.Quantity + amount;
                        mod.Add(_lines);

                    }

                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n##################################################################################\n");
                    Console.WriteLine("\tplease try again you have entered the information wrong please enter from the products available");
                    loop = true;
                    Console.WriteLine("\tWould you like to cancel this add? \ttype yes or no\n");
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
                Console.WriteLine("\nDo you wish to add more items to check out? \t type yes or no\n");
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
            foreach (LineItems s in mod)
            {
                parameterInter.ModifyStockTable(store.Id, s.ProductEstablish.Id, s.Quantity);
            }



            Console.WriteLine("\n##################################################################################\n");
            Console.WriteLine("Record has been updated");




            Console.WriteLine("[5] - Main Menu");
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