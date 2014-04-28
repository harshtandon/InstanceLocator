using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstanceLocator.SampleData
{
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int PinCode { get; set; }
        public AddressType addressType { get; set; }
        public bool DefaultAddress { get; set; }
        public string[] OtherInfo { get; set; }
    }
}