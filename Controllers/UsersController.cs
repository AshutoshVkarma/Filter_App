using Filter_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Filter_App.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationContext context;
        public UsersController()
        {
            context = new ApplicationContext();
        }
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn(SignInModel model)
        {
            var user = context.Users.SingleOrDefault(e => e.Email == model.Email && e.Password == model.Password);
            if(user!= null)
            {
                FormsAuthentication.SetAuthCookie(model.Email, model.Cookie);
                return RedirectToAction("Index","Products");
            }
            else
            {
                ViewBag.Msg = "Invalid User";
            }
            return View("Index");
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Users users)
        {
            context.Users.Add(users);
            context.SaveChanges();
            TempData["Msg"]= "User Created";
            return RedirectToAction("Index");
        }
        
    }
}