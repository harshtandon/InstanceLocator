using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Planning.Bindings;
using InstanceLocator.Helpers;

namespace InstanceLocator.Extensions
{
    [Obsolete("Not used")]
    public static class NinjectBindingExtensions
    {
        /// <summary>
        /// Add a new binding with the specified token or replace it if it already exists.
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="token"></param>
        public static void ReplaceConstantBinding(this IKernel kernel, System.Type type, object value, string token)
        {
            // TODO - Define some checks on the token to prevent irresponsible replacement

            var bindings = kernel.GetBindings(type).Where(binder => binder.Metadata.Name == token);

            foreach (IBinding binding in bindings)
            {
                kernel.RemoveBinding(binding);
            }

            kernel.Bind(type).ToConstant(value).Named(token);
        }

        public static void IssueFreshBinding(this IKernel kernel, System.Type primitiveType, string token)
        {

            if (typeof(String).IsAssignableFrom(primitiveType))
            {

            }

            if (typeof(String).IsAssignableFrom(primitiveType))
            {
                // Renew Binding here - use extension to preserve
            }
        }

        public static object GetRandomPrimitive(this object primitiveType)
        {
            if (primitiveType is System.Int32)
                return RandomNumberHelper.Randomizer.Next(1, int.MaxValue);
            else
                return new object();
        }
    }
}