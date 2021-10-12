using System;

namespace Models
{
    public class Products
    {
        public string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        

        public double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        

        
    }
}