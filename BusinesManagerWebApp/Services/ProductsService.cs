using BusinesManagerWebApp.Models;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinesManagerWebApp.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IBusinessManagerClient _clientHelper;
        private readonly IConfigurationSection _config;

        public ProductsService(IConfiguration configuration, IBusinessManagerClient clientHelper)
        {
            _config = configuration.GetSection("BusinessManagerApi");
            _clientHelper = clientHelper;
        }

        public async Task CreateProduct(Products product)
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:CreateProduct"));

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                await _clientHelper.PostAsync<Products>(uri, product);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }

        public async Task DeleteProduct(Guid id)
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:DeleteProduct"), id);

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                await _clientHelper.DeleteAsync<Products>(uri);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }

        public async Task<IList<Products>> GetAllProducts()
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:GetAllProducts"));

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                return await _clientHelper.GetAsync<IList<Products>>(uri);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }

        public async Task<Products> GetProductById(Guid id)
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:GetProductById"), id);

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                return await _clientHelper.GetAsync<Products>(uri);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }

        public async Task UpdateProduct(Products product)
        {
            //Logger.Debug(this, $"GetContainerTypes() parentId={parentTypeId}");
            try
            {
                string uri = string.Format(_config.GetValue<string>("Uri:UpdateProduct"), product.Id);

                //Logger.Debug(this, $"GetContainerTypes() ContainerValidTypes uri={uri}");
                await _clientHelper.PutAsync<Products>(uri, product);
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"Error getting Container types from in Web Api", ex);
                throw;
            }
        }
    }
}
