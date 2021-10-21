using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;
using System.Security;
using System.Linq;

namespace UserInterface
{
    public class ShowCustomers : IMenu
    {
        private BL _restBL;
        public ShowCustomers(BL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
            Console.WriteLine("Enter store you want to edit");
            string searchname = Console.ReadLine();
            StoreFront test = _restBL.GetStore(searchname);//verifies it received the store
            Console.WriteLine("Your store is : " + test + "\n ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Your store current Line Products :\n ");
            foreach (LineItems p in test._itemslist)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine("\nCurrent list in file");

            List<StoreFront> listOfstores = _restBL.GetAllStoreFrontsBL();
           // var organized=listOfstores.OrderBy(x => x._name);

            foreach (StoreFront s in listOfstores)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("----------------------------------");
            
            listOfstores.RemoveAll(x => x._name == test._name);//thi
            StoreFront test2 = test;
            Console.WriteLine("\nEnter new address");
            test2._address=Console.ReadLine();

            _restBL.ModifyStoreRecordBL(test2);
            Console.WriteLine("\nCurrent list after remove");
            foreach (StoreFront s in listOfstores)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("----------------------------------");
            List<StoreFront> listOfstoresnew = _restBL.GetAllStoreFrontsBL();
            Console.WriteLine("\nCurrent list from database now");
            foreach (StoreFront s in listOfstoresnew)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("----------------------------------");





            //     Console.WriteLine("Start creating a storefront full screen");
            //     StoreFront newstore=new StoreFront();
            //     Console.WriteLine("Enter name of store");
            //     newstore._name=Console.ReadLine();
            //     Console.WriteLine("Enter Address of store");
            //     newstore._address=Console.ReadLine();
            //     Console.WriteLine("\nnow begin adding items to the stores inventory");
            //     bool choice=true;
            //     LineItems storeStock=new LineItems();
            //     Products item=new Products();
            //     while(choice)
            //     {
            //         storeStock=new LineItems();
            //         item=_restBL.CreateProduct();
            //         newstore.productslist.Add(item);
            //        storeStock._product=item;
            //        Console.WriteLine("Enter Amount store has available for "+storeStock._product);
            //         storeStock._quantity = Convert.ToInt32(Console.ReadLine());
            //    newstore._itemslist.Add(storeStock);
            //             string checkout;
            //             Console.WriteLine("\nDo you wish to add more items to check out? type yes or no\n");
            //             checkout=Console.ReadLine();


            //             if (checkout=="yes" || checkout=="Yes" || checkout=="YES"){
            //                 choice=true;
            //                 }
            //                 else
            //                 {

            //                         choice=false;

            //                 }

            //     }
            //     foreach(LineItems s in newstore._itemslist)
            //     {
            //         Console.WriteLine(s);
            //     }

            //     Console.ReadLine();
            //     _restBL.AddStoreFrontBL(newstore);








            //Console.WriteLine("Enter store you want to edit");
            //         string searchname=Console.ReadLine();
            // StoreFront test=_restBL.GetStore(searchname);//verifies it received the store
            // Console.WriteLine( "Your store is : " + test + "\n ");
            // Console.WriteLine( "----------------------------------");
            // Console.WriteLine( "Your store current products :\n ");
            // foreach(Products p in test.productslist)
            // {
            //     Console.WriteLine(p);
            // }
            // Console.WriteLine( "----------------------------------");
            // Console.WriteLine( "Your store current Line Products :\n ");
            // foreach(LineItems p in test._itemslist)
            // {
            //     Console.WriteLine(p);
            // }

            // Console.WriteLine( "----------------------------------");
            // Console.WriteLine( "Current list in file");
            // //_restBL.ReplaceInformation(StoreFront Store)
            // List<StoreFront> listOfstores = _restBL.GetAllStoreFrontsBL();
            // foreach(StoreFront s in listOfstores)
            // {
            //     Console.WriteLine(s);
            // }
            // Console.WriteLine( "----------------------------------");
            // listOfstores.Remove(test);
            // StoreFront test2=test;
            // Console.WriteLine( "Current list after remove");
            // foreach(StoreFront s in listOfstores)
            // {
            //     Console.WriteLine(s);
            // }
            // Console.WriteLine( "----------------------------------");



            //We added the new storefront from the parameter 
            //listOfstores.Add(p_rest);



            /* Console.WriteLine("Welcome "+ Customer.displayName);

            StoreFront.selectedStore=Console.ReadLine();
            StoreFront test4=_restBL.GetStore(StoreFront.selectedStore);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (LineItems rest in _restBL.ShowStock(test4))
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            } 
            Console.WriteLine("\n\n\n");

Orders _details=new Orders();
            StoreFront store=_restBL.GetStore(StoreFront.selectedStore);
                            _details._location=store;
                    double total=0;
                    double cost=0.0;
                    int selectedamount=0;
                    double payment=0;
                    List<string>cartResult=new List<string>();
                    bool decision=true;
                    do{
                        
                    LineItems _lines=new LineItems();
                   
                    bool loop=true;
                    while(loop==true)
                    {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Enter the name of the product from the store to add to your cart");
                    string productsname=Console.ReadLine();
                    string cancel;
                    try
                    {
                         
                    _lines=_restBL.VerifyStock(productsname,store);
                    loop=false;
                    // Console.WriteLine("\nType in the line item quantity you want to buy\n");
                    // selectedamount=Convert.ToInt32(Console.ReadLine());
                   // _lines._product=_prods;
                   //_lines._quantity=_lines._quantity-selectedamount;
                    _details.itemslist.Add(_lines);
                    }
                    catch (System.Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("please try again you have entered the information wrong");
                        loop=true;
                        Console.WriteLine("Would you like to cancel the item? \ntype yes or no\n?");
                        cancel=Console.ReadLine();

             
                    if (cancel=="yes" || cancel=="Yes" || cancel=="YES")
                    {
                        loop=false;
                        }
                        else
                        {

                              loop=true;  ;
                                
                        }
                    }//end of catch

                    // totalitems=totalitems+selectedamount;
                    }//end of while
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    
            //
            
            
                string checkout;
                    Console.WriteLine("\nDo you wish to add more items to check out? type yes or no\n");
                    checkout=Console.ReadLine();

             
                    if (checkout=="yes" || checkout=="Yes" || checkout=="YES"){
                        decision=true;
                        }
                        else
                        {

                                decision=false;
                                
                        }
                    }while(decision);

            double linecost=0.0;
            foreach (LineItems obj in _details.itemslist)
            {
                Console.WriteLine(obj);
                Console.WriteLine("\nType in the line item quantity you want to buy\n");
                selectedamount=Convert.ToInt32(Console.ReadLine());
                cost=obj._product.PriceGrab();
                payment=(cost * selectedamount);
                linecost=payment;
                
                total=total+payment;
                string temp;
              //  Console.WriteLine("\ntotal cost for the order is: " + total + " for "+ selectedamount+" items");
                temp="\n"+obj._product  + "\t $"+obj._product._price+" selecting "+ selectedamount + " =$"+ linecost;
                cartResult.Add(temp);
                cost=0;
                linecost=0;
                }
            
            
            
            



                _details._totalprice=total;
                _restBL.AddOrdersBL(_details);
                _details._location.orderslist.Add(_details);
                Console.WriteLine("\nReceite:");
                Console.WriteLine("Store: "+ _details._location._name + "\n Address: "+ _details._location._address  );
                foreach(String s in cartResult)
                {
                    Console.WriteLine(s);
                }
            //     foreach (LineItems obj in _details.itemslist)
            // {
            //     Console.WriteLine(obj._product);

            // }
                
                Console.WriteLine("Total cost $"+ _details.TotalPrice);
                _details._totalprice=0;
                _details.itemslist=null;
                
                Console.ReadLine();
           















            List<StoreFront> listOfStoreFront = _restBL.GetAllStoreFrontsBL();

            /* var myLinqQuery =  from store in text
            			   where store.Contains(StoreFront.selectedStore)
            				select store;
                    foreach (string store in myLinqQuery)
            Console.Write(store + "\n "); */


            //adds products to specified store
            /* StoreFront test=_restBL.GetStore(searchname);//verifies it received the store
            Console.Write(test + "\n ");
            test.productslist.Add(_restBL.CreateProduct());
            test.productslist.Add(_restBL.CreateProduct());
            foreach(Products p in test.productslist)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Right new name");

            test._name=Console.ReadLine();;
            _restBL.AddStoreFrontBL(test); */

            /* StoreFront test2=_restBL.GetStore(test._name);
            Console.Write(test2 + "\n ");
            test2.productslist=_restBL.ShowProducts(test); 
            test2.productslist.Add(_restBL.CreateProduct());
            foreach(Products p in test2.productslist)
            {
                Console.WriteLine(p);
            } */







            Console.WriteLine("[x] - Go Back");







        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {


                case "x":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowCustomers;
            }
        }
    }
}