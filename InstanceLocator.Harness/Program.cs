using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstanceLocator.Abstract;
using InstanceLocator;

namespace InstanceLocator.Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            IDependencyResolver resolver = new NinjectDependencyResolver();


            var inte = resolver.GetService<int>();
            var inte2 = resolver.GetService<int[]>();

            var str = resolver.GetService<string>();
            var str2 = resolver.GetService<string[]>();

            var boo = resolver.GetService<bool>();


            var en1 = resolver.GetService<PersonType>();
            var en2 = resolver.GetService<PersonType>();


            var a1 = resolver.GetService<PersonType[]>();
            var a2 = resolver.GetService<PersonType[]>();


            var per1 = resolver.GetService<Person>();
            var per2 = resolver.GetService<Person>();

            var perar1 = resolver.GetService<Person[]>();
            var perar2 = resolver.GetService<Person[]>();


            var socar1 = resolver.GetService<Society[]>();
            var socar2 = resolver.GetService<Society[]>();


            Console.WriteLine("Done ... ");
            Console.ReadKey(true);
        }
    }
}