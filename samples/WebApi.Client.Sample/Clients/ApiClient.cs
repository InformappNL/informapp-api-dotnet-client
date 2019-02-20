using Informapp.InformSystem.WebApi.Client.Sample.Arguments;

namespace Informapp.InformSystem.WebApi.Client.Sample.Clients
{
    /// <summary>
    /// Base class for api client facade providing access to factory instance
    /// </summary>
    internal abstract class ApiClient
    {
        protected static IApiClientFactory _factory = new ApiClientFactory();

        /// <summary>
        /// Set factory to use
        /// </summary>
        /// <param name="factory">The factory</param>
        public static void SetFactory(IApiClientFactory factory)
        {
            Argument.NotNull(factory, nameof(factory));

            _factory = factory;
        }
    }
}
