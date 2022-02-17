using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Methods.PatchMethod
{
    /// <summary>
    /// Patch method response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class PatchMethodV1Response : BaseResponse
    {
        /// <summary>
        /// Method
        /// </summary>
        [DataMember]
        [ExampleValue(nameof(HttpMethod.Patch))]
        public string Method { get; set; }
    }
}
