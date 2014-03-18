using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Activation;
using InstanceLocator.Helpers;

namespace InstanceLocator.NinjectProviders
{
    class BoolProvider : Provider<bool>
    {
        protected override bool CreateInstance(IContext context)
        {
            return RandomNumberHelper.Randomizer.Next(0, 2) == 1;
        }
    }
}
