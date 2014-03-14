using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public IEnumerable<IBinding> Resolve(Multimap<Type, IBinding> bindings, IRequest request)
        {

            // Register provider for Array
            if (request.Service.IsArray)
            {
                return new[] 
                {
                    new Binding(request.Service)
                    {
                        ProviderCallback = (context => new ArrayProvider())
                        //,Condition = (rqst => rqst.Service.IsArray),
                    }
                };
            }

            // Register provider for Enum
            if (request.Service.IsEnum)
            {
                return new[]
                {
                    new Binding(request.Service)
                    {
                        ProviderCallback = (context => new EnumProvider())
                        //,Condition = (rqst => rqst.Service.IsEnum),
                    }
                };
            }

            // Unable to find an appropriate resolver
            // TODO - Throw an exception maybe ?
            return Enumerable.Empty<Binding>();
        }
    }
}