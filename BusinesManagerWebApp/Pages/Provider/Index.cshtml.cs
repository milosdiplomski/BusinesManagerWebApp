using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesManagerWebApp.Extensions;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages.Provider
{
    public class IndexModel : PageModel
    {
        public IProviderService _providerService;

        public string AntiforgeryToken => HttpContext.GetAntiforgeryTokenForJs();

        [BindProperty]
        public IList<Models.Provider> Provider { get; set; }

        public IndexModel(IProviderService providerService)
        {
            _providerService = providerService;
        }

        public async Task OnGet()
        {
            try
            {

                //Logger.Debug(this, $"GetContainerTypes() parentId = {parentId}");

                Provider = _providerService.GetAllProviders().Result;

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

                await _providerService.DeleteProvider(id);
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
