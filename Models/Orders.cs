using System;
using System.Collections.Generic;
using Models;


namespace Models
{
    public class Orders
    {
        public List<LineItems> itemslist = new List<LineItems>();
        public List<LineItems> PurchaseList
            {
                set { itemslist = value; }
                get { return itemslist; }
            }
        public StoreFront _location;
        public StoreFront Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public double _totalprice;
        public double TotalPrice
        {
            get { return _totalprice; }
            set { _totalprice = value; }
        }


public override string ToString()
        {
            string text=$"Order is from location : {_location}\tTotal Price :${_totalprice}";
            return text;
        }
        
    }
}