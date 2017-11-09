using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;

namespace AIS_FI15.Controllers
{
    public class SharedBearbeitenController : Controller
    {
        // GET: SharedBearbeiten
        public ActionResult Index(string U1, string U2, string TextArea1)
        {
            Console.WriteLine(U1, U2, TextArea1);

            FileTest();


            return View();
        }

        public void FileTest()
        {
            string path = (Server.MapPath("/App_Data/Wohnheim.json"));

            try
            {
                // Delete the file if it exists.
                if (System.IO.File.Exists(path))
                {
                    Console.WriteLine("");
                }

                else
                {
                    // Create the file.
                    using (FileStream fs = System.IO.File.Create(path))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                  }   
               }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
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