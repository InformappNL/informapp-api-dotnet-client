using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.Errors
{
    /// <summary>
    /// Version 1 bad request response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public partial class BadRequestV1Response
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
        [ExampleMemberProvider(typeof(BadRequestV1Response), nameof(ModelState))]
        public IDictionary<string, IEnumerable<string>> ModelState { get; set; }
    }
}
