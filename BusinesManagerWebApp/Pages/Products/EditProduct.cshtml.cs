using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages.Products
{
    public class EditProductModel : PageModel
    {
        public IProductsService _productsService;

        [BindProperty]
        public Models.Products Product { get; set; }

        public EditProductModel(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public async Task OnGet(Guid id)
        {
            Product = await _productsService.GetProductById(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productsService.UpdateProduct(Product);

            return RedirectToPage("Index");
        }
    }
}
