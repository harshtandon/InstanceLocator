using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstanceLocator.Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanceLocator.FakesResolver.Abstract.IDependencyResolver resolver = new InstanceLocator.FakesResolver.FakeInstanceResolver();

            //var int1 = resolver.GetService<int>();
            //var int2 = resolver.GetService<int[]>();

            //var str1 = resolver.GetService<string>();
            //var str2 = resolver.GetService<string[]>();

            //var boo1 = resolver.GetService<bool>();
            //var boo2 = resolver.GetService<bool[]>();

            //var dt1 = resolver.GetService<DateTime>();
            //var dt2 = resolver.GetService<DateTime[]>();

            //var prod1 = resolver.GetServiceByType(typeof(SampleData.Product));
            //var prod1 = resolver.GetServiceByType(typeof(SampleData.Product));
            //var prod2 = resolver.GetServiceByType(typeof(SampleData.Product[]));

            //var sal1 = resolver.GetServiceByType(typeof(SampleData.Sale));
            //var sal2 = resolver.GetServiceByType(typeof(SampleData.Sale[]));

            //var chek1 = resolver.GetServiceByType(typeof(SampleData.Checkout));


            //var c1 = resolver.GetServiceByType(typeof(char));


            var x = new Dictionary<string, Type>();

            x.Add("orderId", typeof(int));
            x.Add("priorityOrder", typeof(bool));
            x.Add("productBought", typeof(SampleData.Product));
            x.Add("deliveryAddress", typeof(SampleData.Address));

            x.Add("orderDate", typeof(DateTime));
            x.Add("customerInfo", typeof(SampleData.Customer));

            var instances = EntryPoint.InstanceLocator.GetInstances(x, "getEmployeeByName_PositiveScenario");

            Console.WriteLine("Done ... ");
            Console.ReadKey(true);
        }
    }
}