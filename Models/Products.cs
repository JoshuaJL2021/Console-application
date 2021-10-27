using System;

namespace Models
{
    public class Products
    {
        public int Id { get; set; }
        public string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        

        public decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Description { get; set; }
        public string Category { get; set; }
        
public override string ToString()
        {
            return $"Product Name: {_name}\n Price $: {_price}\n";
        }
public decimal PriceGrab(){
    return _price;
}
        
    }
}