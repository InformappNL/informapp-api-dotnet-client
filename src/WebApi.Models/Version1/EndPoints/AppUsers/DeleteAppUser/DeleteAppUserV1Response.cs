using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.DeleteAppUser
{
    /// <summary>
    /// Delete app user response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class DeleteAppUserV1Response : BaseResponse
    {

    }
}
