﻿using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationAttachments.Download
{
    /// <summary>
    /// Download data source file request
    /// </summary>
    [Accept(Accept.OctetStream)]
    [DataContract(Namespace = Version1Constants.Namespace)]
    [DownloadFileRequest]
    [HttpMethod(HttpMethod.Get)]
    [Path(FormRegistrationAttachmentV1Constants.DownloadRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class DownloadFormRegistrationAttachmentV1Request : BaseRequest,
        IRequest<DownloadFormRegistrationAttachmentV1Response>
    {
        /// <summary>
        /// Form Registration Attachment Id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "D3B00DDE-27F5-448B-817D-776D3073E04D")]
        [IgnoreDataMember]
        [PathParameter]
        [Required]
        public Guid? FormRegistrationAttachmentId { get; set; }
    }
}
