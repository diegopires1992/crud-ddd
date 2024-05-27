using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
     public class UpdateEmailDTO
    { 

        [Required]
        [EmailAddress(ErrorMessage = "Digite um endereço de e-mail válido.")]
        public string NewEmail { get; set; }
    }
}
