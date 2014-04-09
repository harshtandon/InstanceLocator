using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstanceLocator.FakesResolver.Extensions;
using Ninject.Infrastructure;
using Ninject.Components;
using Ninject.Activation;
using Ninject.Planning.Bindings;
using Ninject.Planning.Bindings.Resolvers;
using InstanceLocator.FakesResolver.NinjectProviders;

namespace InstanceLocator.FakesResolver.NinjectResolvers
{
    /// <summary>
    /// Generates binding at runtime for types not bound explicitly and also excluded from self binding.
    /// </summary>
    class FallbackResolver : NinjectComponent, IMissingBindingResolver
    {
        private static readonly IDictionary<Predicate<IRequest>, System.Type> _providerMap;

        static FallbackResolver()
        {
            _providerMap = new Dictionary<Predicate<IRequest>, Type>
            {
                {req => req.Service.IsEnum, typeof(EnumProvider)},
                {req => req.Service.IsArray, typeof(ArrayProvider)},
                {req => req.Service.IsString(), typeof(StringProvider)},
                {req => req.Service.IsNumericType(), typeof(NumericalsProvider)},
                {req => req.Service.IsBoolean(), typeof(BoolProvider)},
                {req => req.Service.IsDateTime(), typeof(DateTimeProvider)}
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
            var providerType = _providerMap.FirstOrDefault(pair => pair.Key(context.Request)).Value;

            if (providerType == null)
                throw new Exception("InstanceLocator : Unable to find a resolver for " + context.Request.Service);

            return (IProvider)Activator.CreateInstance(providerType);
        }
    }
}