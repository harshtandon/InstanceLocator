using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstanceLocator.FakesResolver.Abstract
{
    public interface IDependencyResolver
    {
        /// <summary>
        /// Resolve a type and all it's dependencies.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <returns></returns>
        T GetService<T>();

        /// <summary>
        /// Resolve a type and all it's dependencies given it's token.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <returns></returns>
        T GetService<T>(string token);

        /// <summary>
        /// Resolve a runtime type and all it's dependencies given it's type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        object GetServiceByType(Type type);

        /// <summary>
        /// Resolve a runtime type and all it's dependencies given it's type and token.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        object GetServiceByType(Type type, string token);
    }
}
