using System;

namespace Models
{
    public class LineItems
    {
        private string _product;
        public string Product
        {
            get { return _product; }
            set { _product = value; }
        }
        

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        
        
    }
}