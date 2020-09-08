using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinesManagerWebApp.Services.Abstractions
{
    public interface IBusinessManagerClient
    {
        /// <summary>
        /// Generic method for HttpClient GetAsync
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="url">Url string</param>
        /// <returns>Type provided</returns>
        /// <exception cref="ApiException">The request did not return a success http response code.</exception>
        Task<T> GetAsync<T>(string url);
    }
}
