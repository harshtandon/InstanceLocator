using System;
using InstanceLocator.FakesResolver.Abstract;
using InstanceLocator.FakesResolver.NinjectResolvers;
using Ninject;
using Ninject.Modules;
using Ninject.Planning.Bindings.Resolvers;
using Ninject.Selection.Heuristics;
using Ninject.Parameters;
using System.Diagnostics.CodeAnalysis;

namespace InstanceLocator.FakesResolver
{
    /// <summary>
    /// A dependency resolver that uses Ninject as DI Container to generate fake instances.
    /// </summary>
    public class FakeInstanceResolver : IDependencyResolver
    {
        private IKernel _coreKernel;

        #region Constructors

        /// <summary>
        /// Initialize a Standard Kernel, auto discover & load all modules in the current assembly.
        /// </summary>
        public FakeInstanceResolver()
            : this(new StandardKernel())
        { }

        /// <summary>
        /// Initialize with specified Kernel, auto discover & load all modules in the current assembly.
        /// </summary>
        /// <param name="kernel"></param>
        public FakeInstanceResolver(IKernel kernel)
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
        public FakeInstanceResolver(IKernel kernel, params INinjectModule[] moduleList)
        {
            this._coreKernel = kernel;
            this._coreKernel.Load(moduleList);
            this.SetupComponents();
        }

        #endregion

        [ExcludeFromCodeCoverage]
        public T GetService<T>()
        {
            return (T)this.GetServiceByType(typeof(T), "NoToken");
        }

        [ExcludeFromCodeCoverage]
        public T GetService<T>(string token)
        {
            return (T)this.GetServiceByType(typeof(T), token);
        }

        [ExcludeFromCodeCoverage]
        public object GetServiceByType(Type type)
        {
            return this.GetServiceByType(type, "NoToken");
        }

        public object GetServiceByType(Type type, string token)
        {
            return _coreKernel.Get(type, new Parameter("parameterName", token, false));
        }

        #region Private Methods

        protected virtual void SetupComponents()
        {
            // By default, Ninject registers 2 MissingBindingResolvers - 
            // [1] DefaultValueBindingResolver - Can safely remove this since we don't want resolution of any type 
            //  to return a default value for that type. Bindings for all supported types should be explicitly registered.
            // [2] SelfBindingResolver - This is needed but we will register our own SelfBindingResolver.
            // Ref- https://github.com/ninject/ninject/blob/master/src/Ninject/StandardKernel.cs

            // Order is important here
            _coreKernel.Components.RemoveAll<IMissingBindingResolver>();
            _coreKernel.Components.Add<IMissingBindingResolver, CustomSelfBindingResolver>();
            _coreKernel.Components.Add<IMissingBindingResolver, FallbackResolver>();

            // Constructor Scoring Overriden Implementation
            _coreKernel.Components.Remove<Ninject.Selection.Heuristics.IConstructorScorer, Ninject.Selection.Heuristics.StandardConstructorScorer>();
            _coreKernel.Components.Add<Ninject.Selection.Heuristics.IConstructorScorer, Heuristics.ConstructorScoring>();

            // Enable Property Injection
            _coreKernel.Components.Remove<IInjectionHeuristic, StandardInjectionHeuristic>();
            _coreKernel.Components.Add<IInjectionHeuristic, Heuristics.PropertyInjector>();
        }

        # endregion
    }
}
