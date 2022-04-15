using Firebase.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        FirebaseAuthProvider auth;

        public HomeController()
        {
            auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyB2fK-fhnqN1eVSU4DMpN11R1uL6cfFFlc"));
        }

      /*  public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FirebaseRegistrationpage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FirebaseRegistrationpage(Users users)
        {
            
            var registerauth  = await auth.CreateUserWithEmailAndPasswordAsync(users.Email, users.Password);
          

            string token = registerauth.FirebaseToken;
          
            if (token != null)
            {

                return RedirectToAction("FirebaseLoginPage");
            }
            else
            {
                return View();
            }
        }

        public IActionResult FirebaseLoginPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FirebaseLoginPage(Users users)
        {
            
            var loginauth = await auth.SignInWithEmailAndPasswordAsync(users.Email, users.Password);
           
            string token = loginauth.FirebaseToken;

            if (token != null)
            {
                HttpContext.Session.SetString("_UserToken", token);
                return RedirectToAction("RecipePage");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("_UserToken");
            return RedirectToAction("FirebaseLoginPage");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RecipePage()
        {
            var token = HttpContext.Session.GetString("_UserToken");
            if (token != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("FirebaseLoginPage");
            }
        }
    }
}
