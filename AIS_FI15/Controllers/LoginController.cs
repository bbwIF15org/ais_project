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
using System.Text;
using System.Security.Cryptography;

namespace AIS_FI15.Controllers
{
    public class LoginController : Controller
    {
        // GET: 
        /// <summary>
        /// Didplay default view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();

        }

        /// <summary>
        /// authenticate Players' unsername and proceeds Log the user in.
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
                    byte[] hashpw = { (81), (197), (169), (248), (40), (225), (114), (230), (29), (113), (109), (18), (206), (96), (57), (3), (123), (50), (3), (152), (107), (191), (101), (62), (183), (133), (87), (64), (76), (201), (45), (182)};
                    //Crypto

                    SHA256 sha256 = SHA256Managed.Create();
                    byte[] hashBytes = Encoding.UTF8.GetBytes(Password);
                    byte[] hash = sha256.ComputeHash(hashBytes);

                    /* Compare the results */

                    for (int i = 0; i < 32; i++)
                    {
                        if (hash[i] != hashpw[i])
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