// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Pindorama.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)

        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }


        public IList<AuthenticationScheme> ExternalLogins { get; set; }


        public class InputModel
        {

            [Required(ErrorMessage = "Informe um E-mail.")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }


            [Required(ErrorMessage = "Informe uma senha.")]
            [StringLength(100, ErrorMessage = "Digite uma senha forte contendo, Letra maiúscula, minúscula, número e caractere especial.", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Digite a mesma senha que foi digitado acima.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Escolha o seu tipo de usuario podendo ser, Cliente, Aldeia ou Admin.")]
            [StringLength(100, ErrorMessage = "Escolha o seu tipo de usuario podendo ser, Cliente, Aldeia ou Admin.")]
            [Display(Name = "Tipo de Usuario")]
            public string Name { get; set; }
        }


        public async Task OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var role = _roleManager.Roles.Where(rl => rl.NormalizedName == Input.Name.ToUpper()).FirstOrDefault();


            if (ModelState.IsValid)
            {
                var user = CreateUser();
                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);


                if (role != null)
                {
                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("Usuario criado com sucesso.");
                        await _userManager.AddToRoleAsync(user, role.Name);

                        var userId = await _userManager.GetUserIdAsync(user);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(Input.Email, "Confirme seu email",
                            $"Confirme sua conta, <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicando aqui</ a>.");

                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                        }
                        else
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                    }

                    var cont = 0;
                    foreach (var error in result.Errors)
                    {

                        if (cont == 0)
                        {
                            cont++;
                            ModelState.AddModelError(string.Empty, error.Code.Equals("PasswordRequiresNonAlphanumeric") ||
                            error.Code.Equals("PasswordRequiresUpper") || error.Code.Equals("PasswordRequiresDigit") ||
                            error.Code.Equals("PasswordRequiresLower") ? "A senha deve conter no minimo 8 caracteres," +
                            " Letras Maiúscula e Minuscula, Número e Caractere Especial(@,#,$,etc)." : "");
                        }
                        ModelState.AddModelError(string.Empty, error.Code.Equals("DuplicateUserName") ? "E-mail já cadastrado, tente outro." : "");


                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Escolha o seu tipo de usuario podendo ser, Cliente, Aldeia ou Admin.");
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Não é possível criar uma instância de '{nameof(IdentityUser)}'. " +
                    $"Garanta que '{nameof(IdentityUser)}' não é uma classe abstrata e tem um construtor sem parâmetros, ou alternativamente " +
                    $"substituir a página de registro em /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("A interface do usuário padrão requer um repositório de usuários com suporte por e-mail.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}
