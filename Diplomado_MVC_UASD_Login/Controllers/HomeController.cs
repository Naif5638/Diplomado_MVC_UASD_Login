using Diplomado_MVC_UASD_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Diplomado_MVC_UASD_Login.Controllers
{
     public class HomeController : Controller
    {
        SessionData session = new SessionData();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Usuarios(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                if (userLogin.login() == true)
                {
                    session.setSession("UserName", userLogin.UserName);
                    ViewBag.User = session.getSession("UserName");
                    return RedirectToAction("Users", "User");
                }
                else
                {
                    ViewBag.Message = "Error";
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }


        [AllowAnonymous]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignIn(SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                if (signIn.Signin() == false)
                {
                    ViewBag.Message = "El usuario o Email ya estan registrado";
                    return View("SignIn", signIn);
                }
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }
        }
    }
}