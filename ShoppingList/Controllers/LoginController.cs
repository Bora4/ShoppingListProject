using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingList.Models;
using ShoppingList.Models.ViewModels;
using ShoppingListAPI.Controllers;
using ShoppingListAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShoppingList.Controllers
{
    public class LoginController : Controller
    {

        private readonly ShoppingDBContext _context;
        private readonly UsersController _controller;
        

        public LoginController()
        {
            _context = new();
            _controller = new(_context);
        }



        [HttpGet]
        public async Task<IActionResult> Login()
        {

            if (HttpContext.User.Claims.Any())
            {
                var user = HttpContext.User;

                if (user.HasClaim(u => u.Type == ClaimTypes.NameIdentifier))
                {
                    string email = user.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value;
                    var result = _controller.GetUser(email);
                    if (result != null)
                    {
                        if (result.Password != null)
                        {
                            ClaimsPrincipal principal = GenerateClaims(result);

                            CurrentUser.Id = result.Id;
                            CurrentUser.FirstName = result.FirstName;
                            CurrentUser.LastName = result.LastName;
                            CurrentUser.Email = result.Email;
                            CurrentUser.RememberMe = true;

                            await HttpContext.SignInAsync(principal, new AuthenticationProperties() { IsPersistent = true });

                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            return View();

        }
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> LoginAction()
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            User user = _controller.GetUser(email);
            if (user != null)
            {
                if (user.Password == password)
                {

                    ClaimsPrincipal principal = GenerateClaims(user);

                    bool isPersistent = false;

                    if (Request.Form["RememberMe"] == "on")
                    {
                        isPersistent = true;
                        CurrentUser.RememberMe = true;
                    }
                    else
                    {
                        CurrentUser.RememberMe = false;
                    }

                    await HttpContext.SignInAsync(principal, new AuthenticationProperties() { IsPersistent = isPersistent });


                    CurrentUser.FirstName = user.FirstName;
                    CurrentUser.LastName = user.LastName;
                    CurrentUser.Email = email;
                    CurrentUser.Id = user.Id;
                     
                    return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    ViewBag.Message = "Incorrect password.";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "User was not found.";
                return View();
            }


        }
        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        [ActionName("CreateAccount")]
        public async Task<IActionResult> CreateUser()
        {
            User user = new();
            user.FirstName = Request.Form["Firstname"];
            user.LastName = Request.Form["LastName"];
            user.Email = Request.Form["Email"];
            user.Password = Request.Form["Password"];
            string password2 = Request.Form["Password2"];
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            var isValidated = hasNumber.IsMatch(user.Password) && hasUpperChar.IsMatch(user.Password) && hasLowerChar.IsMatch(user.Password) && hasMinimum8Chars.IsMatch(user.Password);
            if (isValidated && user.Password == password2)
            {
                var result = _controller.PostUser(user);
                result.Wait();
                CurrentUser.FirstName = user.FirstName;
                CurrentUser.LastName = user.LastName;
                CurrentUser.Email = user.Email;
                CurrentUser.Id = ((User)((ObjectResult)result.Result.Result).Value).Id;

                var principal = GenerateClaims(user);

                await HttpContext.SignInAsync(principal, new AuthenticationProperties() { IsPersistent = false });

                return RedirectToAction("Index", "Home");
                
            }
            else if(isValidated && user.Password != password2)
            {
                ViewBag.Data = "Passwords don't match";
            }
            else
            {
                ViewBag.Data = "Your password mush contain one upper case letter, one lower case letter and one number";
            }

            return View();
        }

        private ClaimsPrincipal GenerateClaims(User user)
        {
            List<Claim> myClaims = new();
            myClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Email));
            myClaims.Add(new Claim(ClaimTypes.Name, user.FirstName));
            myClaims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            if (user.Id == 1)
            {
                myClaims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else
            {
                myClaims.Add(new Claim(ClaimTypes.Role, "User"));
            }

            ClaimsIdentity identity = new(myClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new(identity);
            return principal;
        }
    }
}
