using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstanceLocator.FakesResolver.Abstract;
using InstanceLocator;

namespace InstanceLocator.Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            //IDependencyResolver resolver = new FakeInstanceResolver();


            //var int1 = resolver.GetService<int>();
            //var int2 = resolver.GetService<int[]>();

            //var str1 = resolver.GetService<string>();
            //var str2 = resolver.GetService<string[]>();

            //var boo1 = resolver.GetService<bool>();
            //var boo2 = resolver.GetService<bool[]>();

            //var dt1 = resolver.GetService<DateTime>();
            //var dt2 = resolver.GetService<DateTime[]>();

            //var prod1 = resolver.GetServiceByType(typeof(SampleData.Product));
            //var prod2 = resolver.GetServiceByType(typeof(SampleData.Product[]));

            //var sal1 = resolver.GetServiceByType(typeof(SampleData.Sale));
            //var sal2 = resolver.GetServiceByType(typeof(SampleData.Sale[]));

            //var chek1 = resolver.GetServiceByType(typeof(SampleData.Checkout));


            InstanceLocator.EntryPoint.XmlDataReader.ReadFile("asd");

            Console.WriteLine("Done ... ");
            Console.ReadKey(true);
        }
    }
}