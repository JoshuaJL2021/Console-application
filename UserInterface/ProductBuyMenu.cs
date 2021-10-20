using System;
using BusinessLogic;
using System.Collections.Generic;
using Models;

namespace UserInterface
{
    public class ProductBuyMenu : IMenu
    {
        private static Orders _details=new Orders();
        private BL _restBL;
        public ProductBuyMenu(BL p_restBL)
        {
            _restBL = p_restBL;
        }
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the " + StoreFront.selectedStore + " products menu");
            Console.WriteLine("below is a list of products");

            Console.WriteLine("\n\nList of Products in " + StoreFront.selectedStore);
            StoreFront test=_restBL.GetStore(StoreFront.selectedStore);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Products rest in _restBL.ShowProducts(test))
            {
                Console.WriteLine("====================");
                Console.WriteLine(rest);
                Console.WriteLine("====================");
            } 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[3] - Begin Purchase");
            Console.WriteLine("[2] - texas (goes to products display");
            Console.WriteLine("[1] - canada (goes to order history");
            Console.WriteLine("[0] - exit");
      
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "3":
                StoreFront store=_restBL.GetStore(StoreFront.selectedStore);
                            _details._location=store;
                    double total=0;
                    double cost=0.0;
                    int totalitems=0;
                    double payment=0;
                    bool decision=true;
                    do{
                        
                    LineItems _lines=new LineItems();
                    
                    bool loop=true;
                    Products _prods=new Products();
                    while(loop==true)
                    {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Enter the name of the product from the store");
                    string productsname=Console.ReadLine();
                    string cancel;
                    try
                    {
                         
                    _prods=_restBL.VerifyProduct(productsname,store);
                    loop=false;
                    Console.WriteLine("\nType in the line item quantity\n");
                    _lines._quantity=Convert.ToInt32(Console.ReadLine());
                    _lines._product=_prods;
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
                totalitems=obj.AmountGrab();
                
                cost=obj._product.PriceGrab();
                payment=(cost * totalitems);
                
                totalitems=0;
                cost=0;
                total=total+payment;
                Console.WriteLine("\ntotal cost for the order is: " + total);
            }
            
            
            
            



                _details._totalprice=total;
                _restBL.AddOrdersBL(_details);
                _details._location.orderslist.Add(_details);
                Console.WriteLine("Receite:");
                Console.WriteLine("Store: "+ _details._location._name + " Address: "+ _details._location._address  );
                foreach (LineItems obj in _details.itemslist)
            {
                Console.WriteLine(obj);

            }
                
                Console.WriteLine("Total cost $"+ _details.TotalPrice);
                _details._totalprice=0;
                _details.itemslist=null;
                
                Console.ReadLine();
                return MenuType.ProductBuyMenu;
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