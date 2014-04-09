using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstanceLocator.SampleData
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address address { get; set; }
        public DateTime CustomerSince { get; set; }
        public CustomerCategory customerCategory { get; set; }
    }
}