using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesManagerWebApp.Extensions;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        public IProductsService _productService;

        [BindProperty]
        public IList<Models.Products> Products { get; set; }

        public string AntiforgeryToken => HttpContext.GetAntiforgeryTokenForJs();

        public IndexModel(IProductsService productService)
        {
            _productService = productService;
        }

        public async Task OnGet()
        {
            try
            {

                //Logger.Debug(this, $"GetContainerTypes() parentId = {parentId}");

                Products = _productService.GetAllProducts().Result;

            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"GetContainerTypes() Error={ex.Message}", ex);
                //ErrorMessage = "Error getting Container Types for the selected Container";
                throw;
            }
        }

        public async Task<IActionResult> OnDelete(Guid id)
        {
            try
            {

                //Logger.Debug(this, $"GetContainerTypes() parentId = {parentId}");

                await _productService.DeleteProduct(id);
                return new NoContentResult();

            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"GetContainerTypes() Error={ex.Message}", ex);
                //ErrorMessage = "Error getting Container Types for the selected Container";
                return new StatusCodeResult(500);
            }
        }
    }
}
