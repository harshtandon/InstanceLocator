using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Activation;
using InstanceLocator.Helpers;

namespace InstanceLocator.NinjectProviders
{
    /// <summary>
    /// Provider that returns a randomly selected enumeration from amongst all possible values of an enum.
    /// </summary>
    class EnumProvider : Provider<object>
    {
        protected override object CreateInstance(IContext context)
        {
            if (!context.Request.Service.IsEnum)
                throw new InvalidOperationException("Wrong provider plugged in. Current provider serves Enum instead of " + context.Request.Service.FullName);
            
            var enumValues = context.Request.Service.GetEnumValues();
            int randIndex = Helpers.RandomNumberHelper.Randomizer.Next(0, enumValues.Length);
            var randEnum = Enum.ToObject(context.Request.Service, enumValues.GetValue(randIndex));

            return randEnum;
        }
    }
}