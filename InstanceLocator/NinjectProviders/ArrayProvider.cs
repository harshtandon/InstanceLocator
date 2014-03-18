using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Activation;
using Ninject.Planning.Bindings;

namespace InstanceLocator.NinjectProviders
{
    /// <summary>
    /// Provider that creates instances of an array of any specified type. 
    /// Any nested dependencies of element types are all resolved recursively through normal resolution pipeline.
    /// Arrays have been explicitly configured to prevent self binding which  otherwise leads to a null/0 stuffed array.
    /// </summary>
    class ArrayProvider : Provider<object>
    {
        protected override object CreateInstance(IContext context)
        {
            if (!context.Request.Service.IsArray)
                throw new InvalidOperationException("Wrong provider plugged in. Current provider serves System.Array instead of " + context.Request.Service.FullName);

            var elementType = context.Request.Service.GetElementType();

            // TODO : var arrayLength = context.Kernel.Get<int>("CollectionLength");
            var arrayLength = Helpers.RandomNumberHelper.Randomizer.Next(1, 11);

            var arrayInstance = Array.CreateInstance(elementType, arrayLength);

            for (int idx = 0; idx < arrayLength; ++idx)
            {
                var elementInstance = context.Kernel.Get(elementType);
                arrayInstance.SetValue(elementInstance, idx);
            }

            return arrayInstance;
        }
    }
}