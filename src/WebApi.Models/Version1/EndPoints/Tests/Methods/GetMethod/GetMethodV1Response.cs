using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Methods.GetMethod
{
    /// <summary>
    /// Get method response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class GetMethodV1Response : BaseResponse
    {
        /// <summary>
        /// Method
        /// </summary>
        [DataMember]
        [ExampleValue(nameof(HttpMethod.Get))]
        public string Method { get; set; }
    }
}
