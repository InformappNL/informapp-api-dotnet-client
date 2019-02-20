using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Pings
{
    /// <summary>
    /// Ping response
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class PingV1Response : BaseResponse
    {

    }
}
