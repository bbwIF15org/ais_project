using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AIS_FI15.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "Login/Index");
        }
    }
}