using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Net.Http;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Methods.OptionsMethod
{
    /// <summary>
    /// Options method response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class OptionsMethodV1Response : BaseResponse
    {
        /// <summary>
        /// Method
        /// </summary>
        [DataMember]
        [ExampleValue(nameof(HttpMethod.Options))]
        public string Method { get; set; }
    }
}
