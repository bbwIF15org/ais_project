using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AIS_FI15.Controllers
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Der Benutzername ist erforderlich.")]
        public string  Username { get; set; }
        [Required(ErrorMessage = "Das Passwort ist erforderlich.")]
        public string Password { get; set; }
    }
}