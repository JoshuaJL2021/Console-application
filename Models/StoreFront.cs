using System.Collections.Generic;
using Models;
using System;


namespace Models
{
    public class StoreFront
    {
        public string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        

        public string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public List<Orders> orders = new List<Orders>();
        public List<Orders> EstablishOrders
            {
                set { orders = value; }
                get { return orders; }
            }
        public List<Products> products = new List<Products>();
        public List<Products> EstablishProducts
            {
                set { products = value; }
                get { return products; }
            }
        
        
    }
}