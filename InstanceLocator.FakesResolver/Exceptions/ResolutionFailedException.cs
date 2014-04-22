using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace InstanceLocator.FakesResolver.Exceptions
{
    /// <summary>
    /// Exception when a request for resolution is made for a type for which self binding has failed and no explcit provider exists or has been registered.
    /// </summary>
    [Serializable]
    public class ResolutionFailedException : System.Exception
    {
        /// <summary>
        /// Information about the request that caused the exception.
        /// </summary>
        public InstanceRequest InstanceRequest { get; set; }

        public ResolutionFailedException()
        {

        }

        public ResolutionFailedException(string message)
            : base(message)
        {

        }

        public ResolutionFailedException(string message, Exception inner)
            : base(message, inner)
        {

        }

        protected ResolutionFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                this.InstanceRequest = null;
            }
        }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue("InstanceRequest", GetRequestInfo(InstanceRequest));
            }
        }

        private string GetRequestInfo(InstanceRequest req)
        {
            return "<Serialized recursed req goes here.>"; 
        }
    }

    /// <summary>
    /// Encapsulates information about the requested type.
    /// </summary>
    public class InstanceRequest
    {
        /// <summary>
        /// The type for which an instance was requested. This request could have been explicit or implicit(resolved as a dependency for some other type)
        /// </summary>
        public Type InstanceType { get; set; }

        /// <summary>
        /// Name of the target for the requested type. 
        /// Depending on the context, it should either be the named token for this request or the constructor parameter/property name where resolution was requested.
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// An integer representing the depth at which the current resolution is being processed.
        /// </summary>
        public int RequestDepth { get; set; }

        /// <summary>
        /// Information about parent request.
        /// </summary>
        public InstanceRequest ParentRequest { get; set; }
    }
}