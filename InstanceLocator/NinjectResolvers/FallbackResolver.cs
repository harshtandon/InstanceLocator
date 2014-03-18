using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstanceLocator.Extensions;
using Ninject.Infrastructure;
using Ninject.Components;
using Ninject.Activation;
using Ninject.Planning.Bindings;
using Ninject.Planning.Bindings.Resolvers;
using InstanceLocator.NinjectProviders;

namespace InstanceLocator.NinjectResolvers
{
    class FallbackResolver : NinjectComponent, IMissingBindingResolver
    {
        private static readonly IDictionary<Predicate<IRequest>, System.Type> ProviderMap;

        static FallbackResolver()
        {
            ProviderMap = new Dictionary<Predicate<IRequest>, Type>
            {
                {req => req.Service.IsEnum, typeof(EnumProvider)},
                {req => req.Service.IsArray, typeof(ArrayProvider)},
                {req => req.Service == typeof (string), typeof(StringProvider)},
                {req => req.Service.IsNumericType(), typeof(NumericalsProvider)},
                {req => req.Service == typeof (bool), typeof(BoolProvider)},
            };
        }

        public IEnumerable<IBinding> Resolve(Multimap<Type, IBinding> bindings, IRequest request)
        {
            return new[]
                {
                    new Binding(request.Service)
                    {
                        ProviderCallback = ProviderCallback
                    }
                };
        }

        private IProvider ProviderCallback(IContext context)
        {
            var providerType = ProviderMap.FirstOrDefault(pair => pair.Key(context.Request)).Value;

            if (providerType == null)
                throw new Exception("Unable to find a resolver");

            return (IProvider)Activator.CreateInstance(providerType);
        }
    }
}