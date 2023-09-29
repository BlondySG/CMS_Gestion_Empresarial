using Entities.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, IEmailSender emailSender, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.emailSender = emailSender;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("forgot")]
        public async Task<IActionResult> Forgot([FromBody] ForgotModel model)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    if (user == null || !(await userManager.IsEmailConfirmedAsync(user)))
                    {
                        // Don't reveal that the user does not exist or is not confirmed
                        return RedirectToPage("./ForgotPasswordConfirmation");
                    }

                    // For more information on how to enable account confirmation and password reset please
                    // visit https://go.microsoft.com/fwlink/?LinkID=532713
                    var code = await userManager.GeneratePasswordResetTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ResetPassword",
                    pageHandler: null,
                        values: new { area = "Identity", code },
                        protocol: Request.Scheme);

                    await emailSender.SendEmailAsync(
                        model.Email,
                        "Reset Password",
                        $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                

            }
            return Ok("Si el usuario existe, se ha enviado un correo electrónico para restablecer la contraseña.");

            //    var user = await _userManager.FindByEmailAsync(model.Email);
            //if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            //{
            //    // Si el usuario no existe o su dirección de correo electrónico no ha sido confirmada
            //    // devolvemos el mismo mensaje para no revelar información
            //    return BadRequest("Si el usuario existe, se ha enviado un correo electrónico para restablecer la contraseña.");
            //}

            //// Generamos un token de restablecimiento de contraseña
            //var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            //// Creamos la URL para restablecer la contraseña
            //var resetUrl = $"{_configuration["AppBaseUrl"]}/reset-password?email={model.Email}&token={resetToken}";

            //// Enviamos el correo electrónico con la URL de restablecimiento de contraseña
            //var client = new SendGridClient(_configuration["SendGrid:ApiKey"]);
            //var from = new EmailAddress(_configuration["SendGrid:FromEmail"], _configuration["SendGrid:FromName"]);
            //var to = new EmailAddress(model.Email, user.UserName);
            //var subject = "Restablecer contraseña";
            //var htmlContent = $"<p>Haga clic en el siguiente enlace para restablecer su contraseña:</p><p><a href='{resetUrl}'>{resetUrl}</a></p>";
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
            //await client.SendEmailAsync(msg);

            //return Ok("Si el usuario existe, se ha enviado un correo electrónico para restablecer la contraseña.");

        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Si el usuario no existe, devolvemos el mismo mensaje para no revelar información
                return BadRequest("No se encontró ningún usuario con la dirección de correo electrónico especificada.");
            }

            var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!result.Succeeded)
            {
                // Si el restablecimiento de contraseña falló, devolvemos los errores
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok("La contraseña ha sido restablecida exitosamente.");
        }
    }
}


//using Entities.Authentication;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using SendGrid;
//using SendGrid.Helpers.Mail;
//using System.Net;
//using Response = Entities.Authentication.Response;

//namespace BackEnd.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ForgotPasswordController : Controller
//    {
//        private readonly UserManager<ApplicationUser> userManager;
//        private readonly RoleManager<IdentityRole> roleManager;
//        private readonly IConfiguration _configuration;


//        public ForgotPasswordController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
//        {
//            this.userManager = userManager;
//            this.roleManager = roleManager;
//            _configuration = configuration;
//        }

//        [HttpPost]
//        [Route("forgot-password")]
//        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var user = await userManager.FindByEmailAsync(model.Email);
//                if (user == null)
//                {
//                    return BadRequest(new Response { Status = "Error", Message = "Invalid email address!" });
//                }

//                var token = await userManager.GeneratePasswordResetTokenAsync(user);

//                var callbackUrl = $"{Request.Scheme}://{Request.Host}/api/authenticate/reset-password?email={Uri.EscapeDataString(user.Email)}&token={Uri.EscapeDataString(token)}";

//                var message = new SendGridMessage();
//                message.SetFrom(new EmailAddress(_configuration["EmailSender:FromEmail"], _configuration["EmailSender:FromName"]));
//                message.AddTo(user.Email);
//                message.SetSubject("Reset Password");
//                message.AddContent(MimeType.Text, $"Please reset your password by clicking here: {callbackUrl}");
//                message.AddContent(MimeType.Html, $"<p>Please reset your password by clicking here: <a href='{callbackUrl}'>{callbackUrl}</a></p>");

//                var client = new SendGridClient(_configuration["EmailSender:ApiKey"]);
//                var response = await client.SendEmailAsync(message);

//                if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
//                {
//                    return Ok(new Response { Status = "Success", Message = "Reset password email has been sent!" });
//                }
//                else
//                {
//                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to send reset password email! Please try again." });
//                }
//            }

//            return BadRequest(new Response { Status = "Error", Message = "Invalid payload!" });
//        }

//        [HttpPost]
//        [Route("reset-password")]
//        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
//        {
//            var user = await userManager.FindByEmailAsync(model.Email);
//            if (user == null)
//            {
//                return NotFound(new Response { Status = "Error", Message = "User not found!" });
//            }

//            var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
//            if (!result.Succeeded)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Password reset failed! Please check input values and try again." });
//            }

//            return Ok(new Response { Status = "Success", Message = "Password reset successful!" });
//        }
//    }
//}
