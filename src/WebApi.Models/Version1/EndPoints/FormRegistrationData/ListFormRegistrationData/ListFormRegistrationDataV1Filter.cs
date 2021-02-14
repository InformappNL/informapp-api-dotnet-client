using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Filters;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData.ListFormRegistrationData
{
    /// <summary>
    /// List form registration data request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationDataV1Filter
    {
        /// <summary>
        /// Filter records by form registration id
        /// </summary>
        [DataMember]
        public IdV1Filter FormRegistrationId { get; set; }

        /// <summary>
        /// Filter records by form id
        /// </summary>
        [DataMember]
        public IdV1Filter FormId { get; set; }
    }
}
