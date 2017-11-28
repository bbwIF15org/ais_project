using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using MySql.Data.MySqlClient;
using System.Web.Script.Serialization;
using System.IO;

namespace AIS_FI15.Controllers
{
    public class SuchenController : Controller
    {
        // GET: Suchen
        public ActionResult Index(string Suchwort)
        {
            string json = SuchenModel.Auslesen(Server.MapPath("/App_Data/SearchStrings.json"));

            if (Suchwort.ToLower() == "darkmode = true")
            {
                var cookieDarkMode = new HttpCookie("DarkMode");
                cookieDarkMode.Value = "DarkMode = True";
                Response.SetCookie(cookieDarkMode);
                return RedirectToAction("index", "Home/Index");

            }

            if (Suchwort.ToLower() == "darkmode = false")
            {
                var cookieDarkMode = new HttpCookie("DarkMode");
                cookieDarkMode.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookieDarkMode);
                return RedirectToAction("index", "Home/Index");
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
                SuchenModel.Navigation[] Navi = js.Deserialize<SuchenModel.Navigation[]>(json);

                for(int l = 0; l < Navi.Length; l++ )
                {
                    try
                    {
                        if (Navi[l].word == Suchwort.ToLower())
                            return RedirectToAction("index", Navi[l].site);
                    }
                    catch (Exception)
                     {
                        return RedirectToAction("index", "Home/Index");
                        throw;
                     }
                       
                }
            
            AIS_FI15.Models.SuchwortModel sw = new AIS_FI15.Models.SuchwortModel { SuchwortSend = Suchwort };             
            return View(sw);
        }

    }
}