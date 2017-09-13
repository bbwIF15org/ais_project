using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Security.Cryptography;

namespace AIS_FI15.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                XmlDocument doc = new XmlDocument();

                doc.Load(Server.MapPath("/App_Data/Login.xml"));

                foreach (XmlNode node in doc.SelectNodes("//user"))

                {
                    String Username = node.SelectSingleNode("username").InnerText;
                    String Password = node.SelectSingleNode("password").InnerText;

                    //Crypto

                    byte[] hashBytes = Convert.FromBase64String(Password);  //Extract

                    byte[] salt = new byte[16];                             //Salt nehmen
                    Array.Copy(hashBytes, 0, salt, 0, 16);

                    var pbkdf2 = new Rfc2898DeriveBytes(model.Password, salt, 10000);
                    byte[] hash = pbkdf2.GetBytes(20);

                    /* Compare the results */

                    for (int i = 0; i < 20; i++)
                    {
                        if (hashBytes[i + 16] != hash[i])
                        { 
                            ModelState.AddModelError("", ""); // TODO besser beschreibung 
                            return View();
                        }

                    }


                    if (model.Username == Username)
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, false);
                        return RedirectToAction("index", "Verwaltung/Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", ""); // TODO besser beschreibung 
                    }
  
                }

            }

            return View();
        }

    }
}