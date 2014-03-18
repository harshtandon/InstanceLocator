using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Activation;
using InstanceLocator.Helpers;

namespace InstanceLocator.NinjectProviders
{
    /// <summary>
    /// Provider that creates instances of DateTime
    /// </summary>
    class DateTimeProvider : Provider<DateTime>
    {
        protected override DateTime CreateInstance(IContext context)
        {
            throw new NotImplementedException();
        }
    }
}
