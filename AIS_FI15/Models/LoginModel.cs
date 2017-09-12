using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AIS_FI15.Controllers
{
    public class LoginModel
    {
        [Required]
        public string  Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}