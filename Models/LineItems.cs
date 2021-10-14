using System;

namespace Models
{
    public class LineItems
    {
        public string _product;
        public string Product
        {
            get { return _product; }
            set { _product = value; }
        }
        

        public int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public override string ToString()
        {
            return $"Product Name: {_product}\nAddress: {_quantity}\n";
        }
        
    }
}