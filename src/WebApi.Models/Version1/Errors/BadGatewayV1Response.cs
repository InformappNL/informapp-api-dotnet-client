using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.Errors
{
    /// <summary>
    /// Version 1 bad gateway response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class BadGatewayV1Response
    {
        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("Received an invalid response from the upstream server.")]
        public string Message { get; set; }
    }
}
