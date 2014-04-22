using System;
using System.Collections.Generic;
using System.Linq;
using InstanceLocator.FakesResolver;

namespace InstanceLocator.EntryPoint
{
    public static class InstanceLocator
    {
        public static Dictionary<string, object> GetInstances(Dictionary<string, Type> parameterRequests, string testCaseName, string dataPath = @"C:\Users\qi94\Desktop\DataSpecn.xml")
        {
            var dataDiscovered = XmlDataReader.GetInstancesFromSpecification(dataPath, parameterRequests, testCaseName);
            var fakesRequired = parameterRequests.Keys.Except(dataDiscovered.Keys);

            if (fakesRequired.Count() == 0)
                return dataDiscovered;

            var fakes = new Dictionary<string, object>();
            FakesResolver.Abstract.IDependencyResolver fakeResolver = new FakesResolver.FakeInstanceResolver();

            foreach (var fakeRequested in fakesRequired)
            {
                object fakeInstance = fakeResolver.GetServiceByType(parameterRequests[fakeRequested], fakeRequested);
                fakes.Add(fakeRequested, fakeInstance);
            }

            return dataDiscovered.Concat(fakes).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}