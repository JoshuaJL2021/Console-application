using System;

namespace Models
{
    public class LineItems
    {
        
        public Products _product;
        public Products ProductEstablish
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
            return $"{_product}\nquantity available : {_quantity}\n";
        }
        
        public int AmountGrab(){
    return _quantity;
}
    }
}