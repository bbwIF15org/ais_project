using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;

namespace AIS_FI15.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        /// <summary>
        /// This function automatically converts provided Schdules into PNG format
        /// </summary>
        /// <returns>The Action Result (Page)</returns>
        [HttpGet]
        public ActionResult Index()
        {

            // Read file names frim DIredtdory
            string[] schedules = Directory.GetFiles(Server.MapPath("~/Data/Speiseplan"));
            Presentation pres;
            Application app;
            // Check if parent folder axists, if not create it
            if (!Directory.Exists(Server.MapPath("~/Data/Speiseplan/Bilder")))
            {

                Directory.CreateDirectory(Server.MapPath("~/Data/Speiseplan/Bilder"));

            }

            // iterate through all lines of your eating schedule and coinvert the Files to BDF.
            foreach (string file in schedules)
            {

                try
                {
                    string filePath = Server.MapPath("~/Data/Speiseplan/Bilder/" + Path.GetFileNameWithoutExtension(file) + "/");
                    // open and save the *.ppsx-files if they are not already present
                    if (!(Directory.Exists(filePath) && Directory.GetFiles(filePath, "*.png").Length > 0) && !filePath.Contains("humbs"))
                    {                    
                        app = new Application();
                        pres = app.Presentations.Open(file, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
                        // i guess the following  + ".png" is ignored because Server.MapPath can't deal with file extensions
                        string newPath = Server.MapPath("~/Data/Speiseplan/Bilder/" + Path.GetFileNameWithoutExtension(file) + ".png");
                        pres.SaveAs(newPath, PpSaveAsFileType.ppSaveAsPNG, MsoTriState.msoTrue);
                        pres.Close();
                        app.Quit();
                    }

                }
                catch (Exception e)
                {

                    string f = e.ToString();  
                }
              
            }
            return View();
        }

        public void DbWrite(string us, string uus, string txt, string filePath, string callingView)
        {



        }




        }

}