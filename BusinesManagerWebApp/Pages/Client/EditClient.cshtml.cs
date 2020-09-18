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
    public class EditClientModel : PageModel
    {
        public IClientsClient _clientsService;

        [BindProperty]
        public Clients Client { get; set; }

        public EditClientModel(IClientsClient clientsClient)
        {
            _clientsService = clientsClient;
        }

        public async Task OnGet(Guid id)
        {
            Client = await _clientsService.GetClientById(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _clientsService.UpdateClient(Client);

            return RedirectToPage("Index");
        }
    }
}
