using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Authentication
{
    public class ForgotModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email es requerido")]
        public string Email { get; set; }
    }

}