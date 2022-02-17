using ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations;
using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors;
using System.ComponentModel;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.DownloadTestFile
{
    /// <summary>
    /// Download test file request
    /// </summary>
    [Accept(Accept.OctetStream)]
    [DataContract(Namespace = Version1Constants.Namespace)]
    [DownloadFileRequest]
    [HttpMethod(HttpMethod.Get)]
    [Path(TestFileV1Constants.DownloadRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class DownloadTestFileV1Request : BaseRequest,
        IRequest<DownloadTestFileV1Response>
    {
        private const DownloadTestFileV1RequestKind DefaultKind = DownloadTestFileV1RequestKind.Txt;

        /// <summary>
        /// Kind
        /// </summary>
        [DataMember]
        [DefaultValue(DefaultKind)]
        [EnumValidation(typeof(DownloadTestFileV1RequestKind))]
        [ExampleValue(DefaultKind)]
        [QueryParameter]
        public DownloadTestFileV1RequestKind? Kind { get; set; } = DefaultKind;
    }
}
