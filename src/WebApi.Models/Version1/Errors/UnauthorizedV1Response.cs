using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors
{
    /// <summary>
    /// Version 1 unauthorized response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class UnauthorizedV1Response
    {
        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("Unauthorized")]
        public string Message { get; set; }
    }
}
