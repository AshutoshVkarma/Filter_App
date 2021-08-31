using Filter_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                return RedirectToAction("Index","Product");
            }
            else
            {
                ViewBag.Msg = "Invalid User";
            }
            return View();
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
            return RedirectToAction("Index");
        }
    }
}