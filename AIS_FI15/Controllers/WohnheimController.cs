using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.Data;

namespace AIS_FI15.Controllers
{
    public class WohnheimController : Controller
    {
        // GET: Wohnheim
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rss()
        {
            return View();
        }
    }
}