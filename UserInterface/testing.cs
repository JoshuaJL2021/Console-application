using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class LoginConfirmationMenu : IMenu
    {
        private static Orders _details = new Orders();


        static List<string> cartResult = new List<string>();
        static List<LineItems> tempdb = new List<LineItems>();


        private InterfaceBL parameterInter;

        public LoginConfirmationMenu(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            _details.Location = SingletonUser.currentstore;
            Console.WriteLine("##################################################################################\n");
            Console.WriteLine("\tWelcome to the " + SingletonUser.currentstore._name + " products menu");
            Console.WriteLine("\tBelow is a list of products");
            Console.WriteLine("---------------------------------------------------------------------\n");
            Console.WriteLine("\nList of Products in " + SingletonUser.currentstore._name);
            StoreFront test = parameterInter.GetStoreByID(SingletonUser.currentstore.Id);
            Console.ForegroundColor = ConsoleColor.White;
            // foreach (LineItems rest in parameterInter.GetInventory(SingletonUser.currentstore.Id))
            // {
            //     Console.WriteLine("====================");
            //     Console.WriteLine("\t" + rest._product);
            //     Console.WriteLine("====================");
            // }

            Console.WriteLine("\n##################################################################################\n");
            Console.WriteLine("Currently in cart");
            foreach (LineItems x in _details.itemslist)
            {
                Console.WriteLine(x);

            }
            Console.WriteLine("\tTotal of cart is $" + _details.TotalPrice);
            Console.WriteLine("Information headed to db tables");
            foreach (LineItems x in tempdb)
            {
                Console.WriteLine(x);

            }

            Console.WriteLine("\tTotal of cart is $" + _details.TotalPrice);
            Console.WriteLine("\n##################################################################################\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t[5] - Add Items to cart");
            Console.WriteLine("\t[4] - remove items from cart");
            Console.WriteLine("\t[3] - Modify/calculate total of order");
            Console.WriteLine("\t[2] - confirm");
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
                case "5":

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

                                _lines = parameterInter.VerifyStock(productsname, SingletonUser.currentstore);
                                loop = false;

                                if (tempdb.Exists(x => x._product._name == _lines._product._name))
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\n************************************************\n");
                                    Console.WriteLine("\tThis item is already in the cart");
                                    Console.WriteLine("\n************************************************\n");
                                    Console.ReadLine();

                                }
                                else
                                {

                                    tempdb.Add(_lines);
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


                case "4":

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
                                if (tempdb.Exists(x => x._product._name == _lines._product._name))
                                {

                                    tempdb.RemoveAll(x => x._product._name == _lines._product._name);
                                    // _details.itemslist.RemoveAll(x => x._product._name == _lines._product._name);

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
                    decimal cost = 0;
                    int selectedamount = 0;
                    decimal payment = 0;
                    decimal linecost = 0;
                    decimal total = 0;

                    Console.WriteLine("\n##################################################################################\n");

                    linecost = 0;
                    List<LineItems> original = new List<LineItems>();
                    cartResult.Clear();




                    _details.itemslist.Clear();

                    foreach (LineItems obj in tempdb)
                    {
                        original.Add(obj);

                        LineItems filler = new LineItems();

                        filler._product = obj._product;

                        Console.WriteLine(obj);
                        Console.WriteLine("\n\tType in the line item quantity you want to buy\n");
                        selectedamount = Convert.ToInt32(Console.ReadLine());
                        obj._quantity = obj._quantity - selectedamount;
                        filler._quantity = selectedamount;
                        cost = obj._product.PriceGrab();
                        payment = (cost * selectedamount);
                        linecost = payment;

                        total = total + payment;
                        string temp;
                        temp = "\n\t" + obj._product.Name + "======$" + obj._product.Price + "=========selecting " + selectedamount + " = $" + linecost;
                        cartResult.Add(temp);
                        cost = 0;
                        linecost = 0;
                        _details.itemslist.Add(filler);

                    }
                    total = decimal.Round(total, 2, MidpointRounding.AwayFromZero);
                    _details._totalprice = total;
                    Console.WriteLine("\tTotal of cart is $" + total);
                    List<LineItems> values = _details.itemslist;
                    for (int i = 0; i < _details.itemslist.Count; i++)
                    {
                        tempdb[i]._quantity = tempdb[i]._quantity + values[i]._quantity;

                    }
                    Console.ReadLine();
                    return MenuType.loginconfirm;


                case "2":
                    string confirmation;
                    Console.WriteLine("\tConfirm Purchase enter yes or no\n\tif you enter no you must restart the order");
                    confirmation = Console.ReadLine();
                    if (confirmation == "yes" || confirmation == "Yes" || confirmation == "YES")
                    {
                        Orders Test = new Orders();

                        parameterInter.AddOrdersBL(_details, SingletonUser.currentstore, SingletonUser.currentuser);
                        Test = parameterInter.GetOrderByID(Test);
                        List<LineItems> valuesfinal = _details.itemslist;
                        for (int i = 0; i < _details.itemslist.Count; i++)
                        {
                            tempdb[i]._quantity = tempdb[i]._quantity - valuesfinal[i]._quantity;

                        }

                        foreach (LineItems s in tempdb)
                        {
                            parameterInter.InsertHistory(SingletonUser.currentstore.Id, s._product.Id, Test.Id, SingletonUser.currentuser.Id, s._quantity);
                            parameterInter.ModifyStockTable(SingletonUser.currentstore.Id, s._product.Id, s._quantity);
                        }
                        Console.WriteLine("\nReceite:");
                        Console.WriteLine("\tStore: " + _details._location._name + "\n\t Address: " + _details._location._address);
                        foreach (string s in cartResult)
                        {
                            Console.WriteLine(s);
                        }

                        Console.WriteLine("\tTotal cost $" + _details.TotalPrice);
                        Console.WriteLine("\n##################################################################################\n");

                        Console.ReadLine();
                        _details.itemslist.Clear();
                        tempdb.Clear();
                        _details._totalprice = 0;
                        return MenuType.loginconfirm;
                    }
                    else
                    {
                        _details.itemslist = null;
                        _details._totalprice = 0;
                        return MenuType.loginconfirm;
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