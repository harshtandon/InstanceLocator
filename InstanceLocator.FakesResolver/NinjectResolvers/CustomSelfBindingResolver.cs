using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Planning.Bindings.Resolvers;
using InstanceLocator.FakesResolver.Extensions;

namespace InstanceLocator.FakesResolver.NinjectResolvers
{
    /// <summary>
    /// The standard self binding resolver with overriden list of self bindable types.
    /// </summary>
    public class CustomSelfBindingResolver : SelfBindingResolver
    {
        // All other types should attempt to do a resolution via self binding.
        protected override bool TypeIsSelfBindable(Type service)
        {
            return !service.IsInterface
                && !service.IsAbstract
                && !service.ContainsGenericParameters
                && !service.IsEnum
                && !service.IsArray
                && !service.IsNumericType()
                && !service.IsString()
                && !service.IsBoolean()
                && !service.IsDateTime()
                && service != typeof(char);
        }
    }
}