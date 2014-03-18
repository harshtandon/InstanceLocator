using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;

namespace InstanceLocator.NinjectModules
{
    /// <summary>
    /// This module binds supported primitives to a constant value specified by the user.
    /// </summary>
    public class OverridenConstantsModule : NinjectModule
    {
        public override void Load()
        {
            //ReadBindExternalSource();
        }

        private void ReadBindExternalSource()
        {
            Bind<int>().ToConstant(12).Named("Preferred");

            Bind<string>().ToConstant("OverridenString").Named("Preferred");

            Bind<bool>().ToConstant(true).Named("Preferred");

        }
    }
}
