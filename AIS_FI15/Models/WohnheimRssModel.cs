using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

namespace AIS_FI15.Models
{
    public class WohnheimRssModel
    {
        public static WohnheimItem[] readItems()
        {
            //ToDo fehler abfangen wenn db-verbindung fehlschlägt (try catch?)
            Database db = Database.Open("SQLServerConnectionString");

            //var db = Database.Open("");
            string selectQueryString = "SELECT * FROM Wohnheim";

            dynamic[] dbItemsArray = db.Query(selectQueryString).ToArray();
            IEnumerable<dynamic> dbItems = db.Query(selectQueryString);
            WohnheimItem[] o = new WohnheimItem[dbItemsArray.Length];
            int i = 0;
            foreach (var dbItem in dbItems)
            {
                WohnheimItem oitem = new WohnheimItem();
                oitem.id = dbItem.Id.ToString();
                oitem.title = dbItem.Title;
                oitem.subtitle = dbItem.Addition;
                oitem.text = dbItem.Text;
                oitem.date = dbItem.Time.ToString();
                o[i] = oitem;
                i++;
            }

            return o;
        }

        public struct WohnheimItem
        {
            public string id;
            public string title;
            public string subtitle;
            public string text;
            public string date;
        }
    }
}