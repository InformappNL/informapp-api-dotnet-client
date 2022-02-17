using System;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Exceptions
{
    /// <summary>
    /// Represents errors that occur during API requests
    /// </summary>
    [Serializable]
    public class ApiClientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientException"/> class.
        /// </summary>
        public ApiClientException() : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientException"/> class with a specified error.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApiClientException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientException"/> with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ApiClientException(string message, Exception innerException) : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected ApiClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
