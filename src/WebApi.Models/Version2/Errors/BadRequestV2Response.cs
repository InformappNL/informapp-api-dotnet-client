using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Constants;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Errors
{
    /// <summary>
    /// Version 2 bad request response
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public partial class BadRequestV2Response
    {
        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        [ExampleValue("The request is invalid.")]
        public string Message { get; set; }

        /// <summary>
        /// Dictionary of string and collection of string, containing field names and their errors
        /// </summary>
        [DataMember]
        [ExampleMemberProvider(typeof(BadRequestV2Response), nameof(ModelState))]
        public IReadOnlyDictionary<string, IEnumerable<string>> ModelState { get; set; }
    }
}
