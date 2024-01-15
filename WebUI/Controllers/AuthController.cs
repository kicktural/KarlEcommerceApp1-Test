using Entities.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.DTOs;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            if (!ModelState.IsValid)
            {
              return View();
            }

            var CheckEamil = await _userManager.FindByEmailAsync(loginDto.Email);

            if (CheckEamil == null)
            {
                ModelState.AddModelError("Error", "This Error Is valid!!");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(CheckEamil, loginDto.Password, loginDto.RememBerme, false);


            if (!result.Succeeded)
            {
                ModelState.AddModelError("Error!", "Error This Email");
                return View();
            }
            return RedirectToAction("Index", "Home");
            
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var CheckEmail = await _userManager.FindByEmailAsync(registerDto.Email);

            if (CheckEmail != null)
            {
                ModelState.AddModelError("Error", "Error Email!");
                return View();
            }

            User user = new()
            {
                Firstname = registerDto.FirstName,
                Lastname = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                Address = "/",
                PhotoUrl = "//",
            };


            var CreatePasword = await _userManager.CreateAsync(user, registerDto.Password);


            if (CreatePasword.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in CreatePasword.Errors)
                {
                    ModelState.AddModelError("Error", item.Description);
                }
                  return View(registerDto);
            }

        }
            [HttpPost]
            public async Task<IActionResult> SignOut()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
    }
}

