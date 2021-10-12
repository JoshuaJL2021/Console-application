using System;
using System.Collections.Generic;
using Models;


namespace Models
{
    public class Orders
    {
        public List<LineItems> strings = new List<LineItems>();
        public List<LineItems> ItemsList
            {
                set { strings = value; }
                get { return strings; }
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



        
    }
}