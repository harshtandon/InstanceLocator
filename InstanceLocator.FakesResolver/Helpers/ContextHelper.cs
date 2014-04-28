using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Activation;

namespace InstanceLocator.FakesResolver.Helpers
{
    public static class ContextHelper
    {
        public static string GetParameterNameFromContext(IContext requestContext)
        {
            if (requestContext.Request.Target == null)
            {
                var parameter = requestContext.Request.Parameters.AsEnumerable().FirstOrDefault(param => param.Name == "parameterName");
                if (parameter != null)
                    return (string)parameter.GetValue(requestContext, null);
                else
                    return "<Unknown>";
            }
            else
                return requestContext.Request.Target.Name;
        }
    }
}
