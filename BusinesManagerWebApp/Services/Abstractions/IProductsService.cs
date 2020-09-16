using BusinesManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinesManagerWebApp.Services.Abstractions
{
    public interface IProductsService
    {
        /// <summary>
        /// Get a list of products from database
        /// </summary>
        /// <param></param>
        /// <returns>List of products</returns>
        Task<IList<Products>> GetAllProducts();

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single product</returns>
        Task<Products> GetProductById(Guid id);

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task UpdateProduct(Products product);

        /// <summary>
        /// Create product
        /// </summary>
        /// <param name="client"></param>
        /// <returns>No content</returns>
        Task CreateProduct(Products product);

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        Task DeleteProduct(Guid id);
    }
}
