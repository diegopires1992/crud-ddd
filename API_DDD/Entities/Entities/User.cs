using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public ICollection<Phone> Phones { get; set; } = new List<Phone>();
    }
}
