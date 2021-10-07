using System;
using System.Collections.Generic;
using Models;


namespace Models
{
    public class Orders
    {
        private List<LineItems> strings = new List<LineItems>();
        public List<LineItems> ItemsList
            {
                set { strings = value; }
                get { return strings; }
            }
        private StoreFront _location;
        public StoreFront Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private double _totalprice;
        public double TotalPrice
        {
            get { return _totalprice; }
            set { _totalprice = value; }
        }



        
    }
}