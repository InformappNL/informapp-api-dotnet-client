using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version2.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version2.Errors
{
    /// <summary>
    /// Version 1 forbidden response
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class ForbiddenV2Response
    {
        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("Forbidden")]
        public string Message { get; set; }
    }
}
