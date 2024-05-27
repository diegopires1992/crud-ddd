using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PhoneDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{2}$", ErrorMessage = "O DDD deve ter 2 dígitos numéricos.")]
        public string DDD { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "O telefone deve conter apenas números.")]
        public string Number { get; set; }

        [Required]
        public PhoneType Type { get; set; }
    }
}

