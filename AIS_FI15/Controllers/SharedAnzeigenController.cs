using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIS_FI15.Controllers
{
    public class SharedAnzeigenController : Controller
    {
        // GET: SharedAnzeigen
        public ActionResult Index()
        {
            string json = SharedAnzeigenModel.Auslesen(Server.MapPath("/App_Data/Wohnheim.json")); //ToDo: muss sich der aufrufenden Seite anpassen


            return View();
        }
    }
}