using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using WebMatrix.Data;


namespace AIS_FI15.Controllers
{
    public class SharedBearbeitenController : Controller
    {
        // GET: SharedBearbeiten
        public ActionResult Index(string U1, string U2, string TextArea1, string callingView)
        {   
            DbWrite(U1, U2, TextArea1, callingView);

            string controllerToRedirectTo = callingView + "/Index";
            return RedirectToAction("index", controllerToRedirectTo);            
        }
        public void DbWrite(string us, string uus, string txt, string callingView)
        {

            var db = Database.Open("SQLServerConnectionString");

            //var insertQuery = "INSERT INTO Wohnheim (Title, Addition, Text, Time) VALUES ('" + us + "','" + uus + "','" + txt + "', CURRENT_TIMESTAMP)";

            string insertQuery = "INSERT INTO " + callingView + " (Title, Addition, Text, Time) VALUES (@0, @1, @2, CURRENT_TIMESTAMP)";

            db.Execute(insertQuery, new string[3] { us, uus, txt });


            db.Close();

            
        }
    }
} 