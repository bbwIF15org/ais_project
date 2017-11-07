using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Web.Script.Serialization;
using System.IO;
using AIS_FI15.Models;

namespace AIS_FI15.Controllers
{
    public class SuchenController : Controller
    {

   

        //"[{Name:'Mensa',Link:'Mensa/Index'},{Name:'Kundenservice',Link:'Kundenservice/Index'}]";


    


        // GET: Suchen
        public ActionResult Index(string Suchwort)
        {



            string json = SuchenModel.Auslesen(Server.MapPath("/App_Data/SearchStrings.json"));





                JavaScriptSerializer js = new JavaScriptSerializer();
                SuchenModel.Navigation[] Navi = js.Deserialize<SuchenModel.Navigation[]>(json);

                for(int l = 0; l < Navi.Length; l++ )
                {
                       if(Navi[l].word == Suchwort.ToLower())
                            return RedirectToAction("index", Navi[l].site);
                }

            
            AIS_FI15.Models.SuchwortModel sw = new AIS_FI15.Models.SuchwortModel { SuchwortSend = Suchwort };        
            
              

            return View(sw);
        }

    }
}