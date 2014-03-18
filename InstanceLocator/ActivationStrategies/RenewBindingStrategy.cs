using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Activation;
using Ninject.Activation.Strategies;
using InstanceLocator.Extensions;

namespace InstanceLocator.ActivationStrategies
{
    /// <summary>
    /// DON'T USE - Use IMissingBindingResolver instead to build instances at runtime
    /// An activation strategy that renews a binding for any requested primitive.
    /// This ensures fakes are composed of primitives with random values. Fakes become snowfakes.
    /// </summary>
    [Obsolete]
    class RenewBindingStrategy : ActivationStrategy
    {
        public override void Activate(IContext context, InstanceReference reference)
        {
            context.Kernel.IssueFreshBinding(context.Request.Service, "Default"); 


            //context.Request.Service.BindTypeToConstant(context.Kernel);
        }
    }
}
