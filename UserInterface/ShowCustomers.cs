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
     /*        LineItems test=new LineItems();
            List<LineItems>testlist=new List<LineItems>();
            int counter=0;
            LineItems test2=new LineItems();
bool testing=true;
string cancel2;
            while(testing)
            {
                test=new LineItems();
                test._product=_restBL.CreateProduct();
                Console.WriteLine("Enter Amount store has available for "+test._product);
                test._quantity = Convert.ToInt32(Console.ReadLine());
                
                testlist.Add(test); 
                 Console.WriteLine("Would you like to cancel the item?type yes or no\n?");
                cancel2=Console.ReadLine();

             
                    if (cancel2=="yes" || cancel2=="Yes" || cancel2=="YES")
                    {
                        testing=false;
                        }
                        else
                        {

                              testing=true;  ;
                               
                        }
                
                
                
                
            } 
            foreach(LineItems s in testlist)
            {
                Console.WriteLine(s._product);
            } */



            Console.WriteLine("Welcome "+ Customer.displayName);
            Console.WriteLine("Start creating a storefront full screen");
            StoreFront newstore=new StoreFront();
            Console.WriteLine("Enter name of store");
            newstore._name=Console.ReadLine();
            Console.WriteLine("Enter Address of store");
            newstore._address=Console.ReadLine();
            Console.WriteLine("\nnow begin adding items to the stores inventory");
            bool choice=true;
            LineItems storeStock=new LineItems();
            Products item=new Products();
            while(choice)
            {
                storeStock=new LineItems();
                item=_restBL.CreateProduct();
                newstore.productslist.Add(item);
               storeStock._product=item;
               Console.WriteLine("Enter Amount store has available for "+storeStock._product);
                storeStock._quantity = Convert.ToInt32(Console.ReadLine());
           newstore._itemslist.Add(storeStock);
                    string checkout;
                    Console.WriteLine("\nDo you wish to add more items to check out? type yes or no\n");
                    checkout=Console.ReadLine();

             
                    if (checkout=="yes" || checkout=="Yes" || checkout=="YES"){
                        choice=true;
                        }
                        else
                        {

                                choice=false;
                                
                        }

            }
            foreach(LineItems s in newstore._itemslist)
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
            _restBL.AddStoreFrontBL(newstore);












            Console.WriteLine("\nnow begin creating an order");
            foreach(Products p in newstore.productslist)
            {
                Console.WriteLine(p);
            }
            Orders _details=new Orders();
            StoreFront store=_restBL.GetStore(newstore._name);
                            _details._location=store;
                    double total=0;
                    double cost=0.0;
                    int totalitems=0;
                    int selectedamount=0;
                    double payment=0;
                    bool decision=true;
                    do{
                        
                    LineItems _lines=new LineItems();
                   
                    bool loop=true;
                    while(loop==true)
                    {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Enter the name of the product from the store");
                    string productsname=Console.ReadLine();
                    string cancel;
                    try
                    {
                         
                    _lines=_restBL.VerifyStock(productsname,store);
                    loop=false;
                    Console.WriteLine("\nType in the line item quantity you want to buy\n");
                    selectedamount=Convert.ToInt32(Console.ReadLine());
                   // _lines._product=_prods;
                   _lines._quantity=_lines._quantity-selectedamount;
                    _details.itemslist.Add(_lines);
                    }
                    catch (System.Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("please try again you have entered the information wrong");
                        loop=true;
                        Console.WriteLine("Would you like to cancel the item?type yes or no\n?");
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

                   totalitems=totalitems+selectedamount;
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

            foreach (LineItems obj in _details.itemslist)
            {
                Console.WriteLine(obj);
                
                cost=obj._product.PriceGrab();
                payment=(cost * selectedamount);
                
                
                total=total+payment;
                Console.WriteLine("\ntotal cost for the order is: " + total + "for "+ selectedamount+" items");
            selectedamount=0;
                cost=0;
                }
            
            
            
            



                _details._totalprice=total;
                _restBL.AddOrdersBL(_details);
                _details._location.orderslist.Add(_details);
                Console.WriteLine("Receite:");
                Console.WriteLine("Store: "+ _details._location._name + " Address: "+ _details._location._address  );
                foreach (LineItems obj in _details.itemslist)
            {
                Console.WriteLine(obj._product);

            }
                
                Console.WriteLine("Total cost $"+ _details.TotalPrice);
                // newstore.orderslist.Add(_details);
                // StoreFront test=newstore;
                // _restBL.AddStoreFrontBL(test);
                _details._totalprice=0;






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




  












            //List<Customer> listOfCustomers = _restBL.GetAllCustomersBL();

/*             foreach (Customer rest in listOfCustomers)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest._name + "\t" + rest._address + "\t" + rest._contact);
                Console.WriteLine("====================");
                
            }

Console.WriteLine("\n\n List of StoreFronts");
            List<StoreFront> listOfStoreFront = _restBL.GetAllStoreFrontsBL();

            foreach (StoreFront rest in listOfStoreFront)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }
Console.WriteLine("\n\n List of Products");
            List<Products> listOfProduct = _restBL.GetAllProductsBL();

            foreach (Products rest in listOfProduct)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }
            Console.WriteLine("\n\n List of LineItems");
            List<LineItems> listOfLineItem = _restBL.GetAllLineItemsBL();

            foreach (LineItems rest in listOfLineItem)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            }

Console.WriteLine("\n\n List of Orders");
            List<Orders> listOfOrder = _restBL.GetAllOrdersBL();

            foreach (Orders rest in listOfOrder)
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
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