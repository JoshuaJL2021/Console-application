using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ReplenishInventoryMenu : IMenu
    {
        private static StoreFront _rest = new StoreFront();
        private static Orders _details = new Orders();

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

            Console.WriteLine("Enter store you want to edit");
            string searchname = Console.ReadLine();
            Console.WriteLine("Enter store address you want to edit");
            string ad = Console.ReadLine();
            StoreFront test = _restBL.GetStore(searchname,ad);//verifies it received the store
            Console.WriteLine("Your store is : " + test + "\n ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Your store current Line Products :\n ");
            foreach (LineItems p in test._itemslist)
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
                Console.WriteLine("Enter the name of the product from the store to edit your inventory");
                string productsname = Console.ReadLine();
                string cancel;
                try
                {

                    //_lines = _restBL.VerifyStock(productsname, test);
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
                        listOfstores.RemoveAll(x => x._name == test._name);
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
                test._itemslist.RemoveAll(x => x._product._name == s._product._name);
                test._itemslist.Add(s);
            }

            foreach (LineItems s in test._itemslist)
            {
                Console.WriteLine(s);

            }

            _restBL.ModifyStoreRecordBL(test);


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