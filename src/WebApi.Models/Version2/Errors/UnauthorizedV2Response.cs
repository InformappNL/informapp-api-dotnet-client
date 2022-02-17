using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Errors
{
    /// <summary>
    /// Version 2 unauthorized response
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class UnauthorizedV2Response
    {
        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("Unauthorized")]
        public string Message { get; set; }
    }
}
