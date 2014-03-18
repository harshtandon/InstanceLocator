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
        public static readonly IDictionary<Predicate<IRequest>, IProvider> ProviderMap;

        public IEnumerable<IBinding> Resolve(Multimap<Type, IBinding> bindings, IRequest request)
        {
            if (request.Service.IsEnum)
            {
                return new[]
                {
                    new Binding(request.Service)
                    {
                        ProviderCallback = (context => new EnumProvider())
                    }
                };
            }

            if (request.Service.IsArray)
            {
                return new[] 
                {
                    new Binding(request.Service)
                    {
                        ProviderCallback = (context => new ArrayProvider())
                    }
                };
            }

            if (request.Service == typeof(string))
            {
                return new[]
                {
                    new Binding(request.Service)
                    {
                        ProviderCallback = (context =>  new StringProvider())
                    }
                };
            }

            if (request.Service == typeof(Int32))
            {
                return new[]
                {
                    new Binding(request.Service)
                    {
                        ProviderCallback = (context => new NumericalsProvider()),
                    }
                };
            }

            if (request.Service == typeof(bool))
            {
                return new[]
                {
                    new Binding(request.Service)
                    {
                        ProviderCallback = (context => new BoolProvider()),
                    }
                };
            }

            return Enumerable.Empty<Binding>();
        }

        //private Binding CreateRuntimeBinding(System.Type serviceRequested, string token = "Explicit")
        //{
        //    IBindingConfiguration config = new BindingConfiguration();
        //    config.Metadata.Name = token;

        //    Binding binding = new Binding(serviceRequested, config);

        //    if(serviceRequested.IsArray)
        //        binding.ProviderCallback = (ctxt => new ArrayProvider());
        //    else if(serviceRequested.IsEnum)
        //        binding.ProviderCallback = (ctxt => new EnumProvider());
        //    else if (serviceRequested = typeof(string)) 
        //        binding.ProviderCallback = (ctxt => new StringProvider());
        //    else if (serviceRequested == typeof(Int32)) 
        //        binding.ProviderCallback = (ctxt => new NumericalsProvider());

        //    return binding;
        //}
    }
}