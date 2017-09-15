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
        public ActionResult Index(SuchenModel model)
        {
           return View();
        }

        [HttpPost]
        public ActionResult CheckTerm(SuchenModel model)
        {
            /* MySql-Verweis muss eingefügt werden!! */
            /* MySql.data.dll sowie ein Tutorial zum Einfügen liegen auf der 25 */

            string Suchwort = model.Suchwort;

            string conString = "server=localhost;uid=root;pwd=;database=ais_fi15;";
            MySqlConnection con = new MySqlConnection(conString);

            return null;
        }



        }
}