using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Converters;
using ConnectedDevelopment.InformSystem.WebApi.Client.Cryptography;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Files;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Files
{
    /// <summary>
    /// Upload file response mapper class for version 1 upload responses
    /// </summary>
    /// <typeparam name="TRequest">The type of request</typeparam>
    /// <typeparam name="TResponse">The type of response</typeparam>
    public class UploadFileV1ResponseMapper<TRequest, TResponse> : IUploadFileResponseMapper<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly bool _mappable = typeof(IUploadFileV1Response).IsAssignableFrom(typeof(TResponse));

        private readonly IConverter<FileV1HashAlgorithm?, HashAlgorithmKind?> _converter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileV1ResponseMapper{TRequest, TResponse}"/> class.
        /// </summary>
        public UploadFileV1ResponseMapper(
            IConverter<FileV1HashAlgorithm?, HashAlgorithmKind?> converter)
        {
            Argument.NotNull(converter, nameof(converter));

            _converter = converter;
        }

        /// <summary>
        /// Map response to the upload file response
        /// </summary>
        /// <param name="response">The response</param>
        /// <returns>true if the source response was successfully mapped to the destination response; otherwise, false.</returns>
        public bool Map(ApiResponse<TResponse> response)
        {
            Argument.NotNull(response, nameof(response));

            bool mapped = false;

            if (_mappable == true)
            {
                var model = response.Model as IUploadFileV1Response;

                Require.NotNull(model, nameof(model));

                if (model.Algorithm.HasValue == true &&
                    model.Algorithm.Value != FileV1HashAlgorithm.None)
                {
                    var algorithm = _converter.Convert(model.Algorithm)
                        .ThrowIfNoValue()
                        .Value;

                    response.UploadFile.Algorithm = algorithm;
                    response.UploadFile.Hash = model.Hash;
                }

                response.UploadFile.Size = model.Size;

                mapped = true;
            }

            return mapped;
        }
    }
}
