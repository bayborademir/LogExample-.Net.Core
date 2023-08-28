using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using qwerty.Enttities;

namespace qwerty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : Controller
    {
        private readonly UserManager<AppUser> _userManger;

        public SignUpController(UserManager<AppUser> userManger)
        {
            _userManger = userManger;
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.Password
                };
                var result = await _userManger.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok("Başarılı");
                }
            }
            return Ok();
        }
    }
}

