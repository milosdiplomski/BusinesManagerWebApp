using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesManagerWebApp.Extensions;
using BusinesManagerWebApp.Models;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages.Client
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public IClientsClient _clientService;

        public string AntiforgeryToken => HttpContext.GetAntiforgeryTokenForJs();

        [BindProperty]
        public IList<Clients> Clients { get; set; }

        public IndexModel(IClientsClient clientsClient)
        {
            _clientService = clientsClient;
        }
        
        public async Task OnGet()
        {
            try
            {

                //Logger.Debug(this, $"GetContainerTypes() parentId = {parentId}");

                Clients = _clientService.GetAllClients().Result;

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

                await _clientService.DeleteClient(id);
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
