using System;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class AddStoreFront : IMenu
    {
        private static StoreFront _rest = new StoreFront();
        private static Orders _details = new Orders();

        private InterfaceBL parameterInter;

        public AddStoreFront(InterfaceBL parameterobj)
        {
            parameterInter = parameterobj;
        }

        public void Menu()
        {
            Console.WriteLine("Adding a new Store Front");
            Console.WriteLine("Name of store- " + _rest._name);
            Console.WriteLine("Address of store - " + _rest._address);

            Console.WriteLine("order history");
            foreach (Orders obj in _rest.orderslist)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("[4] - Add StoreFront");
            Console.WriteLine("[3] - Input value for Name");
            Console.WriteLine("[2] - Input value for Address");

            Console.WriteLine("[0] - Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {

                case "4":
                    //Add implementation to talk to the repository method to add a restaurant
                    parameterInter.AddStoreFrontBL(_rest);

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

                 Products _prods=parameterInter.CreateProduct();
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