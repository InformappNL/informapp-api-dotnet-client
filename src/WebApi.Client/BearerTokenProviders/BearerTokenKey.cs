using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.BearerTokenProviders
{
    /// <summary>
    /// DTO class to act as key for caching bearer tokens
    /// </summary>
    public class BearerTokenKey
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BearerTokenKey"/> class.
        /// </summary>
        /// <param name="endPoint">The endpoint</param>
        /// <param name="username">The username</param>
        /// <exception cref="ArgumentNullException"><paramref name="endPoint"/> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="username"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="username"/> is empty</exception>
        public BearerTokenKey(Uri endPoint, string username)
        {
            Argument.NotNull(endPoint, nameof(endPoint));
            Argument.NotNullOrEmpty(username, nameof(username));

            EndPoint = endPoint;

            UserName = username;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BearerTokenKey"/> class.
        /// </summary>
        /// <param name="endPoint">The endpoint</param>
        /// <param name="username">The username</param>
        /// <param name="environment">The environment</param>
        /// <exception cref="ArgumentNullException"><paramref name="endPoint"/> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="username"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="username"/> is empty</exception>
        /// <exception cref="ArgumentNullException"><paramref name="environment"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="environment"/> is empty</exception>
        public BearerTokenKey(Uri endPoint, string username, string environment)
        {
            Argument.NotNull(endPoint, nameof(endPoint));
            Argument.NotNullOrEmpty(username, nameof(username));
            Argument.NotNullOrEmpty(environment, nameof(environment));

            EndPoint = endPoint;

            UserName = username;

            Environment = environment;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BearerTokenKey"/> class.
        /// </summary>
        /// <param name="endPoint">The endpoint</param>
        /// <param name="username">The username</param>
        /// <param name="environment">The environment</param>
        /// <param name="impersonateUserId">The user id to impersonate</param>
        /// <exception cref="ArgumentNullException"><paramref name="endPoint"/> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="username"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="username"/> is empty</exception>
        /// <exception cref="ArgumentNullException"><paramref name="environment"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="environment"/> is empty</exception>
        /// <exception cref="ArgumentNullException"><paramref name="impersonateUserId"/> is null</exception>
        public BearerTokenKey(Uri endPoint, string username, string environment, Guid? impersonateUserId)
        {
            Argument.NotNull(endPoint, nameof(endPoint));
            Argument.NotNullOrEmpty(username, nameof(username));
            Argument.NotNullOrEmpty(environment, nameof(environment));
            Argument.NotNull(impersonateUserId, nameof(impersonateUserId));

            EndPoint = endPoint;

            UserName = username;

            Environment = environment;

            ImpersonateUserId = impersonateUserId;
        }

        /// <summary>
        /// The end point
        /// </summary>
        public Uri EndPoint { get; }

        /// <summary>
        /// The username
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// The environment
        /// </summary>
        public string Environment { get; }

        /// <summary>
        /// The user id to impersonate
        /// </summary>
        public Guid? ImpersonateUserId { get; }
    }
}
