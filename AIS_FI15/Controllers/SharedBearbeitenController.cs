﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using WebMatrix.Data;


namespace AIS_FI15.Controllers
{
    public class SharedBearbeitenController : Controller
    {
        // GET: SharedBearbeiten
        public ActionResult Index(string U1, string U2, string TextArea1)
        {
            

            
            DbWrite(U1, U2, TextArea1, DateTime.Now);

            return RedirectToAction("index", "Wohnheim/Index");
        }
        public void DbWrite(string us, string uus, string txt, DateTime zp)//ToDo es muss noch die aufrufende Seite übergeben werden (z.B. "Wohnheim")
        {
            
            var db = Database.Open("SQLServerConnectionString");
            
            var insertQuery = "INSERT INTO Wohnheim (Title, Addition, Text, Time) VALUES ('" + us + "','" + uus + "','" + txt + "', CURRENT_TIMESTAMP)";

            db.Execute(insertQuery);

            db.Close();
            

            //Artikel a = new Artikel();
            //a.ueberschrift = us;
            //a.unterUeberschrift = uus;
            //a.text = txt;
            //a.zeitpunkt = zp;

            //MemoryStream stream1 = new MemoryStream();
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Artikel));

            //ser.WriteObject(stream1, a);
            //stream1.Position = 0;
            //StreamReader sr = new StreamReader(stream1);


            //try
            //{
            //    FileStream fs = new FileStream(path, FileMode.Append);
            //    StreamWriter sw = new StreamWriter(fs);
            //    sw.WriteLine("," + sr.ReadToEnd());
               
            //    sw.Close();
            //    fs.Close();
            //}

            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
        }
     

        //[DataContract]
        //internal class Artikel
        //{
        //    [DataMember]
        //    internal string ueberschrift;

        //    [DataMember]
        //    internal string unterUeberschrift;

        //    [DataMember]
        //    internal string text;

        //    [DataMember]
        //    internal DateTime zeitpunkt;
        //}


    }
}





  // Open the stream and read it back.
                    //using (StreamReader sr = System.IO.File.OpenText(path))
                    //{
                    //    string s = "";
                    //    while ((s = sr.ReadLine()) != null)
                    //    {
                    //        Console.WriteLine(s);
                    //    }
                    //}