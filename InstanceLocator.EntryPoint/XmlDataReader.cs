using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstanceLocator.SampleData;

namespace InstanceLocator.EntryPoint
{
    public static class XmlDataReader
    {
        public static void ReadFile(string path)
        {

            Product pd = new Product(12) {IntroducedDate = DateTime.Now, NiceProduct = true, ProductId = 12345, ProductName ="Mush", ProductType = ProductType.FROZEN };
            var custSerialized = System.Security.SecurityElement.Escape(SerializerHelper.SerializeToJson(pd));

            Address ad =  new SampleData.Address() { AddressLine1 = "Lion 1", AddressLine2 = "Lion 2", addressType = AddressType.HOME, PinCode = 560017, DefaultAddress = true };
            var addrSerialized = SerializerHelper.SerializeToXml(ad);

        }
    }
}