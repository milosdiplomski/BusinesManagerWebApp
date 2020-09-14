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
        /// Create client
        /// </summary>
        /// <param name="client"></param>
        /// <returns>No content</returns>
        public async Task CreateClient(Clients client)
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:CreateClient"));

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                await _clientHelper.PostAsync<Clients>(uri, client);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }

        /// <summary>
        /// Delete client
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        public async Task DeleteClient(Guid id)
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:DeleteClient"), id);

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                await _clientHelper.DeleteAsync<Clients>(uri);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
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

        /// <summary>
        /// Get client by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single client</returns>
        public async Task<Clients> GetClientById(Guid id)
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:GetClientById"), id);

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                return await _clientHelper.GetAsync<Clients>(uri);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }

        /// <summary>
        /// Update client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task UpdateClient(Clients client)
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:UpdateClient"), client.Id);

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                await _clientHelper.PutAsync<Clients>(uri, client);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }
    }
}
