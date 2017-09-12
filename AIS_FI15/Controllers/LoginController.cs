using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            if(ModelState.IsValid)
            {
                if(model.Username == "marten" && model.Password == "pw")
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("index", "Verwaltung/Index");
                }

                {
                    ModelState.AddModelError("", "Username oder Passwort ist falsch :("); // TODO besser beschreibung 
                }
                
            }


            return View();
        }


    }
}