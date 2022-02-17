using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.DeleteAppUser
{
    /// <summary>
    /// Delete app user response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class DeleteAppUserV1Response : BaseResponse
    {

    }
}
