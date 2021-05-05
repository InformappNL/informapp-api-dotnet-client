using Informapp.InformSystem.WebApi.Models.Arguments;
using System;
using System.Net;

namespace Informapp.InformSystem.WebApi.Models.Responses
{
    /// <summary>
    /// Indicates per <see cref="HttpStatusCode"/> the model type
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class ResponseAttribute : Attribute
    {
        /// <summary>
        /// The status code
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// The model type
        /// </summary>
        public Type Model { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseAttribute"/> class.
        /// </summary>
        public ResponseAttribute(
            HttpStatusCode statusCode,
            Type model)
        {
            Argument.NotNull(model, nameof(model));

            if (IsValid(statusCode) == false)
            {
                throw new ArgumentException("Unsupported value", nameof(statusCode));
            }

            StatusCode = statusCode;

            Model = model;
        }
#pragma warning disable CA1502 // Rewrite or refactor the code to decrease its complexity.
        private static bool IsValid(HttpStatusCode statusCode)
#pragma warning restore CA1502
        {
            switch (statusCode)
            {
                case HttpStatusCode.Continue:
                case HttpStatusCode.SwitchingProtocols:
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.NonAuthoritativeInformation:
                case HttpStatusCode.NoContent:
                case HttpStatusCode.ResetContent:
                case HttpStatusCode.PartialContent:
                case HttpStatusCode.MultipleChoices:
                //case HttpStatusCode.Ambiguous:
                case HttpStatusCode.MovedPermanently:
                //case HttpStatusCode.Moved:
                case HttpStatusCode.Found:
                //case HttpStatusCode.Redirect:
                case HttpStatusCode.SeeOther:
                //case HttpStatusCode.RedirectMethod:
                case HttpStatusCode.NotModified:
                case HttpStatusCode.UseProxy:
                case HttpStatusCode.Unused:
                case HttpStatusCode.TemporaryRedirect:
                //case HttpStatusCode.RedirectKeepVerb:
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.PaymentRequired:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.MethodNotAllowed:
                case HttpStatusCode.NotAcceptable:
                case HttpStatusCode.ProxyAuthenticationRequired:
                case HttpStatusCode.RequestTimeout:
                case HttpStatusCode.Conflict:
                case HttpStatusCode.Gone:
                case HttpStatusCode.LengthRequired:
                case HttpStatusCode.PreconditionFailed:
                case HttpStatusCode.RequestEntityTooLarge:
                case HttpStatusCode.RequestUriTooLong:
                case HttpStatusCode.UnsupportedMediaType:
                case HttpStatusCode.RequestedRangeNotSatisfiable:
                case HttpStatusCode.ExpectationFailed:
                case HttpStatusCode.UpgradeRequired:
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.NotImplemented:
                case HttpStatusCode.BadGateway:
                case HttpStatusCode.ServiceUnavailable:
                case HttpStatusCode.GatewayTimeout:
                case HttpStatusCode.HttpVersionNotSupported:
                    return true;
                default:
                    return false;
            }
        }
    }
}
