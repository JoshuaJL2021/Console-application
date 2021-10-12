using System.Collections.Generic;
using Models;
using System;


namespace Models
{
    public class StoreFront
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private List<Orders> orders = new List<Orders>();
        public List<Orders> EstablishOrders
            {
                set { orders = value; }
                get { return orders; }
            }
        private List<Products> products = new List<Products>();
        public List<Products> EstablishProducts
            {
                set { products = value; }
                get { return products; }
            }
        
        
    }
}