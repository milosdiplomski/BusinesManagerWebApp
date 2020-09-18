using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesManagerWebApp.Models;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages.Provider
{
    public class CreateProviderModel : PageModel
    {
        public IProviderService _providerService;

        [BindProperty]
        public Models.Provider Provider{ get; set; }

        public CreateProviderModel(IProviderService providerService)
        {
            _providerService = providerService;
        }

        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _providerService.CreateProvider(Provider);

            return RedirectToPage("Index");
        }
    }
}
