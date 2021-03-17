using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.RevokeInstruction
{
    /// <summary>
    /// Revoke form instruction response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class RevokeInformAppFormInstructionV1Response : BaseResponse
    {

    }
}
