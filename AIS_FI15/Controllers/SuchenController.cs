using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace AIS_FI15.Controllers
{
    public class SuchenController : Controller
    {
        // GET: Suchen
        public ActionResult Index(string Suchwort)
        {

            Console.Write(Suchwort);

            return View();
        }

    }
}