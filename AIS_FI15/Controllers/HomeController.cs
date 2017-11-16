using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using ppt = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;

namespace AIS_FI15.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}