using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebMatrix.Data;

namespace AIS_FI15.Controllers
{
    public class SharedAnzeigenController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: SharedAnzeigen
        [HttpPost]
        public ActionResult Index(string sId, string callingView)
        {
           
                DbDelete(sId, callingView);
           
            

            string controllerToRedirectTo = callingView + "/Index";
            
            return RedirectToAction("index", controllerToRedirectTo);
        }

        public void DbDelete(string sId, string callingView)
        {
            ulong uLongId;
            ulong.TryParse(sId, out uLongId);

            //ToDo trycatch
            var db = Database.Open("SQLServerConnectionString");           
            var deleteQueryString = "DELETE FROM " + callingView + " WHERE Id = '" + uLongId + "'";
            db.Execute(deleteQueryString);
            db.Close();
        }
    }
}