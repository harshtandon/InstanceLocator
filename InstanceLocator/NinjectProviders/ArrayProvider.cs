using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Activation;

namespace InstanceLocator.NinjectProviders
{
    /// <summary>
    /// Provider that creates instances of an array of any specified type. 
    /// Any nested dependencies of element types are all resolved recursively through normal resolution pipeline.
    /// </summary>
    class ArrayProvider : Provider<object>
    {
        protected override object CreateInstance(IContext context)
        {
            var elementType = context.Request.Service.GetElementType();
            var arrayLength = context.Kernel.Get<int>("CollectionLength");

            var arrayInstance = Array.CreateInstance(elementType, arrayLength);

            // Arrays have been configured to prevent self binding which leads to a null stuffed array.
            // Loop so we can generate a new fake instance every time and stuff it in the array.
            for (int idx = 0; idx < arrayLength; ++idx)
            {
                var elementInstance = context.Kernel.Get(elementType);
                arrayInstance.SetValue(elementInstance, idx);
            }

            return arrayInstance;
        }
    }
}