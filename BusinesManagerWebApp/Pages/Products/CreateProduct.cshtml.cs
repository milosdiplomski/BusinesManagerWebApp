using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesManagerWebApp.Models;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages.Products
{
    public class CreateProductModel : PageModel
    {
        public IProductsService _productsService;

        [BindProperty]
        public Models.Products Product { get; set; }

        public CreateProductModel(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productsService.CreateProduct(Product);

            return RedirectToPage("Index");
        }
    }
}
