using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace InstanceLocator.SampleData
{
    public static class SerializerHelper
    {
        public static string SerializeToXml(object entity)
        {
            using (MemoryStream memStm = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(entity.GetType());
                serializer.WriteObject(memStm, entity);

                memStm.Seek(0, SeekOrigin.Begin);

                using (var streamReader = new StreamReader(memStm))
                {
                    string result = streamReader.ReadToEnd();
                    return result;
                }
            }
        }

        public static string SerializeToJson(object entity)
        {
            return JsonConvert.SerializeObject(entity);
        }
    }
}
