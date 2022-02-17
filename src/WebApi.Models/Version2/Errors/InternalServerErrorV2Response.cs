using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Errors
{
    /// <summary>
    /// Version 2 internal server error response
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class InternalServerErrorV2Response
    {
        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("InternalServerError")]
        public string Message { get; set; }
    }
}
