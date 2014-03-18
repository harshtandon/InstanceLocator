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
        // All other types should attempt to do a self binding first.
        protected override bool TypeIsSelfBindable(Type service)
        {
            return    !service.IsInterface
                   && !service.IsAbstract
                   && !service.ContainsGenericParameters
                   && !service.IsEnum
                   && !service.IsArray
                   && service != typeof(byte) && service != typeof(short) && service != typeof(int) && service != typeof(long)
                   && service != typeof(float) && service != typeof(double) && service != typeof(decimal)
                   && service != typeof(string)
                   && service != typeof(bool)
                   && service != typeof(DateTime);
        }
    }
}
