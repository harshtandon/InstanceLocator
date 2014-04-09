using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InstanceLocator.FakesResolver.Abstract;
using InstanceLocator.FakesResolver.Extensions;
using System.Collections.Generic;
using System.Linq;
using InstanceLocator.SampleData;
using System.Reflection;
using InstanceLocator.FakesResolver;

namespace InstanceLocator.Tests
{
    [TestClass]
    public class FakeResolverTests
    {
        public static IDependencyResolver _resolver;

        [TestInitialize]
        public void SetupTests()
        {
            _resolver = new FakeInstanceResolver();
        }

        [TestMethod]
        public void TestStringInstance()
        {
            var strInstance = _resolver.GetServiceByType(typeof(string));

            Assert.IsNotNull(strInstance);
            Assert.IsInstanceOfType(strInstance, typeof(string));
            Assert.IsTrue(((string)strInstance).Trim().Length > 0);
        }

        [TestMethod]
        public void TestNumericInstance()
        {
            var byteInstance = _resolver.GetServiceByType(typeof(byte));
            var shortInstance = _resolver.GetServiceByType(typeof(short));
            var intInstance = _resolver.GetServiceByType(typeof(int));
            var longInstance = _resolver.GetServiceByType(typeof(long));
            var floatInstance = _resolver.GetServiceByType(typeof(float));
            var doubleInstance = _resolver.GetServiceByType(typeof(double));
            var decimalInstance = _resolver.GetServiceByType(typeof(decimal));

            Assert.IsInstanceOfType(byteInstance, typeof(byte));
            Assert.IsInstanceOfType(shortInstance, typeof(short));
            Assert.IsInstanceOfType(intInstance, typeof(int));
            Assert.IsInstanceOfType(longInstance, typeof(long));
            Assert.IsInstanceOfType(floatInstance, typeof(float));
            Assert.IsInstanceOfType(doubleInstance, typeof(double));
            Assert.IsInstanceOfType(decimalInstance, typeof(decimal));
        }

        [TestMethod]
        public void TestBoolInstance()
        {
            var boolInstance = _resolver.GetServiceByType(typeof(bool));

            Assert.IsInstanceOfType(boolInstance, typeof(bool));
        }

        [TestMethod]
        public void TestDateTimeInstance()
        {
            var dateInstance = _resolver.GetServiceByType(typeof(DateTime));

            Assert.IsInstanceOfType(dateInstance, typeof(DateTime));
            Assert.IsTrue((DateTime)dateInstance != new DateTime());
        }

        [TestMethod]
        public void TestEnumInstance()
        {
            var enumInstance = _resolver.GetServiceByType(typeof(CustomerCategory));

            Assert.IsNotNull(enumInstance);
            Assert.IsInstanceOfType(enumInstance, typeof(CustomerCategory));
        }

        [TestMethod]
        public void TestComplexEntityWithProperty()
        {
            var customer = _resolver.GetServiceByType(typeof(Customer));

            Assert.IsNotNull(customer);
            Assert.IsInstanceOfType(customer, typeof(Customer));
            TestInitialization(customer);
        }

        [TestMethod]
        public void TestComplexEntityWithCtor()
        {
            var product = _resolver.GetServiceByType(typeof(Product));

            Assert.IsNotNull(product);
            Assert.IsInstanceOfType(product, typeof(Product));
            TestInitialization(product);
        }

        [TestMethod]
        public void TestPrimitiveArray()
        {
            var strSet = (string[])_resolver.GetServiceByType(typeof(string[]));

            Assert.IsNotNull(strSet);
            Assert.IsInstanceOfType(strSet, typeof(string[]));
            Assert.IsTrue(strSet.All(st => st != null));
            Assert.IsFalse(strSet.Any(st => st.Trim().Length == 0));
        }

        [TestMethod]
        public void TestComplexEntityArray()
        {
            var customerSet = (Customer[])_resolver.GetServiceByType(typeof(Customer[]));

            Assert.IsNotNull(customerSet);
            Assert.IsInstanceOfType(customerSet, typeof(Customer[]));
            Assert.IsTrue(customerSet.All(cust => cust != null));

            foreach (var customer in customerSet)
            {
                TestInitialization(customer);
            }
        }

        /// <summary>
        /// Assert whether all public properties of reference type are initialized
        /// </summary>
        /// <param name="entity"></param>
        private void TestInitialization(object entity)
        {
            var type = entity.GetType();

            foreach (var publicProp in type.GetProperties())
            {
                if (publicProp.PropertyType.IsValueType)
                    continue;

                var entityVal = publicProp.GetValue(entity, null);
                
                Assert.IsNotNull(entityVal, "Property " + publicProp + " of type " + type  + " was not initialized.");
            }

        }
    }
}