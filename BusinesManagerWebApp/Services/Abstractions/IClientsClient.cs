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
    }
}
