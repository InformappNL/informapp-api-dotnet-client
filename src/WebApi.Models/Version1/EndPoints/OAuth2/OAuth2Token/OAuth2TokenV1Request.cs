using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.OAuth2.OAuth2Token
{
    /// <summary>
    /// OAuth token request
    /// </summary>
    [Anonymous]
    [ContentType(ContentType.FormUrlEncoded)]
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(OAuth2V1Constants.TokenRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(OAuth2TokenV1ResponseBadRequest))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class OAuth2TokenV1Request : BaseRequest,
        IRequest<OAuth2TokenV1Response>
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
    }
}
