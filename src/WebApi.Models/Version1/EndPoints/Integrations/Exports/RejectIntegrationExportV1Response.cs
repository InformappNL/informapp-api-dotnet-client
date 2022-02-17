using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports
{
    /// <summary>
    /// Reject integration export response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class RejectIntegrationExportV1Response : BaseResponse
    {

    }
}
