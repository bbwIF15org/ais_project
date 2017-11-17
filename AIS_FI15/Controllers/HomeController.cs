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
        [HttpGet]
        public ActionResult Index()
        {
            string[] schedules = Directory.GetFiles(Server.MapPath("~/Data/Speiseplan"));
            Presentation pres;
            Application app;
            if (!Directory.Exists(Server.MapPath("~/Data/Speiseplan/Bilder")))
            {
                Directory.CreateDirectory(Server.MapPath("~/Data/Speiseplan/Bilder"));
            }

            foreach (string file in schedules)
            {
                try
                {
                    app = new Application();
                    pres = app.Presentations.Open(file, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
                    string newPath = Server.MapPath("~/Data/Speiseplan/Bilder/" + Path.GetFileNameWithoutExtension(file) + ".png");
                    pres.SaveAs(newPath, PpSaveAsFileType.ppSaveAsPNG, MsoTriState.msoTrue);
                    pres.Close();
                    app.Quit();
                }
                catch (Exception)
                {

                    
                }
              
            }
            return View();
        }
    }
}