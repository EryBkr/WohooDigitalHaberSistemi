using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WohooDigitalProject.News.WebUI.Identity;
using WohooDigitalProject.News.WebUI.Models;

namespace WohooDigitalProject.News.WebUI.Controllers
{
    
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = "Admin";
            user.Email = "admin@admin.com";
            var result = userManager.Create(user, "AdminAdmin");
            return RedirectToAction("Login","Account");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.UserName, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı");

                }
                else
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = true
                    };
                    authManager.SignOut();
                    authManager.SignIn(authProperties, identity);
                    return RedirectToAction("Index", "Admin");
                }
            }
        
            return View();
        }

        public ActionResult LogOut()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Login");
        }

    }
}