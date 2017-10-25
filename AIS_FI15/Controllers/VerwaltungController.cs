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
                return View();
            }
            else
            {
                return RedirectToAction("index", "Login/Index");
            }
        }
    }
}