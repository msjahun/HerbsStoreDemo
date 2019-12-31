using HerbsStore.Libraries.HS.Core.Domain.Users;
using HerbsStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HerbsStore.Controllers
{
    public class AuthenticationController : Controller
    {
       

        public SignInManager<User> SignInManager { get; }
        public UserManager<User> UserManager { get; }

        public AuthenticationController(
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterVm vm)
        {


            //create user account

            if (vm.AgreeToTermsAndConditions == false)
            {
                ModelState.AddModelError("", "You have to accept the terms and conditions");
                return View(vm);
            }





            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = vm.EmailAddress,
                    Email = vm.EmailAddress,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    CreatedOnUtc = DateTime.Now,
                    Active = true,
                    LastActivityDateUtc = DateTime.Now
                };
                var result = await UserManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    

                    await UserManager.AddToRoleAsync(user, "Registered");
                  


                    await SignInManager.SignInAsync(user, false);

                    return Redirect("/");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }

            }
            return View(vm);



        }
        [Route("Login")]
        // GET: Login
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = Request.Headers["Referer"].ToString();
            return View();
        }


        [Route("Login/")]
        [HttpPost]
        public async Task<ActionResult> Login(LoginVm vm)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Users.FirstOrDefault(s => s.Email == vm.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "User doesn't exist");
                    return View(vm);
                }

                //if (user.Active == false)
                //{
                //    ModelState.AddModelError("","Administrator has de-activated your account, please contact administrator");
                //    return View(vm);
                //}


                var result = await SignInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);

                if (result.Succeeded)
                {
                    //save last login date
                    
                    user.LastLoginDateUtc = DateTime.UtcNow;

                    await UserManager.UpdateAsync(user);
                    var st = vm.ReturnUrl;
                    if (!string.IsNullOrEmpty(st))
                        return Redirect(vm.ReturnUrl);

                    return RedirectToAction("Index", "Home");

                }

                ModelState.AddModelError("", "Invalid Login attempt");
              
            }


            return View(vm);
        }

        [Route("Logout/")]
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return Redirect("/" );
        }
    }
}