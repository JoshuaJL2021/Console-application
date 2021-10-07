using System;

namespace Models
{
    public class Customer
    {
        private string _name;
        public string CustomerName
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

        private string _contact;
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        private List<Orders> customerOrders = new List<Orders>();
        public List<Orders> MyOrders
            {
                set { customerOrders = value; }
                get { return customerOrders; }
            }
    }
}