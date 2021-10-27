using System;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddStoreFront : IMenu
    {
        private static StoreFront _rest = new StoreFront();
        private static Orders _details=new Orders();
        
        private InterfaceBL _restBL;
         
        public AddStoreFront(InterfaceBL p_restBL)
        {
            _restBL = p_restBL;
        }

        public void Menu()
        {
            Console.WriteLine("Adding a new Store Front");
            Console.WriteLine("Name of store- " + _rest._name);
            Console.WriteLine("Address of store - "+ _rest._address);
          /*  double cost=0.0;
            Console.WriteLine("Available products");
            foreach (Products obj in _rest.productslist)
            {
                Console.WriteLine(obj);
                cost=cost+obj.PriceGrab();
            }
            Console.WriteLine("total cost for the order is: "+cost);
*/

            Console.WriteLine("order history");
            foreach (Orders obj in _rest.orderslist)
            {
                Console.WriteLine(obj);
            }

            //Console.WriteLine("[5] - Submit with receite");
            Console.WriteLine("[4] - Add StoreFront");
            Console.WriteLine("[3] - Input value for Name");
            Console.WriteLine("[2] - Input value for Address");
//Console.WriteLine("[11] - input products for list");
Console.WriteLine("[12] - input orders for list");
           
            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "5":
                StoreFront store=_restBL.GetStore(_rest._name,_rest._address);
                            _details._location=store;
                    decimal total=0;
                    Decimal cost=0;
                    int totalitems=0;
                    Decimal payment=0;
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
                     _lines=_restBL.VerifyStock(productsname,store);    
                    //_prods=_restBL.VerifyProduct(productsname,store);
                    loop=false;
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
                    }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nType in the line item quantity\n");
                    _lines._quantity=Convert.ToInt32(Console.ReadLine());
                    _lines._product=_prods;


                    _details.itemslist.Add(_lines);
                    
            //
            foreach (LineItems obj in _details.itemslist)
            {
                Console.WriteLine(obj);
                totalitems=obj.AmountGrab();
                cost=obj._product.PriceGrab();
                payment=(cost * totalitems);
                totalitems=0;
                cost=0;

            }
            
            total=total+payment;
            Console.WriteLine("\ntotal cost for the order is: " + total);
            
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
                Console.ReadLine();
                return MenuType.MainMenu;

                case "4":
                    //Add implementation to talk to the repository method to add a restaurant
                    _restBL.AddStoreFrontBL(_rest);
                   
                    return MenuType.MainMenu;
                case "3":
                    Console.WriteLine("Type in the value for the Name");
                    _rest._name = Console.ReadLine();
                    return MenuType.AddStore;
                case "2":
                    Console.WriteLine("Type in the value for the Address");
                    _rest._address = Console.ReadLine();
                    return MenuType.AddStore;
             /*case "11":
                    Products _items=new Products();
                    Console.WriteLine("Type in the line item product name");
                    _items._name =Console.ReadLine();
                    Console.WriteLine("Type in the line item price");
                    _items._price=Convert.ToDouble(Console.ReadLine());
                    _rest.productslist.Add(_items);
                    return MenuType.AddStore;*/

                   /* case "12":
                    Orders _details=new Orders();
                            StoreFront store=new StoreFront();
                            store._name=_rest._name;
                            store._address=_rest._address;
                            _details._location=store;
                    double total=0;
                    double cost=0.0;
                    int totalitems=0;
                    double payment=0;
                    bool decision=true;
                    do{
                        
                    LineItems _lines=new LineItems();

                    Products _prods=_restBL.CreateProduct();
                     _rest.productslist.Add(_prods);
                       

                    Console.WriteLine("\nType in the line item quantity\n");
                    _lines._quantity=Convert.ToInt32(Console.ReadLine());
                    _lines._product=_prods;


                    _details.itemslist.Add(_lines);
                    
            //
            foreach (LineItems obj in _details.itemslist)
            {
                Console.WriteLine(obj);
                totalitems=obj.AmountGrab();
                cost=obj._product.PriceGrab();
                payment=(cost * totalitems);
                totalitems=0;
                cost=0;

            }
            
            total=total+payment;
            Console.WriteLine("\ntotal cost for the order is: " + total);
            
                string checkout;
                    Console.WriteLine("\nDouble you wish to check out? type yes or no\n");
                    checkout=Console.ReadLine();

             
                    if (checkout=="yes" || checkout=="Yes" || checkout=="YES"){
                        decision=true;
                        }
                        else{

                                decision=false;
                                
                        }
                    }while(decision);


                                _details._totalprice=total;
                    _rest.orderslist.Add(_details);
                    return MenuType.AddStore;
*/

                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddStore;
            }
        }
    }
}