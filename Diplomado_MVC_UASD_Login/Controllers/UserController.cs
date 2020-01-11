using Diplomado_MVC_UASD_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplomado_MVC_UASD_Login.Controllers
{
    public class UserController : Controller
    {
        SessionData session = new SessionData();
        UsersDataDataContext DataDataContext = new UsersDataDataContext();
        // GET: User
        public ActionResult Users()
        {
            if (ViewBag.User == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }

        public ActionResult Close()
        {
            session.destroySession();
            return RedirectToAction("Users", "User");
        }

        public ActionResult Index()
        {
            List<User> listUser = DataDataContext.Users.ToList();
            return View(listUser);
        }

        public ActionResult Edit(int id)
        {
            User user = DataDataContext.Users.FirstOrDefault(u => u.IdUser == id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {

            }
            return View("Index");
        }
    }
}