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
    /// Provider that creates instances of DateTime
    /// </summary>
    class DateTimeProvider : Provider<DateTime>
    {
        protected override DateTime CreateInstance(IContext context)
        {
            if (!context.Request.Service.IsDateTime())
                throw new InvalidOperationException("Wrong provider plugged in. Current provider serves System.DateTime instead of " + context.Request.Service.FullName);

            DateTime seedDate = new DateTime(2000, 1, 1);
            int maxRange = (DateTime.Today - seedDate).Days;

            return seedDate.AddDays(RandomNumberHelper.Randomizer.Next(1, maxRange + 1));
        }
    }
}