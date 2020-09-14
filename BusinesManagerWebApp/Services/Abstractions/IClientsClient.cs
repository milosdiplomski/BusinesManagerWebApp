using BusinesManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinesManagerWebApp.Services.Abstractions
{
    public interface IClientsClient
    {
        /// <summary>
        /// Get a list of clients from database
        /// </summary>
        /// <param></param>
        /// <returns>List of clients</returns>
        Task<IList<Clients>> GetAllClients();

        /// <summary>
        /// Get client by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single client</returns>
        Task<Clients> GetClientById(Guid id);

        /// <summary>
        /// Update client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task UpdateClient(Clients client);

        /// <summary>
        /// Create client
        /// </summary>
        /// <param name="client"></param>
        /// <returns>No content</returns>
        Task CreateClient(Clients client);

        /// <summary>
        /// Delete client
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        Task DeleteClient(Guid id);
    }
}
