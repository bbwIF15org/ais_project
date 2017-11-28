using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIS_FI15.Controllers
{
    public class VerwaltungController : Controller
    {
        // GET: Verwaltung
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                //if (Request.IsAuthenticated && (System.Web.HttpContext.Current.User.Identity.Name == "Mensa" || System.Web.HttpContext.Current.User.Identity.Name == "Root")) { }
                //Beispiel zum Abfragen der Authenticated und nach dem Usernamen.
                //In diesem Beispiel wird der Zugang nur gewährt wenn man:
                //sich mit richtigem Usernamen und Passwort anmeldet 
                //*UND*
                //Man den Usernamen „Mensa“ *ODER* „Root“ besitzt.

                return View();
            }
            else
            {
                return RedirectToAction("index", "Login/Index");
            }
        }
    }
}