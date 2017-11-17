﻿using System;
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
        public ActionResult Index(string U1, string U2, string TextArea1, HttpPostedFileBase file, string callingView)
        {
            string savedPath = "";

            if ((file != null) && (file.ContentLength > 0))
            {
                savedPath = SaveFile(file, callingView);
            }

            DbWrite(U1, U2, TextArea1, savedPath, callingView);

            string controllerToRedirectTo = callingView + "/Index";
            return RedirectToAction("index", controllerToRedirectTo);            
        }
        public void DbWrite(string us, string uus, string txt, string filePath, string callingView)
        {           
            var db = Database.Open("SQLServerConnectionString");

            //var insertQuery = "INSERT INTO Wohnheim (Title, Addition, Text, Time) VALUES ('" + us + "','" + uus + "','" + txt + "', CURRENT_TIMESTAMP)";

            string insertQuery = "INSERT INTO " + callingView + " (Title, Addition, Text, Link, Time) VALUES (@0, @1, @2, @3, CURRENT_TIMESTAMP)";

            db.Execute(insertQuery, new string[4] { us, uus, txt, filePath });


            db.Close();

            
        }

        private string SaveFile(HttpPostedFileBase file, string callingView)
        {
          
                string fn = System.IO.Path.GetFileName(file.FileName);
                string SaveLocation = Server.MapPath("/Data") + "\\" + callingView + "\\" + fn;
                try
                {
                    file.SaveAs(SaveLocation);
                    Response.Write("The file has been uploaded.");
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                    //Note: Exception.Message returns detailed message that describes the current exception. 
                    //For security reasons, we do not recommend you return Exception.Message to end users in 
                    //production environments. It would be better just to put a generic error message. 
                }
            return "\\Data\\" + callingView + "\\" + file.FileName;


        }

        [HttpPost]
        public ActionResult Delete(string sId, string callingView)
        {
            ulong uLongId = ulong.Parse(sId);
            //ToDo trycatch
            var db = Database.Open("SQLServerConnectionString");
            var deleteQueryString = "DELETE FROM Zeiten WHERE Id = '" + uLongId + "'";
            db.Execute(deleteQueryString);
            db.Close();

            return RedirectToAction("index", callingView + "/Index");
        }

        //POST: Wohnheim
        [HttpPost]
        public ActionResult InsertTime(string Name, string U1, string U2, string U3, string U4, string U5, string U6, string U7, string U8, string U9, string U10, string U11, string U12, string U13, string U14, string callingView)
        {

            var db = Database.Open("SQLServerConnectionString");

            //var insertQuery = "INSERT INTO Wohnheim (Title, Addition, Text, Time) VALUES ('" + us + "','" + uus + "','" + txt + "', CURRENT_TIMESTAMP)";

            string insertQuery = "INSERT INTO Zeiten (Name, MontagFr, MOntagSp, DienstagFr, DienstagSp, MittwochFr, MittwochSp, DOnnerstagFr, DonnerstagSp, FreitagFr, FreitagSp, SamstagFr, SamstagSp, SOnntagFr, SonntagSp) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14)";

            db.Execute(insertQuery, new string[15] { Name, U1, U2, U3, U4, U5, U6, U7, U8, U9, U10, U11, U12, U13, U14 });


            db.Close();

            return RedirectToAction("index", callingView + "/Index");
        }

    }
} 