using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2.EnvironmentOAuth2Token
{
    /// <summary>
    /// Environment OAuth token request
    /// </summary>
    [Anonymous]
    [ContentType(ContentType.FormUrlEncoded)]
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(OAuth2V1Constants.EnvironmentTokenRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(EnvironmentOAuth2TokenV1ResponseBadRequest))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class EnvironmentOAuth2TokenV1Request : BaseRequest,
        IRequest<EnvironmentOAuth2TokenV1Response>
    {
        /// <summary>
        /// Grant type
        /// 
        /// Supported values: password
        /// </summary>
        [AllowedValues(OAuth2V1Constants.GrantTypes.Password)]
        [BodyParameter]
        [DataMember(Name = OAuth2V1Constants.Parameters.GrantType)]
        [ExampleValue(OAuth2V1Constants.GrantTypes.Password)]
        [Required]
        public string GrantType { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [BodyParameter]
        [DataMember(Name = OAuth2V1Constants.Parameters.UserName)]
        [ExampleValue("JohnDoe")]
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [BodyParameter]
        [DataMember(Name = OAuth2V1Constants.Parameters.Password)]
        [DataType(DataType.Password)]
        [ExampleValue("mBoiWXSnLE9H7eU9mjT9whK5LP8KBWKX")]
        [MinLength(OAuth2V1Constants.PasswordMinLength)]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Environment
        /// </summary>
        [BodyParameter]
        [DataMember(Name = OAuth2V1Constants.Parameters.Environment)]
        [ExampleValue("World")]
        [Required]
        public string Environment { get; set; }
    }
}
