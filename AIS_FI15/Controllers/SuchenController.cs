using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Web.Script.Serialization;
using System.IO;

namespace AIS_FI15.Controllers
{
    public class SuchenController : Controller
    {

   

        //"[{Name:'Mensa',Link:'Mensa/Index'},{Name:'Kundenservice',Link:'Kundenservice/Index'}]";


        public class Navigation
        {
            public string Link { get; set; }
            public string Name { get; set; }
        }


        // GET: Suchen
        public ActionResult Index(string Suchwort)
        {


            using (StreamReader r = new StreamReader(Server.MapPath("/App_Data/SearchStrings.json")))
            {
                string json = r.ReadToEnd();
           
                JavaScriptSerializer js = new JavaScriptSerializer();
                Navigation[] Navi = js.Deserialize<Navigation[]>(json);

                for(int l = 0; l < Navi.Length; l++ )
                {
                       if(Navi[l].Name == Suchwort)
                            return RedirectToAction("index", Navi[l].Link);
                }



            }


            return View();
        }

    }
}