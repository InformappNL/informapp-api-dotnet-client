using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Errors;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version2.EndPoints.OAuth2.OAuth2Token
{
    /// <summary>
    /// OAuth token request
    /// </summary>
    [Anonymous]
    [ContentType(ContentType.FormUrlEncoded)]
    [DataContract(Namespace = Version2Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(OAuth2V2Constants.TokenRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(OAuth2TokenV2ResponseBadRequest))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV2Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV2Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV2Response))]
    public class OAuth2TokenV2Request : BaseRequest,
        IRequest<OAuth2TokenV2Response>
    {
        /// <summary>
        /// Grant type
        /// 
        /// Supported values: password
        /// </summary>
        [AllowedValues(OAuth2V2Constants.GrantTypes.Password)]
        [BodyParameter]
        [DataMember(Name = OAuth2V2Constants.Parameters.GrantType)]
        [ExampleValue(OAuth2V2Constants.GrantTypes.Password)]
        [Required]
        public string GrantType { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [BodyParameter]
        [DataMember(Name = OAuth2V2Constants.Parameters.UserName)]
        [ExampleValue("JohnDoe")]
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [BodyParameter]
        [DataMember(Name = OAuth2V2Constants.Parameters.Password)]
        [DataType(DataType.Password)]
        [ExampleValue("mBoiWXSnLE9H7eU9mjT9whK5LP8KBWKX")]
        [MinLength(OAuth2V2Constants.PasswordMinLength)]
        [Required]
        public string Password { get; set; }
    }
}
