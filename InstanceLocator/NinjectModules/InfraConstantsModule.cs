using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;

namespace InstanceLocator.NinjectModules
{
    /// <summary>
    /// Register all infrastructure related bindings here.
    /// </summary>
    public class InfraConstantsModule : NinjectModule
    {
        public override void Load()
        {
            // Default length of an array.
            // When a new array is initialized the length is resolved via injection!
            //Bind<int>().ToConstant(7).WhenInjectedInto<ICollection>().Named("CollectionLength");
            //Bind<int>().ToConstant(8);

            //Bind<int>().ToConstant(7).When(Callback).Named("CollectionLength");
            //Bind<string>().ToConstant("GreatestStringEver");//.Named("CollectionLength");
        }

        //public bool Callback(Ninject.Activation.IRequest req)
        //{
        //    return false;
        //}
    }
}
