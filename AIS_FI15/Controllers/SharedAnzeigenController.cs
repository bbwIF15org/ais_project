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

        /// <summary>
        /// delete a single news entry from the database
        /// </summary>
        /// <param name="sId">The id of the Datarow in the Database</param>
        /// <param name="callingView">Table name from which to delete.</param>
        public void DbDelete(string sId, string callingView)
        {
            ulong uLongId;
            ulong.TryParse(sId, out uLongId);

            //ToDo trycatch
            var db = Database.Open("SQLServerConnectionString");
            var items = db.Query("SELECT * FROM " + callingView + " WHERE Id = '" + uLongId + "'");
            foreach (var item in items)
            {
                // If a file was uploaded in the news, delete also the file.
                if (item.Link != "" && item.Link != null)
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath( Url.Content("~") + item.Link));
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
            var deleteQueryString = "DELETE FROM " + callingView + " WHERE Id = '" + uLongId + "'";
            db.Execute(deleteQueryString);
            db.Close();
        }
    }
}