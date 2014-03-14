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
    /// All bindings have a named token called 'Preferred'.
    /// </summary>
    public class OverridenConstantsModule : NinjectModule
    {
        public override void Load()
        {
            //ReadBindExternalSource();
        }

        private void ReadBindExternalSource()
        {
            // TODO : These bindings will not be in such a global scope.
            // When reading from the data file, we need to be able to define a parent scope
            // Like so, Bind<int>().ToConstant(12).WhenParentNamed("Parent").Named("Preferred");
            
            Bind<int>().ToConstant(12).Named("Preferred");

            Bind<string>().ToConstant("OverridenString").Named("Preferred");

            Bind<bool>().ToConstant(true).Named("Preferred");

        }
    }
}
