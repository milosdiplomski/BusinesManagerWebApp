using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesManagerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages
{
    public class ClientsModel : PageModel
    {

        [BindProperty]
        public Clients Clients { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //await _productService.CreateProduct(Product);

            return RedirectToPage("Index");
        }

        public void OnDelete()
        {

        }

        public void OnPut()
        {

        }
    }
}
