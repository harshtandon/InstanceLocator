using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstanceLocator.Extensions;
using Ninject.Activation;
using InstanceLocator.Helpers;

namespace InstanceLocator.NinjectProviders
{
    /// <summary>
    /// Provider that creates instances of System.Boolean
    /// </summary>
    class BoolProvider : Provider<bool>
    {
        protected override bool CreateInstance(IContext context)
        {
            if (!context.Request.Service.IsBoolean())
                throw new InvalidOperationException("Wrong provider plugged in. Current provider serves System.Boolean instead of " + context.Request.Service.FullName);
            
            return RandomNumberHelper.Randomizer.Next(0, 2) == 1;
        }
    }
}