using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages.Provider
{
    public class EditProviderModel : PageModel
    {
        public IProviderService _providerService;

        [BindProperty]
        public Models.Provider Provider { get; set; }

        public EditProviderModel(IProviderService providerService)
        {
            _providerService = providerService;
        }

        public async Task OnGet(Guid id)
        {
            Provider = await _providerService.GetProviderById(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _providerService.UpdateProvider(Provider);

            return RedirectToPage("Index");
        }
    }
}
