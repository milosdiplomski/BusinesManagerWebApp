using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinesManagerWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusinesManagerWebApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserRegistrationModel UserRegistrationModel { get; set; }
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public RegisterModel(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _mapper.Map<User>(UserRegistrationModel);
            var result = await _userManager.CreateAsync(user, UserRegistrationModel.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return Page();
            }
            await _userManager.AddToRoleAsync(user, "Visitor");

            return RedirectToPage("../Index");
        }
    }
}
