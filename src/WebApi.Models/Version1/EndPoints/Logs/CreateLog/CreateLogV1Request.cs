﻿using Informapp.InformSystem.WebApi.Models.DataAnnotations;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Errors;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Logs.CreateLog
{
    /// <summary>
    /// Create log request
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    [HttpMethod(HttpMethod.Post)]
    [Path(LogV1Constants.CreateRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class CreateLogV1Request : BaseRequest,
        IRequest<CreateLogV1Response>
    {
        internal const int MaxItems = 10;
        internal const int MinItems = 1;

        /// <summary>
        /// Log entries
        /// </summary>
        [BodyParameter]
        [DataMember]
        [MaxItems(MaxItems)]
        [MinItems(MinItems)]
        [Required]
        public IReadOnlyList<CreateLogV1RequestLog> Logs { get; set; }
    }
}
