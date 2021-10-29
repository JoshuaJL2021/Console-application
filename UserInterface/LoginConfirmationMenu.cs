using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class LoginConfirmationMenu : IMenu
    {
        private static Orders _details = new Orders();
        static decimal total;
        decimal cost;
        int selectedamount;
        decimal payment;
        decimal linecost;
        List<string> cartResult = new List<string>();
        private InterfaceBL parameterInter;

        public LoginConfirmationMenu(InterfaceBL parameterobj)
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

            Console.WriteLine("\n##################################################################################\n");
            Console.WriteLine("Currently in cart");
            foreach (LineItems x in _details.itemslist)
            {
                Console.WriteLine(x);

            }
            Console.WriteLine("\tTotal of cart is $" + _details.TotalPrice);
            Console.WriteLine("\n##################################################################################\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t[6] - Add Items to cart");
            Console.WriteLine("\t[5] - Modify items from cart");
            Console.WriteLine("\t[4] - remove items from cart");
            Console.WriteLine("\t[3] - calculate total of order");
            Console.WriteLine("\t[2] - goes to exit");
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
                case "6":
                    StoreFront store = parameterInter.GetStoreByID(SingletonUser.currentstore.Id);
                    _details._location = store;
                    total = 0;
                    cost = 0;
                    selectedamount = 0;
                    payment = 0;
                    List<string> cartResult = new List<string>();
                    List<LineItems> temper = new List<LineItems>();
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
                                    Console.ReadLine();

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



                        decision = false;

                    } while (decision);


                    return MenuType.loginconfirm;




                case "5":
                    total = 0;
                    cost = 0;
                    selectedamount = 0;
                    payment = 0;
                    cartResult = new List<string>();
                    List<LineItems> temper2 = new List<LineItems>();
                    bool decision2 = true;
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

                                _lines = parameterInter.VerifyStock(productsname, SingletonUser.currentstore);
                                if (_details.ItemsList.Exists(x => x._product._name == _lines._product._name))
                                {

                                    _details.ItemsList.RemoveAll(x => x._product._name == _lines._product._name);

                                }
                                loop = false;
                                temper2.Add(_lines);
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



                        decision2 = false;
                    } while (decision2);

                    Console.WriteLine("\n##################################################################################\n");

                    linecost = 0;
                    total = 0;

                    foreach (LineItems x in temper2)
                    {
                        _details.itemslist.Add(x);
                    }
                    return MenuType.loginconfirm;

                case "4":
                    total = 0;
                    cost = 0;
                    selectedamount = 0;
                    payment = 0;
                    cartResult = new List<string>();
                    List<LineItems> temper3 = new List<LineItems>();
                    bool decision3 = true;
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

                                _lines = parameterInter.VerifyStock(productsname, SingletonUser.currentstore);
                                if (_details.ItemsList.Exists(x => x._product._name == _lines._product._name))
                                {

                                    _details.ItemsList.RemoveAll(x => x._product._name == _lines._product._name);

                                }
                                loop = false;
                                temper3.Add(_lines);
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



                        decision3 = false;
                    } while (decision3);

                    Console.WriteLine("\n##################################################################################\n");

                    return MenuType.loginconfirm;

                case "3":
                    total = 0;
                    cost = 0;
                    selectedamount = 0;
                    payment = 0;
                    cartResult = new List<string>();

                    Console.WriteLine("\n##################################################################################\n");

                    linecost = 0;


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
                    total = decimal.Round(total, 2, MidpointRounding.AwayFromZero);
                    _details._totalprice = total;
                    Console.WriteLine("\tTotal of cart is $" + total);
                    return MenuType.loginconfirm;


                case "2":
                    string confirmation;
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
                            parameterInter.InsertHistory(SingletonUser.currentstore.Id, s._product.Id, Test.Id, SingletonUser.currentuser.Id);
                            parameterInter.ModifyStockTable(SingletonUser.currentstore.Id, s._product.Id, s._quantity);
                        }
                        Console.WriteLine("\nReceite:");
                        Console.WriteLine("\tStore: " + _details._location._name + "\n\t Address: " + _details._location._address);
                        // foreach (String s in cartResult)
                        // {
                        //     Console.WriteLine(s);
                        // }

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