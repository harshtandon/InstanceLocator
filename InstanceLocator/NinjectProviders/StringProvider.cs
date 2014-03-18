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
    /// Provider that creates a random instance of string
    /// </summary>
    class StringProvider : Provider<object>
    {
        public static readonly string[] StringPool =  ("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et " +
                                                "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." +
                                                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat "  +
                                                "cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum")
                                                    .Replace(".", "").Replace(",", "").Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        protected override object CreateInstance(IContext context)
        {
            if(!context.Request.Service.IsString())
                throw new InvalidOperationException("Wrong provider plugged in. Current provider serves String instead of " + context.Request.Service.FullName);

            return StringPool[RandomNumberHelper.Randomizer.Next(0, StringPool.Length)];
        }
    }
}
