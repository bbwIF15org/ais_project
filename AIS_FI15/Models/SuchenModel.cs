using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AIS_FI15.Controllers
{
    public class SuchenModel
    {
        public string Suchwort { get; set; }

        public class Navigation
        {
            public string site { get; set; }
            public string word { get; set; }
        }

        public static string Auslesen(string p)
        {
                using (StreamReader r = new StreamReader(p))
                {
                    string json = r.ReadToEnd();

                    return json;
                }
        }


    }
}