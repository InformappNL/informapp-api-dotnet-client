using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmailFiles.Download
{
    /// <summary>
    /// Download form registration email file request
    /// </summary>
    [Accept(Accept.OctetStream)]
    [DataContract(Namespace = Version1Constants.Namespace)]
    [DownloadFileRequest]
    [HttpMethod(HttpMethod.Get)]
    [Path(FormRegistrationEmailFileV1Constants.DownloadRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class DownloadFormRegistrationEmailFileV1Request : BaseRequest,
        IRequest<DownloadFormRegistrationEmailFileV1Response>
    {
        /// <summary>
        /// Form Registration Email File Id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "6A799CB1-D22D-4307-99C1-1D8CE3F9FC37")]
        [IgnoreDataMember]
        //[PathParameter]
        [Required]
        public Guid? FormRegistrationEmailFileId { get; set; }
    }
}
