using System;
using BusinessLogic;
using System.Collections.Generic;
using Models;

namespace UserInterface
{
    public class ProductBuyMenu : IMenu
    {
        private static Orders _details = new Orders();
        static List<string> cartResult = new List<string>();
        static List<LineItems> tempdb = new List<LineItems>();
        private InterfaceBL parameterInter;
        public ProductBuyMenu(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            _details.Location = SingletonUser.currentstore;
            Console.WriteLine("##################################################################################\n");
            Console.WriteLine("\tWelcome to the " + SingletonUser.currentstore.Name + " products menu");
            Console.WriteLine("\tBelow is a list of products");
            Console.WriteLine("---------------------------------------------------------------------\n");
            Console.WriteLine("\nList of Products in " + SingletonUser.currentstore.Name);
            StoreFront test = parameterInter.GetStoreByID(SingletonUser.currentstore.Id);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (LineItems rest in parameterInter.GetInventory(SingletonUser.currentstore.Id))
            {
                Console.WriteLine("====================");
                Console.WriteLine("\t" + rest);
                Console.WriteLine("====================");
            }
            Console.WriteLine("\n##################################################################################\n");
            Console.WriteLine("\tAdding to cart");
            foreach (LineItems x in tempdb)
            {
                Console.WriteLine(x.ProductEstablish.Name);

            }

            Console.WriteLine("---------------------------------------------------------------\n");
            Console.WriteLine("\tCheckout cart");
            foreach (LineItems x in _details.ItemsList)
            {
                Console.WriteLine(x);

            }
            Console.WriteLine("\tTotal of cart is $" + _details.TotalPrice);
            Console.WriteLine("Current Balance in wallet: $" + SingletonUser.currentuser.Currency);

            Console.WriteLine("\n##################################################################################\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t[5] - Add Items to cart");
            Console.WriteLine("\t[4] - remove items from cart");
            Console.WriteLine("\t[3] - Modify/calculate total of order");
            Console.WriteLine("\t[2] - confirm");
            Console.WriteLine("\t[1] - back");

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
                                if (_lines.Quantity > 0)
                                {
                                    if (tempdb.Exists(x => x.ProductEstablish.Name == _lines.ProductEstablish.Name))
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
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.WriteLine("\n************************************************\n");
                                    Console.WriteLine("\tItem cannot be added because it is out of stock");
                                    Console.WriteLine("\n************************************************\n");
                                    Console.ReadLine();
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


                    return MenuType.ProductBuyMenu;


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
                                if (tempdb.Exists(x => x.ProductEstablish.Name == _lines.ProductEstablish.Name))
                                {

                                    tempdb.RemoveAll(x => x.ProductEstablish.Name == _lines.ProductEstablish.Name);
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

                    return MenuType.ProductBuyMenu;

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




                    _details.ItemsList.Clear();

                    foreach (LineItems obj in tempdb)
                    {
                        original.Add(obj);

                        LineItems filler = new LineItems();

                        filler.ProductEstablish = obj.ProductEstablish;

                        Console.WriteLine(obj);
                        Console.WriteLine("\n\tType in the line item quantity you want to buy\n");
                        selectedamount = Convert.ToInt32(Console.ReadLine());
                        obj.Quantity = obj.Quantity - selectedamount;
                        filler.Quantity = selectedamount;
                        cost = obj.ProductEstablish.PriceGrab();
                        payment = (cost * selectedamount);
                        linecost = payment;

                        total = total + payment;
                        string temp;
                        temp = "\n\t" + obj.ProductEstablish.Name + "======$" + obj.ProductEstablish.Price + "=========selecting " + selectedamount + " = $" + linecost;
                        cartResult.Add(temp);
                        cost = 0;
                        linecost = 0;
                        _details.ItemsList.Add(filler);

                    }
                    total = decimal.Round(total, 2, MidpointRounding.AwayFromZero);
                    _details.TotalPrice = total;
                    Console.WriteLine("\tTotal of cart is $" + total);
                    List<LineItems> values = _details.ItemsList;
                    for (int i = 0; i < _details.ItemsList.Count; i++)
                    {
                        tempdb[i].Quantity = tempdb[i].Quantity + values[i].Quantity;

                    }
                    Console.ReadLine();
                    return MenuType.ProductBuyMenu;


                case "2":
                    string confirmation;
                    Console.WriteLine("\tConfirm Purchase enter yes or no\n\tif you enter no you must restart the order");
                    confirmation = Console.ReadLine();
                    if (confirmation == "yes" || confirmation == "Yes" || confirmation == "YES")
                    {
                        if (_details.TotalPrice == 0)
                        {
                            Console.WriteLine("\tError there is nothing in your cart, you must calculate the price before ordering");
                            Console.WriteLine("\tthe page and order will be reset. press enter to continue");
                            Console.ReadLine();
                            _details.ItemsList.Clear();
                            tempdb.Clear();
                            _details.TotalPrice = 0;
                            return MenuType.ProductBuyMenu;

                        }
                        else if ((SingletonUser.currentuser.Currency - _details.TotalPrice) >= 0)
                        {
                            SingletonUser.currentuser.Currency = SingletonUser.currentuser.Currency - _details.TotalPrice;
                            parameterInter.ModifyCustomerRecord(SingletonUser.currentuser);

                            Orders Test = new Orders();

                            parameterInter.AddOrdersBL(_details, SingletonUser.currentstore, SingletonUser.currentuser);
                            Test = parameterInter.GetOrderByID(Test);
                            List<LineItems> valuesfinal = _details.ItemsList;
                            for (int i = 0; i < _details.ItemsList.Count; i++)
                            {
                                tempdb[i].Quantity = tempdb[i].Quantity - valuesfinal[i].Quantity;

                            }

                            foreach (LineItems s in tempdb)
                            {
                                parameterInter.ModifyStockTable(SingletonUser.currentstore.Id, s.ProductEstablish.Id, s.Quantity);
                            }
                            foreach (LineItems s in _details.ItemsList)
                            {
                                parameterInter.InsertHistory(SingletonUser.currentstore.Id, s.ProductEstablish.Id, Test.Id, SingletonUser.currentuser.Id, s.Quantity);

                            }


                            Console.WriteLine("\nReceite:");
                            Console.WriteLine("\tStore: " + _details.Location.Name + "\n\t Address: " + _details.Location.Address);
                            foreach (string s in cartResult)
                            {
                                Console.WriteLine(s);
                            }

                            Console.WriteLine("\tTotal cost $" + _details.TotalPrice);
                            Console.WriteLine("\n##################################################################################\n");
                            _details.ItemsList.Clear();
                            tempdb.Clear();
                            _details.TotalPrice = 0;
                            Console.ReadLine();
                            return MenuType.ProductBuyMenu;
                        }
                        else
                        {
                            Console.WriteLine("\t We are sorry you currently dont have the sufficiente funds to complete the purchase.");
                            Console.WriteLine("\t You will need to modify your cart by selecting the option.\tPress enter to continue");
                            Console.ReadLine();
                            _details.ItemsList.Clear();
                            _details.TotalPrice = 0;
                            return MenuType.ProductBuyMenu;

                        }
                    }
                    else
                    {
                        _details.ItemsList.Clear();
                        tempdb.Clear();
                        _details.TotalPrice = 0;
                        Console.WriteLine("Order has been canceled because you did not enter yes press enter to continue");
                        Console.ReadLine();
                        return MenuType.ProductBuyMenu;
                    }


                case "1":
                    tempdb.Clear();
                    _details.ItemsList.Clear();
                    _details.TotalPrice=0;

                    return MenuType.ProductDisplayMenu;
                case "0":
                    tempdb.Clear();
                    _details.ItemsList.Clear();
                    _details.TotalPrice=0;
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ProductBuyMenu;
            }
        }
    }
}