using System;
using BusinessLogic;
using System.Collections.Generic;
using Models;

namespace UserInterface
{
    public class ProductBuyMenu : IMenu
    {
        private static Orders _details = new Orders();
        private InterfaceBL parameterInter;
        public ProductBuyMenu(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("##################################################################################\n");
            Console.WriteLine("\tWelcome to the " + SingletonUser.currentstore._name + " products menu");
            Console.WriteLine("\tBelow is a list of products");
            Console.WriteLine("---------------------------------------------------------------------\n");
            Console.WriteLine("\nList of Products in " + SingletonUser.currentstore._name);
            StoreFront test = parameterInter.GetStoreByID(SingletonUser.currentstore.Id);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (LineItems rest in parameterInter.GetInventory(SingletonUser.currentstore.Id))
            {
                Console.WriteLine("====================");
                Console.WriteLine("\t" + rest._product);
                Console.WriteLine("====================");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t[3] - Begin Purchase");
            Console.WriteLine("\t[2] - goes to products display");
            Console.WriteLine("\t[1] - goes to exit");
            Console.WriteLine("\t[0] - goes to login");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("\n##################################################################################\n");

        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "3":
                    Orders _details = new Orders();
                    StoreFront store = parameterInter.GetStoreByID(SingletonUser.currentstore.Id);
                    _details._location = store;
                    decimal total = 0;
                    decimal cost = 0;
                    int selectedamount = 0;
                    decimal payment = 0;
                    List<string> cartResult = new List<string>();
                    bool decision = true;
                    do
                    {

                        LineItems _lines = new LineItems();

                        bool loop = true;
                        while (loop == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;

                            Console.WriteLine("##################################################################################\n");
                            Console.WriteLine("\tEnter the Id of the product from the store to add to your cart");
                            int productsname = Convert.ToInt32(Console.ReadLine());
                            string cancel;
                            try
                            {

                                _lines = parameterInter.VerifyStock(productsname, store);
                                loop = false;
                                if (_details.itemslist.Exists(x => x._product._name == _lines._product._name))
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\n************************************************\n");
                                    Console.WriteLine("\tThis item is already in the cart");
                                    Console.WriteLine("\n************************************************\n");

                                }
                                else
                                {

                                    _details.itemslist.Add(_lines);
                                }

                            }
                            catch (System.Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n************************************************\n");
                                Console.WriteLine("\tplease try again you have entered the information wrong");
                                loop = true;
                                Console.WriteLine("\tWould you like to cancel the item? \n\ttype yes or no?\n");
                                Console.WriteLine("\n************************************************\n");
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
                        }//end of while
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n##################################################################################\n");



                        string checkout;
                        Console.WriteLine("\tDo you wish to add more items to check out? \n\ttype yes or no\n");
                        checkout = Console.ReadLine();


                        if (checkout == "yes" || checkout == "Yes" || checkout == "YES")
                        {
                            decision = true;
                        }
                        else
                        {

                            decision = false;

                        }
                    } while (decision);
                    Console.WriteLine("\n##################################################################################\n");

                    decimal linecost = 0;
                    foreach (LineItems obj in _details.itemslist)
                    {

                        Console.WriteLine(obj);
                        Console.WriteLine("\n\tType in the line item quantity you want to buy\n");
                        selectedamount = Convert.ToInt32(Console.ReadLine());
                        obj._quantity = obj._quantity - selectedamount;
                        cost = obj._product.PriceGrab();
                        payment = (cost * selectedamount);
                        linecost = payment;

                        total = total + payment;
                        string temp;
                        temp = "\n\t" + obj._product.Name + "======$" + obj._product.Price + "=========selecting " + selectedamount + " = $" + linecost;
                        cartResult.Add(temp);
                        cost = 0;
                        linecost = 0;
                    }






                    Console.WriteLine("\n##################################################################################\n");


                    string confirmation;
                    total = decimal.Round(total, 2, MidpointRounding.AwayFromZero);
                    Console.WriteLine("\tTotal of cart is $" + total);
                    Console.WriteLine("\tConfirm Purchase enter yes or no\n\tif you enter no you must restart the order");
                    confirmation = Console.ReadLine();
                    if (confirmation == "yes" || confirmation == "Yes" || confirmation == "YES")
                    {
                        Orders Test = new Orders();
                        _details._totalprice = total;

                        parameterInter.AddOrdersBL(_details);
                        Test = parameterInter.GetOrderByID(Test);
                        foreach (LineItems s in _details.itemslist)
                        {
                            parameterInter.InsertHistory(store.Id, s._product.Id, Test.Id, SingletonUser.currentuser.Id);
                            parameterInter.ModifyStockTable(store.Id, s._product.Id, s._quantity);
                        }
                        Console.WriteLine("\nReceite:");
                        Console.WriteLine("\tStore: " + _details._location._name + "\n\t Address: " + _details._location._address);
                        foreach (String s in cartResult)
                        {
                            Console.WriteLine(s);
                        }

                        Console.WriteLine("\tTotal cost $" + _details.TotalPrice);
                        Console.WriteLine("\n##################################################################################\n");

                        Console.ReadLine();
                        return MenuType.ProductBuyMenu;
                    }
                    else
                    {
                        _details.itemslist = null;
                        _details._totalprice = 0;
                        return MenuType.ProductBuyMenu;
                    }

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