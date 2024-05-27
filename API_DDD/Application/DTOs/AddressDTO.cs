using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato 83413-678.")]
        public string CEP { get; set; }
        [Required]
        public bool IsMain { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string State { get; set; }
    }
}
