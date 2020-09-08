using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesManagerWebApp.Models;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages.Client
{
    public class IndexModel : PageModel
    {
        public IClientsClient _clientsClient;

        [BindProperty]
        public IList<Clients> Clients { get; set; }

        public IndexModel(IClientsClient clientsClient)
        {
            _clientsClient = clientsClient;
        }
        
        public async Task OnGet()
        {
            try
            {

                //Logger.Debug(this, $"GetContainerTypes() parentId = {parentId}");

                var clients = _clientsClient.GetAllClients().Result;

                //return clients;
            }
            catch (Exception ex)
            {
                //Logger.Error(this, $"GetContainerTypes() Error={ex.Message}", ex);
                //ErrorMessage = "Error getting Container Types for the selected Container";
                throw;
            }
        }
    }
}
