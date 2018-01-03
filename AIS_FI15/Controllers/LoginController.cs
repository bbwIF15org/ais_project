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
                XmlNodeList UserList = doc.SelectSingleNode("Benutzer").ChildNodes;

                foreach (XmlNode User in UserList)
                {

                    String Username = User.SelectSingleNode("username").InnerText;
                    String Password = User.SelectSingleNode("password").InnerText;

                    bool pw_check = CheckPw(Password, model.Password);

                    if (model.Username == Username && pw_check)//Nutzername UND Passwort müssen übereinstimmen
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, false);
                        return RedirectToAction("index", "Verwaltung/Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", ""); // Meldung das Nutzername oder Passwort nicht richtig sind
                    }

                }

            }

            return View();
        }
        /// <summary>
        /// Vergleicht das eingegebene mit dem Gespeicherten Passwort
        /// </summary>
        /// <param name="PW">gespeichertes Passwort</param>
        /// <param name="mPW">eingegebenes Passwort</param>
        /// <returns>true, wenn Paswort übereinstimmt, false wenn es nicht übereinstimmt</returns>
        private bool CheckPw(string PW, string mPW)
        {
            //Crypto

            byte[] hashBytes = Convert.FromBase64String(PW);  //Extract

            byte[] salt = new byte[16];                             //Salt nehmen
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(mPW, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            /* Compare the results */

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    //Passwörter stimmen nicht überein
                    //Abbruch schon hier
                    return false;
                }

            }
            return true;
        }

    }
}