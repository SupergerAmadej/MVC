using DSR_N2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace DSR_N2.Controllers
{
    public class RegistracijaController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult Registracija()
        {
            return View();
        }

        //public IActionResult RegistracijaInvalid(User user)
        //{
        //    //if (user == null)
        //    //{
        //    //    return View();
        //    //}
        //    //return View(user);
        //    return View("~/Views/Registracija/Registracija.cshtml", user);
        //}

        //[Bind("EMSO,Ime,Priimek,Email,Datum_Roj,Kraj_Roj,Starost,Naslov,Postna_Stevilka,Drzava,Geslo")]

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Forma(UserWithGeslo user)
        {
            if (!ModelState.IsValid)
            {
                //return RedirectToAction("asd",,,)
                //return RedirectToAction("RegistracijaInvalid", new User(user));
                return View("~/Views/Registracija/Registracija.cshtml", user);
            }
            //return RedirectToAction("Registracija");
            //var usr = new User { UserName = user.Email, Email = user.Email };
            user.UserName = user.Email;
            var result = await userManager.CreateAsync(user, user.Geslo);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent:false);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("~/Views/Registracija/Registracija.cshtml", user);
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            Login model = new Login
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe,false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "invalid login");


            }

            return View(login);
        }

        public RegistracijaController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Registracija", new { ReturnUrl = returnUrl });

            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            Login login = new Login
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError(String.Empty, $"Error from external provider: {remoteError}");

                return View("Login", login);
            }

            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading external login info");

                return View("Login", login);
            }

            var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, 
                isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                if (email != null)
                {
                    var user = await userManager.FindByEmailAsync(email);

                    if (user == null)
                    {
                        user = new User
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                            EMSO = 0000000000000,
                            Ime = info.Principal.FindFirstValue(ClaimTypes.Name) == null ? "" : info.Principal.FindFirstValue(ClaimTypes.Name),
                            Priimek = info.Principal.FindFirstValue(ClaimTypes.Surname) == null ? "": info.Principal.FindFirstValue(ClaimTypes.Surname),
                            Drzava = info.Principal.FindFirstValue(ClaimTypes.Country) == null ? "" : info.Principal.FindFirstValue(ClaimTypes.Country),
                            Datum_Roj = (DateTime.TryParse(info.Principal.FindFirstValue(ClaimTypes.DateOfBirth),out DateTime dt) ? dt : DateTime.Now),
                            Kraj_Roj = "/",
                            Naslov = "/",
                            Postna_Stevilka = 0000
                        };

                        await userManager.CreateAsync(user);
                    }

                    await userManager.AddLoginAsync(user, info);
                    await signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                ViewBag.ErrorTitle = $"Email claim not recieved from: {info.LoginProvider}";
                ViewBag.ErrorMessage = $"Please contact support";

                return View("Error");
            }
        }

    }
}