using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples
{
    internal interface IExample
    {
        Task Run(CancellationToken cancellationToken);
    }
}
