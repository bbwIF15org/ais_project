using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using mshtml;

namespace AIS_FI15.Models
{
    public class TelefonbuchModel
    {
        /// <summary>
        /// Parses the phonebook table from external resource and outputs a string matrix.
        /// </summary>
        /// <returns>string matrix representing the parsed table</returns>
        public string[][] parsePhonebook()
        {
            WebClient client = new WebClient();

            // grab external resource
            string raw = client.DownloadString("http://192.168.130.215/~telefonbuch/status.php");

            // prepare parsing (type conversion mostly)
            object[] obj = { raw };

            HTMLDocument doc = new HTMLDocument();
            IHTMLDocument2 doc2 = (IHTMLDocument2)doc;
            doc2.write(raw);

            IHTMLElement2 ie = (IHTMLElement2)doc2.body;
            IHTMLElementCollection iecr = (IHTMLElementCollection)ie.getElementsByTagName("tr");
            IHTMLElementCollection iec = (IHTMLElementCollection)ie.getElementsByTagName("td");

            //create boundaries
            int rows = iecr.length;
            int cols = iec.length / rows + 1;

            //create output container
            string[][] o = new string[rows + 1][];
            for (int k = 0; k < o.Length; k++)
            {
                o[k] = new string[cols];
            }


            //parse loop
            int irow = 0;
            int icol = 0;
            foreach (IHTMLElement item in iec)
            {

                o[irow][icol] = item.innerHTML.ToString();

                // make sure the data is in the right order.
                icol = icol + 1;

                // if row is fully parsed switch to next row.
                if (icol == cols)
                {
                    irow = irow + 1;
                    icol = 0;
                }
            }

            return o;
        }
    }
}