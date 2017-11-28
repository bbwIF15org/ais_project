using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using WebMatrix.Data;

namespace AIS_FI15.Controllers
{
    public class SharedAnzeigenModel
    {
  

        //public string Suchwort { get; set; }



        public class Artikel
        {
           // public int id { get; set; }
            public string ueberschrift { get; set; }
            public string unterUeberschrift { get; set; }
            public string text { get; set; }
            public DateTime zeitpunkt { get; set; }
        }

        //public static void Speichern(Artikel artikel)
        //{
        //    var db = Database.Open("SQLServerConnectionString");
        //    //var selectQueryString = "SELECT * FROM Wohnheim";
        //}


    }
}