using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using qwerty.Enttities;
using Volo.Abp.Users;

namespace qwerty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public SignInController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
                if (result.Succeeded)
                {
                    var CurrentUser = await _userManager.FindByNameAsync(model.UserName);
                    var CurrentUserName = await _userManager.GetUserNameAsync(CurrentUser);

                    log4net.GlobalContext.Properties["userName"] = CurrentUserName;
                    //log4net.GlobalContext.Properties["ipAddres"] = ipAddress;
                    return Ok("Giriş Yapıldı");
                }
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            _signInManager.SignOutAsync();
            return Ok("Çıkış yapıldu");
        }

    }
    
}

