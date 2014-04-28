using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Activation;

namespace InstanceLocator.FakesResolver.Exceptions
{
    /// <summary>
    /// Helps build exceptions from Ninject specific entities.
    /// </summary>
    static class ExceptionBuilder
    {
        /// <summary>
        /// Get all information related to current resolution request whihc lead to the exception.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        public static ResolutionFailedException GetActivationException(IContext requestContext)
        {
            var targetRequest = BuildTargetRequest(requestContext);

            string msg = string.Format("InstanceLocator : Unable to process request for {0} which is of type {1}",
                                 targetRequest.ParameterName, targetRequest.InstanceType);

            var resolveExcp = new ResolutionFailedException(msg);
            resolveExcp.InstanceRequest = targetRequest;
            return resolveExcp;
        }

        private static InstanceRequest BuildTargetRequest(IContext requestContext)
        {
            if (requestContext == null)
                return null;

            var targetRequest = new InstanceRequest();

            targetRequest.InstanceType = requestContext.Request.Service;
            targetRequest.ParameterName = Helpers.ContextHelper.GetParameterNameFromContext(requestContext);
            targetRequest.RequestDepth = requestContext.Request.Depth;
            targetRequest.ParentRequest = BuildTargetRequest(requestContext.Request.ParentContext);

            return targetRequest;
        }
    }
}