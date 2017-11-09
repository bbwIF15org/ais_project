using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AIS_FI15.Controllers
{
    public class SharedAnzeigenModel
    {
        //public string Suchwort { get; set; }

        public class Artikel
        {
            public string ueberschrift { get; set; }
            public string unterUeberschrift { get; set; }
            public string text { get; set; }
            public DateTime zeitpunkt { get; set; }
        }

        public static string Auslesen(string p)
        {
                using (StreamReader r = new StreamReader(p))
                {
                    string json = r.ReadToEnd();
                    json = json.Insert(0, "[");
                    json = json + "]";
                    return json;
                }
        }


    }
}