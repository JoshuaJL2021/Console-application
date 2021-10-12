using System;
using System.Collections.Generic;

namespace Models
{
    public class Customer
    {
        //fields

         public string _name;
         public string _address;
         public string _contact;
private List<Orders> customerOrders = new List<Orders>();

        //in the JSON file the information would be entered in the way the constructors are for each property
        //property that uses the field name
                public string CustomerName
        {
            get { return _name; }
            set { _name = value; }
        }
        

       
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        
        public List<Orders> MyOrders
            {
                set { customerOrders = value; }
                get { return customerOrders; }
            }
       public Customer(string name, string address, string contact){

        }
        public Customer(){}

//in order to simply print out a customers information completely in a writeline
        public override string ToString()
        {
            return $"Name: {_name}\nAddress: {_address}\nContact: {_contact}";
        }
    }
}