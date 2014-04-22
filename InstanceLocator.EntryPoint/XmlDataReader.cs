using System;
using System.Collections.Generic;
using System.Xml;

namespace InstanceLocator.EntryPoint
{
    /// <summary>
    /// Helps deserialize the instances found in the data specification file.
    /// </summary>
    public static class XmlDataReader
    {
        /// <summary>
        /// Returns a dictionary of all instances mapped to the parameter names after discovery from the specified data specification file.
        /// </summary>
        /// <param name="dataPath"></param>
        /// <param name="parameterRequests"></param>
        /// <param name="testCaseScope"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetInstancesFromSpecification(string dataPath, Dictionary<string, Type> parameterRequests, string testCaseScope)
        {
            var instancesFound = new Dictionary<string, object>();

            XmlDocument dataSpec = new XmlDocument();
            dataSpec.Load(dataPath);

            var testData = dataSpec.SelectSingleNode(string.Format("//TestData/Test[@TestMethod='{0}']", testCaseScope));

            if (testData != null)
            {
                var testParams = testData.SelectNodes("param");

                if (testParams != null)
                {
                    foreach (XmlNode parameter in testParams)
                    {
                        var paramName = parameter.Attributes["name"].Value;

                        if (!parameterRequests.ContainsKey(paramName))
                            continue;

                        string serialized;

                        if (parameter.ChildNodes.Count > 0)
                        {
                            if (parameter.ChildNodes[0] is XmlCDataSection)
                            {
                                var encodedData = parameter.ChildNodes[0] as XmlCDataSection;
                                serialized = encodedData.InnerText;
                            }
                            else
                                serialized = parameter.ChildNodes[0].InnerText;

                            object instance = Deserializer.GetDeserializedInstance(parameterRequests[paramName], serialized);

                            instancesFound.Add(paramName, instance);
                        }
                    }

                }

            }

            return instancesFound;
        }
    }
}