﻿using ConnectedDevelopment.InformSystem.WebApi.Client.BearerTokenProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.BearerTokenProviders
{
    /// <summary>
    /// Decorator class for <see cref="IBearerTokenProvider{T}"/> to log to console
    /// </summary>
    public class LogToConsoleBearerTokenProviderDecorator<T> : Decorator<IBearerTokenProvider<T>>,
        IBearerTokenProvider<T>

        where T : class
    {
        private readonly IBearerTokenProvider<T> _bearerTokenProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogToConsoleBearerTokenProviderDecorator{T}"/> class.
        /// </summary>
        /// <param name="bearerTokenProvider">The instance to decorate</param>
        public LogToConsoleBearerTokenProviderDecorator(
            IBearerTokenProvider<T> bearerTokenProvider) : base(bearerTokenProvider)
        {
            Argument.NotNull(bearerTokenProvider, nameof(bearerTokenProvider));

            _bearerTokenProvider = bearerTokenProvider;
        }

        /// <summary>
        /// Get bearer token and ensure an access token is returned
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The token response</returns>
        public async Task<BearerTokenResponse> GetToken(ApiRequest request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            var context = (
                request.Credentials.Username,
                request.Context.EndPoint
            );

            string message = string.Format(
                CultureInfo.InvariantCulture,
                "{0} {1}",
                nameof(GetToken),
                context);

            Console.WriteLine(message);

            Debug.WriteLine(message);

            var tokenResponse = await _bearerTokenProvider
                .GetToken(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            return tokenResponse;
        }
    }
}
