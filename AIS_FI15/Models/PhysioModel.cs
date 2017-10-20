using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AIS_FI15.Models
{
    [XmlRoot("Physio")]
    public class PhysioModel
    {
        [XmlElement("Wochentage")]
        [Required(ErrorMessage = "Bitte geben sie einene Wochentag an.")]
        public string Username { get; set; }

        [XmlElement]

        [XmlElement("Zeiten")]
        [Required(ErrorMessage = "Eine Uhr Zeit ist erforderlich.")]
        public string Password { get; set; }
    }
}