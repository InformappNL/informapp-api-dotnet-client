using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Errors;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.DataSources.DownloadDataSource
{
    /// <summary>
    /// Download data source file request
    /// </summary>
    [Accept(Accept.OctetStream)]
    [DataContract(Namespace = Version1Constants.Namespace)]
    [DownloadFileRequest]
    [HttpMethod(HttpMethod.Get)]
    [Path(DataSourceV1Constants.DownloadRoute)]
    [Response(HttpStatusCode.BadRequest, typeof(BadRequestV1Response))]
    [Response(HttpStatusCode.Forbidden, typeof(ForbiddenV1Response))]
    [Response(HttpStatusCode.InternalServerError, typeof(InternalServerErrorV1Response))]
    [Response(HttpStatusCode.Unauthorized, typeof(UnauthorizedV1Response))]
    public class DownloadDataSourceV1Request : BaseRequest,
        IRequest<DownloadDataSourceV1Response>
    {
        /// <summary>
        /// Data source Id
        /// </summary>
        [ExampleString(ExampleStringKind.Guid, "C61003F7-3D55-482F-9565-60A6B38AABAD")]
        [IgnoreDataMember]
        [PathParameter]
        [Required]
        public Guid? DataSourceId { get; set; }
    }
}
