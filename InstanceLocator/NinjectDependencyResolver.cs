using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;
using InstanceLocator.Abstract;
using Ninject.Planning.Bindings.Resolvers;
using InstanceLocator.NinjectResolvers;
using InstanceLocator.ActivationStrategies;

namespace InstanceLocator
{
    /// <summary>
    /// A dependency resolver that uses Ninject as DI Container.
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _coreKernel;

        #region Constructors

        /// <summary>
        /// Initialize a Standard Kernel, auto discover & load all modules in the current assembly.
        /// </summary>
        public NinjectDependencyResolver() : this(new StandardKernel())
        { }

        /// <summary>
        /// Initialize with specified Kernel, auto discover & load all modules in the current assembly.
        /// </summary>
        /// <param name="kernel"></param>
        public NinjectDependencyResolver(IKernel kernel)
        {
            this._coreKernel = kernel;
            
            // Get all modules in the current assembly
            this._coreKernel.Load(System.Reflection.Assembly.GetExecutingAssembly());
            this.SetupComponents();
        }

        /// <summary>
        /// Initialize with specified Kernel and load specified modules in that Kernel.
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="moduleList"></param>
        public NinjectDependencyResolver(IKernel kernel, params INinjectModule[] moduleList)
        {
            this._coreKernel = kernel;
            this._coreKernel.Load(moduleList);
            this.SetupComponents();
        }

        #endregion

        public T GetService<T>()
        {
            return _coreKernel.Get<T>();
        }

        public T GetService<T>(string token)
        {
           return  _coreKernel.Get<T>(token);
        }

        public object GetServiceByType(Type type, string token)
        {
            return default(Type);
        }

        #region Private Methods
        
        private void SetupComponents()
        {
            // By default, Ninject registers 2 MissingBindingResolvers - 
            // [1] DefaultValueBindingResolver - Can safely remove this since we don't want resolution of any type 
            //  to return a default value for that type. Bindings for all supported types should be explicitly registered.
            // [2] SelfBindingResolver - This is needed but we will register our own SelfBindingResolver.
            // Ref- https://github.com/ninject/ninject/blob/master/src/Ninject/StandardKernel.cs
            
            
            _coreKernel.Components.RemoveAll<IMissingBindingResolver>();

            // Order is important here
            _coreKernel.Components.Add<IMissingBindingResolver, CustomSelfBindingResolver>();
            _coreKernel.Components.Add<IMissingBindingResolver, FallbackResolver>();

            _coreKernel.Components.Add<Ninject.Activation.Strategies.IActivationStrategy, RenewBindingStrategy>();
        }

        # endregion
    }
}
