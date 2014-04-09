using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Components;
using Ninject.Selection.Heuristics;
using System.Reflection;
using Ninject.Selection.Heuristics;

namespace InstanceLocator.FakesResolver.Heuristics
{
    /// <summary>
    /// Enables injection on all public properties with setter methods. 
    /// Note that this supports only public properties. To enable private properties use swtich Settings.InjectParentPrivateProperties.
    /// </summary>
    class PropertyInjector : NinjectComponent, IInjectionHeuristic
    {
        public bool ShouldInject(MemberInfo member)
        {
            var propertyInfo = member as PropertyInfo;

            if (propertyInfo != null)
                return propertyInfo.GetSetMethod(false) != null;
            
            return false;
        }
    }
}
