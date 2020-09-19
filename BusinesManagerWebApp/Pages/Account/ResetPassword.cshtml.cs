using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesManagerWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages.Account
{
    public class ResetPasswordModel : PageModel
    {

        private readonly UserManager<User> _userManager;
        public Models.ResetPasswordModel ResetPassModel { get; set; }

        public ResetPasswordModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult OnGet(string token, string email)
        {
            ResetPassModel = new Models.ResetPasswordModel { Token = token, Email = email };
            return Page();
        }

        public async Task<IActionResult> OnPost(Models.ResetPasswordModel resetPassModel)
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _userManager.FindByEmailAsync(resetPassModel.Email);
            if (user == null)
                RedirectToPage("/Account/ResetPasswordConfirmation");

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassModel.Token, resetPassModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return Page();
            }
            return RedirectToPage("/Account/ResetPasswordConfirmation");
        }
    }
}
