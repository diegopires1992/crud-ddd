using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Digite um endereço de e-mail válido.")]
        public string Email { get; set; }

        public List<PhoneDTO> Phones { get; set; } = new List<PhoneDTO>();
    }

}
