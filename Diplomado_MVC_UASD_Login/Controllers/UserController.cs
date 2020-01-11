using Diplomado_MVC_UASD_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                User oldUser = DataDataContext.Users.FirstOrDefault(u => u.IdUser == user.IdUser);
                if (user != null)
                {
                    DataDataContext.Users.InsertOnSubmit(user);
                    DataDataContext.SubmitChanges();
                }
            }
            return View("Index");
        }

        public ActionResult Details(int id)
        {
            User user = DataDataContext.Users.FirstOrDefault(u => u.IdUser == id);
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            User user = DataDataContext.Users.FirstOrDefault(u => u.IdUser == id);
            return View(User);
        }

        [HttpPost]
        public ActionResult Delete(User user)
        {
            if (ModelState.IsValid)
            {
                User oldUser = DataDataContext.Users.FirstOrDefault(u => u.IdUser == user.IdUser);
                if (oldUser != null)
                {
                    DataDataContext.Users.DeleteOnSubmit(oldUser);
                    DataDataContext.SubmitChanges();
                    return View("Index");
                }
            }
            return View(user);
        }
    }
}