using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BusinesManagerWebApp.Services
{
    public class ApiException : Exception
    {
        internal HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Create an ApiResponseException
        /// </summary>
        public ApiException()
        {
        }

        /// <summary>
        /// Create an ApiResponseException
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="httpStatusCode">The HttpStatusCode returned by the Api</param>
        public ApiException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            StatusCode = httpStatusCode;
        }

        /// <summary>
        /// Create an ApiResponseException
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="code">The HttpStatusCode returned by the Api</param>
        /// <param name="inner">The inner exception</param>
        public ApiException(string message, HttpStatusCode code, Exception inner) : base(message, inner)
        {
            StatusCode = code;
        }
    }
}
