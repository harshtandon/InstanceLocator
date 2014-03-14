using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Activation;

namespace InstanceLocator.NinjectProviders
{
    /// <summary>
    /// Provider that returns a randomly selected enumeration from amongst all possible values of an enum.
    /// </summary>
    class EnumProvider : Provider<object>
    {
        protected override object CreateInstance(IContext context)
        {
            var enumValues = context.Request.Service.GetEnumValues();
            int randIndex = Helpers.RandomNumberHelper.Randomizer.Next(0, enumValues.Length);
            var randEnum = Enum.ToObject(context.Request.Service, enumValues.GetValue(randIndex));

            return randEnum;
        }
    }
}