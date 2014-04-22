using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Selection.Heuristics;
using Ninject.Activation;
using Ninject.Planning.Directives;

namespace InstanceLocator.FakesResolver.Heuristics
{
    /// <summary>
    /// Overrides the standard constructor scorer in a way that returns a score proportional to the number of arguments.
    /// This scoring does not assign any weightage to existence of explicit bindings - we naively assume all types can be resolved at runtime.
    /// </summary>
    class ConstructorScoring : StandardConstructorScorer
    {
        public override int Score(IContext context, ConstructorInjectionDirective directive)
        {
            return directive.Targets.Length;
        }
    }
}
