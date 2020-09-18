using BusinesManagerWebApp.Models;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinesManagerWebApp.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IBusinessManagerClient _clientHelper;
        private readonly IConfigurationSection _config;

        public ProviderService(IConfiguration configuration, IBusinessManagerClient clientHelper)
        {
            _config = configuration.GetSection("BusinessManagerApi");
            _clientHelper = clientHelper;
        }

        public async Task CreateProvider(Provider client)
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:CreateProvider"));

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                await _clientHelper.PostAsync<Provider>(uri, client);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }

        public async Task DeleteProvider(Guid id)
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:DeleteProvider"), id);

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                await _clientHelper.DeleteAsync<Provider>(uri);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }

        public async Task<IList<Provider>> GetAllProviders()
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:GetAllProviders"));

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                return await _clientHelper.GetAsync<IList<Provider>>(uri);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }

        public async Task<Provider> GetProviderById(Guid id)
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:GetProviderById"), id);

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                return await _clientHelper.GetAsync<Provider>(uri);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }

        public async Task UpdateProvider(Provider client)
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:UpdateProvider"), client.Id);

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                await _clientHelper.PutAsync<Provider>(uri, client);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }
    }
}
