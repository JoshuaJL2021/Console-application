using System;
using System.Collections.Generic;
using Models;


namespace Models
{
    public class Orders
    {
        public int Id { get; set; }
        public List<LineItems> itemslist = new List<LineItems>();
        public List<LineItems> ItemsList
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

        public decimal _totalprice;
        public decimal TotalPrice
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