using BusinesManagerWebApp.Models;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinesManagerWebApp.Services
{
    public class ClientsClient : IClientsClient
    {
        private readonly IBusinessManagerClient _clientHelper;
        private readonly IConfigurationSection _config;

        public ClientsClient(IConfiguration configuration, IBusinessManagerClient clientHelper)
        {
            _config = configuration.GetSection("BusinessManagerApi");
            _clientHelper = clientHelper;
        }


        /// <summary>
        /// Get a list of clients from database
        /// </summary>
        /// <param></param>
        /// <returns>List of clients</returns>
        public async Task<IList<Clients>> GetAllClients()
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                    string uri = string.Format(_config.GetValue<string>("Uri:GetAllClients"));

                    //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                    return await _clientHelper.GetAsync<IList<Clients>>(uri);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }
    }
}
