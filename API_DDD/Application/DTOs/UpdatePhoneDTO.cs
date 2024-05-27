using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdatePhoneDTO
    {
        [Required]
        public string NewPhone { get; set; }

        [Required]
        public string ddd { get; set; }

    }
}
