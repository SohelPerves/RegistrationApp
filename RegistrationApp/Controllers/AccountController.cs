using Microsoft.AspNetCore.Mvc;
using RegistrationApp.Data;
using RegistrationApp.Models;
using RegistrationApp.Services;

namespace RegistrationApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public AccountController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password 
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                await _emailService.SendEmailAsync(user.Email, "Welcome!", $"Hi {user.Name}, your registration was successful.");

                return RedirectToAction("RegisterSuccess");
            }

            return View(model);
        }

        public IActionResult RegisterSuccess() => View();
    }
}
