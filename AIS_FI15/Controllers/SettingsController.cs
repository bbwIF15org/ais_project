using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIS_FI15.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Index(string id)
        {
            if (Request.Form["action:standard"] != null)
            {
                var cookieDarkMode = new HttpCookie("DarkMode");
                cookieDarkMode.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookieDarkMode);
                return RedirectToAction("index", "Settings/Index");
            }
            else if (Request.Form["action:black"] != null)
            {
                var cookieDarkMode = new HttpCookie("DarkMode");
                cookieDarkMode.Value = "DarkMode = True";
                Response.SetCookie(cookieDarkMode);
                return RedirectToAction("index", "Settings/Index");         
            }

            return View();
        }
    }
}




//Für ein Background Pic

//if (SelfBackgroundPathString != null)
//{
//    var CookieSelfBackgroundPathString = new HttpCookie("Background");
//    CookieSelfBackgroundPathString.Value = SelfBackgroundPathString;
//    Response.SetCookie(CookieSelfBackgroundPathString);
//    return RedirectToAction("index", "Settings/Index");
//}

