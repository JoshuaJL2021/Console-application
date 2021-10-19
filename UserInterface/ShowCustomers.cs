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
            Console.WriteLine("Welcome "+ Customer.displayName);
            Console.WriteLine("insert store name");
            //StoreFront.selectedStore=Console.ReadLine();
            string searchname=Console.ReadLine();
            List<StoreFront> listOfStoreFront = _restBL.GetAllStoreFrontsBL();

            /* var myLinqQuery =  from store in text
            			   where store.Contains(StoreFront.selectedStore)
            				select store;
                    foreach (string store in myLinqQuery)
            Console.Write(store + "\n "); */
StoreFront test=_restBL.GetStore(searchname);
Console.Write(test + "\n ");
test.productslist.Add(_restBL.CreateProduct());
test.productslist.Add(_restBL.CreateProduct());
foreach(Products p in test.productslist)
{
    Console.WriteLine(p);
}
test._name="TestInsertion";
_restBL.AddStoreFrontBL(test);

StoreFront test2=_restBL.GetStore(test._name);
Console.Write(test2 + "\n ");
test2.productslist=_restBL.ShowProducts(test); 
test2.productslist.Add(_restBL.CreateProduct());
foreach(Products p in test2.productslist)
{
    Console.WriteLine(p);
}




  












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