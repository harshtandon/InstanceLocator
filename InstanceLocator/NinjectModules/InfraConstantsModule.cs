﻿using System;
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
            //Bind<int>().ToConstant(6).WhenInjectedInto(typeof(System.Collections.ICollection)); // Works

            Bind<int>().ToConstant(7).Named("CollectionLength");
        }
    }
}
