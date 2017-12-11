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
using AIS_FI15.Models;

namespace AIS_FI15.Controllers
{

    public class PsychologischerDienstController : Controller
    {

        // GET: Login
        public ActionResult Index()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Index(PhysioModel model)
        {

            if (ModelState.IsValid)
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(Server.MapPath("/App_Data/Physio.xml"));
                foreach (XmlNode node in doc.SelectNodes("//wochentag"))

                {
                    String Wochentag = node.SelectSingleNode("wochentag").InnerText;
                    String Uhrzeit = node.SelectSingleNode("uhrzeit").InnerText;

                    //Crypto

                    //Instanz eines XML Dokuments in den RAM laden, XML Konten und XML Attribute reservieren
                    
                    XmlNode myRoot, myNode;
                    XmlAttribute myAttribute;
                    //Root Element einfügen
                    myRoot = doc.CreateElement("/App_Data/Physio.xml");
                    doc.AppendChild(myRoot);

                    myNode = doc.CreateElement("Wochenende");               //Unterknoten einfügen
                    myNode.InnerText = "Montag";                         //Text in den Knoten laden

                    myAttribute = doc.CreateAttribute("Attribute1");    //Attribut aus XML Dokument erstellen
                    myAttribute.InnerText = "AttributeText1";           //Attribut mit Wert befüllen
                    myNode.Attributes.Append(myAttribute);              //Attribut an Unterknoten einfügen

                    //Unterknoten an Root Knoten anhängen
                    myRoot.AppendChild(myNode);
                    //Das ganze in 2 Zeilen
                    myRoot.AppendChild(doc.CreateElement("Child2")).InnerText = "Text2";
                    myRoot.SelectSingleNode("Child2").Attributes.Append(doc.CreateAttribute("Attribute2")).InnerText = "AttributeText2";

                    //XML Dokument speichern
                    doc.Save(@"App_Data\HelloXMLWorldAttribute.xml");

                }

            }

            return View();
        }

    }

}