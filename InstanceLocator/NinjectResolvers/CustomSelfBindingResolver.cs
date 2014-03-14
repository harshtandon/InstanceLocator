using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Planning.Bindings.Resolvers;

namespace InstanceLocator.NinjectResolvers
{
    /// <summary>
    /// The standard self binding resolver with overriden list of self bindable types.
    /// </summary>
    public class CustomSelfBindingResolver : SelfBindingResolver
    {
        // Want the array types to not be self-bindable. In the absence of any matching binding, resolution calls for 
        // array types will fall back to a custom resolver which will works it's magic.

         // All other types should attempt to do a self binding first.
        protected override bool TypeIsSelfBindable(Type service)
        {

            // TODO : Explicitly specify the supported bindings here.
            // Then we throw helpful exception on why an activation failed.

            return !service.IsInterface
                   && !service.IsAbstract
                   && !service.IsEnum
                   //&& !service.IsValueType    // Don't want value types to be self bound.
                   //&& service != typeof(string)
                   && !service.IsArray
                   && !service.ContainsGenericParameters;
        }
    }
}
