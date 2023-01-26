using System.Text;
using EFDataAccessLibrary.Models;
using Filc.Models.JWTAuthenticationModel;
using Filc.Services.Interfaces;
using Filc.ViewModel;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MimeKit.Text;
using MimeKit;
using Org.BouncyCastle.Crypto.Engines;

namespace Filc.Services
{
    public class RegistrationService : IRegistration
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public RegistrationService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<bool> Register(RegistrationModel model, bool seed=false)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
            {
                throw new Exception("User already exists!");
            }

            ApplicationUser user = new()
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User creation failed! Please check user details and try again");
            }

            if (await _roleManager.RoleExistsAsync(model.Role))
            {
                await _userManager.AddToRoleAsync(user, model.Role);
            }
            else
            {
                throw new Exception("The specified Role is not valid");
            }

            try
            {
                if (!seed)
                {
                    SendEmail(model.Email, model.Password);
                }
            }
            catch (Exception e)
            {
                CustomLogger.LogError(e.StackTrace, "Error sending notification email!");
            }

            return true;
        }

        public void SendEmail(string userEmail, string starterPassword)
        {
            string text = "Hello,</br>You have just been registered to the Filc System. To login, please visit: www.filc.edu.</br></br>Your login credentials are:</br>" +
                          $"Username: {userEmail}</br>Password: {starterPassword}</br></br>If you have any questions, please contact your School Admin.</br></br>Best regards,</br>The Filc Team";

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("filc-system@outlook.com"));
            email.To.Add(MailboxAddress.Parse(userEmail));
            email.Subject = "You've been registered to Filc";
            email.Body = new TextPart(TextFormat.Html) { Text = text };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("filc-system@outlook.com", "FilcAdminCodeCool2023");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
