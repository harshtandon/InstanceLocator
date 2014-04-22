using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;


namespace InstanceLocator.EntryPoint
{
    /// <summary>
    /// Helps deserialize a string to a given type depending on its encoding.
    /// </summary>
    public static class Deserializer
    {
        /// <summary>
        /// Deserialize to the given type after discovering its encoding (JSON/XML/None).
        /// </summary>
        /// <param name="parameterType"></param>
        /// <param name="serializedParam"></param>
        /// <returns></returns>
        public static object GetDeserializedInstance(Type parameterType, string serializedParam)
        {
            serializedParam = serializedParam.Trim();

            if (serializedParam.StartsWith("{") || serializedParam.StartsWith("["))
            {
                // JSON encoding
                return DeserializeJson(parameterType, serializedParam);
            }
            else if (serializedParam.StartsWith("<"))       
            {
                // XML encoding
                return DeserializeXml(parameterType, serializedParam);
            }
            
            // No encoding
            var typeConverter = TypeDescriptor.GetConverter(parameterType);
            return typeConverter.ConvertFrom(serializedParam);
        }

        private static object DeserializeJson(Type parameterType, string serializedParam)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(serializedParam, parameterType);
        }

        private static object DeserializeXml(Type parameterType, string serializedParam)
        {
            using (Stream stream = new MemoryStream())
            {
                var data = System.Text.Encoding.UTF8.GetBytes(serializedParam);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                DataContractSerializer serializer = new DataContractSerializer(parameterType);
                return serializer.ReadObject(stream);
            }
        }
    }
}
