using BusinesManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinesManagerWebApp.Services.Abstractions
{
    public interface IProviderService
    {
        /// <summary>
        /// Get a list of Provider from database
        /// </summary>
        /// <param></param>
        /// <returns>List of Providers</returns>
        Task<IList<Provider>> GetAllProviders();

        /// <summary>
        /// Get Provider by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single Provider</returns>
        Task<Provider> GetProviderById(Guid id);

        /// <summary>
        /// Update Provider
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task UpdateProvider(Provider client);

        /// <summary>
        /// Create Provider
        /// </summary>
        /// <param name="client"></param>
        /// <returns>No content</returns>
        Task CreateProvider(Provider client);

        /// <summary>
        /// Delete Provider
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        Task DeleteProvider(Guid id);
    }
}
