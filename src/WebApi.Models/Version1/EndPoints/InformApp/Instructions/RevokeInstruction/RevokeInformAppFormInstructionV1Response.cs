using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.RevokeInstruction
{
    /// <summary>
    /// Revoke form instruction response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class RevokeInformAppFormInstructionV1Response : BaseResponse
    {

    }
}
