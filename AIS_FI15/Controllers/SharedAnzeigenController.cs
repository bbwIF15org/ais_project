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
        // GET: SharedAnzeigen
        public ActionResult Index(string sId)
        { 
            //var pageName = Request.view .ToString();
            DbDelete(sId);


            return RedirectToAction("index", "Wohnheim/Index");
        }

        public void DbDelete(string sId)
        {
            ulong uLongId;
            ulong.TryParse(sId, out uLongId);

            //ToDo trycatch
            var db = Database.Open("SQLServerConnectionString");           
            var deleteQueryString = "DELETE FROM Wohnheim WHERE Id = '" + uLongId + "'";
            db.Execute(deleteQueryString);
            db.Close();
        }
    }
}