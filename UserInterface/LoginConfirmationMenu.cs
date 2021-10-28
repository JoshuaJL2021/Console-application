using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class LoginConfirmationMenu : IMenu
    {
        private InterfaceBL _restBL;

        public LoginConfirmationMenu(InterfaceBL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
            Orders _details = new Orders();
List<StoreFront> listofstores = _restBL.GetAllStoreFrontsBL();

            foreach (StoreFront rest in listofstores)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }

            Console.WriteLine("Enter the Store Id number you want to see inventory for");
            int num=Convert.ToInt32(Console.ReadLine());
                    StoreFront store = _restBL.GetStoreByID(num);
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
                            List<LineItems> listOfRestaurants = _restBL.GetInventory(num);

            foreach (LineItems rest in listOfRestaurants)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }
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

                                    _details.itemslist.Add(_lines);
                                }

                            }
                            catch (System.Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("please try again you have entered the information wrong");
                                loop = true;
                                Console.WriteLine("Would you like to cancel the item? \ntype yes or no\n?");
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



                        string checkout;
                        Console.WriteLine("\nDo you wish to add more items to check out? \ntype yes or no\n");
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

                    decimal linecost = 0;
                    foreach (LineItems obj in _details.itemslist)
                    {
                        Console.WriteLine(obj);
                        Console.WriteLine("\nType in the line item quantity you want to buy\n");
                        selectedamount = Convert.ToInt32(Console.ReadLine());
                        obj._quantity = obj._quantity - selectedamount;
                        cost = obj._product.PriceGrab();
                        payment = (cost * selectedamount);
                        linecost = payment;

                        total = total + payment;
                        string temp;
                        temp = "\n" + obj._product.Name + "\t$" + obj._product.Price + " selecting " + selectedamount + " = $" + linecost;
                        cartResult.Add(temp);
                        cost = 0;
                        linecost = 0;
                        // SingletonUser.currentstore._itemslist.RemoveAll(x => x._product._name == obj._product._name);
                        // SingletonUser.currentstore._itemslist.Add(obj);
                    }








                    string confirmation;
                    Console.WriteLine("Total of cart is $"+total);
                    Console.WriteLine("Confirm Purchase enter yes or no\nif you enter no you must restart the order");
                    confirmation = Console.ReadLine();
                    if (confirmation == "yes" || confirmation == "Yes" || confirmation == "YES")
                    {
                        Orders Test=new Orders();

                        _details._totalprice = total;

                        _restBL.AddOrdersBL(_details);
                        Test=_restBL.GetOrderByID(Test);
                        Console.WriteLine("Id for order:" +Test.Id);
                        foreach(LineItems s in _details.itemslist)
                        {
                            _restBL.InsertHistory(store.Id,s._product.Id,Test.Id,SingletonUser.currentuser.Id);
                        }
                        
                        
                        //SingletonUser.currentuser.customerOrders.Add(_details);
                        //_restBL.ModifyCustomerRecord(SingletonUser.currentuser);
                        //_restBL.ModifyStoreRecordBL(SingletonUser.currentstore);
                        Console.WriteLine("\nReceite:");
                        Console.WriteLine("Store: " + _details._location._name + "\n Address: " + _details._location._address);
                        foreach (String s in cartResult)
                        {
                            Console.WriteLine(s);
                        }

                        Console.WriteLine("Total cost $" + _details.TotalPrice);

                        Console.ReadLine();
                        
                    }
                    else
                    {
                        _details.itemslist = null;
                        _details._totalprice = 0;
                       
                    }




















            // /// <summary>
            // /// Show list of stores and afterwards get the products from the stock table
            // /// </summary>
            // /// <returns></returns>
            //  List<StoreFront> listofstores = _restBL.GetAllStoreFrontsBL();

            // foreach (StoreFront rest in listofstores)
            // {
            //     Console.WriteLine("====================");
            //     Console.WriteLine(rest);
            //     Console.WriteLine("====================");
            // }

            // Console.WriteLine("Enter the Store Id number you want to see inventory for");
            // int num=Convert.ToInt32(Console.ReadLine());
            // List<LineItems> listOfRestaurants = _restBL.GetInventory(num);

            // foreach (LineItems rest in listOfRestaurants)
            // {
            //     Console.WriteLine("====================");
            //     Console.WriteLine(rest);
            //     Console.WriteLine("====================");
            // }







            //checks if product is in db by integer
            // List<Products> listOfRestaurants = _restBL.GetAllProductsBL();

            // foreach (Products rest in listOfRestaurants)
            // {
            //     Console.WriteLine("====================");
            //     Console.WriteLine(rest);
            //     Console.WriteLine("====================");
            // }
            // Console.WriteLine("Enter Product Id");
            // int num = Convert.ToInt32(Console.ReadLine());
            // bool result;
            // try
            // {
            //     Console.ForegroundColor = ConsoleColor.DarkYellow;
            //     result=_restBL.VerifyProduct(num);
            //     Console.WriteLine(result);
            // }
            // catch (System.Exception)
            // {
            //     Console.ForegroundColor = ConsoleColor.White;

                
            //     Console.WriteLine("product was unfortunately not found please enter name as shown in list above");
            //     Console.WriteLine("You will be sent to Store display again ");
            //     Console.WriteLine("Press Enter to continue");
            //     Console.ReadLine();
            // }
            // Console.WriteLine("Enter username");
            //     string name=Console.ReadLine();
            //     Console.WriteLine("Enter Pass");
            //     string pass=Console.ReadLine();
            // Customer test = _restBL.GetCustomer(name,pass);//verifies it received the store
            // Console.WriteLine("Your Name is : " + test + "\n ");
            // Console.WriteLine("age - "+ test._age);
            // Console.WriteLine("position - "+ test.Position);
            // Console.WriteLine("username - "+ test._username);
            // Console.WriteLine("id - "+ test.Id);
            Console.WriteLine("Congrats it went through");
            Console.WriteLine("[0] - to continue to store selection");


        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            
            switch (userChoice)
            {
                case "2":
                   
                    return MenuType.StoreMenu;

                case "1":
                    return MenuType.LoginMenu;
                case "0":
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