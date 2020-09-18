using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesManagerWebApp.Models;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages.Client
{
    [Authorize]
    public class CreateClientModel : PageModel
    {
        public IClientsClient _clientsService;

        [BindProperty]
        public Clients Client { get; set; }

        public CreateClientModel(IClientsClient clientsClient)
        {
            _clientsService = clientsClient;
        }

        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _clientsService.CreateClient(Client);

            return RedirectToPage("Index");
        }
    }
}
