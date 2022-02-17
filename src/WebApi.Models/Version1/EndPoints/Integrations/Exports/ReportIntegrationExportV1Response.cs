using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports
{
    /// <summary>
    /// Report integration export response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ReportIntegrationExportV1Response : BaseResponse
    {

    }
}
