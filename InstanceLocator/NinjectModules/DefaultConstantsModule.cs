using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using InstanceLocator.Extensions;

namespace InstanceLocator.NinjectModules
{
    /// <summary>
    /// This module binds supported primitives (known at compile time) to some constant value.
    /// Types which can only be discovered during runtime like Enum and Sytem.Array are bound and resolved at runtime.
    /// </summary>
    public class DefaultConstantsModule : NinjectModule
    {
        public override void Load()
        {

            Kernel.IssueFreshBinding(typeof(System.Int32), "Default");


            Kernel.IssueFreshBinding(typeof(System.String), "Default");


            Kernel.IssueFreshBinding(typeof(System.Boolean), "Default");



            //Bind<int>().ToConstant(98).Named("Default");

            //Bind<String>().ToConstant("DefaultString").Named("Default");

            //Bind<bool>().ToConstant(false).Named("Default");

        }
    }
}