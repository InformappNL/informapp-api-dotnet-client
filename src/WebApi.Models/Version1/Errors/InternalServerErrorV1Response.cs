using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors
{
    /// <summary>
    /// Version 1 internal server error response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class InternalServerErrorV1Response
    {
        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("InternalServerError")]
        public string Message { get; set; }
    }
}
