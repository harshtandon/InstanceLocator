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


            //TODO : Figure out a way to remove the explicit specn. of token

            var inte = resolver.GetService<int>("Default");

            var str = resolver.GetService<string>("Default");

            var boo = resolver.GetService<bool>("Default");

            
            var en1 = resolver.GetService<PersonType>();
            var en2 = resolver.GetService<PersonType>();


            var a1 = resolver.GetService<PersonType[]>();
            var a2 = resolver.GetService<PersonType[]>();

            foreach (PersonType t in a1)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("\n.....\n");
            foreach (PersonType t in a2)
            {
                Console.WriteLine(t);
            }


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
