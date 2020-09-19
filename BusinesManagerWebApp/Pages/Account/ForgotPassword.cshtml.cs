using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesManagerWebApp.Models;
using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        public Models.ForgotPasswordModel ForgotPassModel { get; set; }
        private readonly IEmailSender _emailSender;
        private readonly UserManager<User> _userManager;

        public ForgotPasswordModel(UserManager<User> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(Models.ForgotPasswordModel forgotPassModel)
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _userManager.FindByEmailAsync(forgotPassModel.Email);
            if (user == null)
                return RedirectToPage("/Account/ForgotPasswordConfirmation");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Page("/Account/ResetPassword", null, new { token, email = user.Email },Request.Scheme);
            var message = new Message(new string[] { "businessmanagerdiplomski@gmail.com" }, "Reset password token", callback, null);

            await _emailSender.SendEmailAsync(message);
            return RedirectToPage("/Account/ForgotPasswordConfirmation");
        }
    }
}
