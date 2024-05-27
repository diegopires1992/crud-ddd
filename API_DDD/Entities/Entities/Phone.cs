using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace Entities.Entities
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(3)]
        [Column("DDD")]
        public string DDD { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("Number")]
        public string Number { get; set; }

        [Required]
        [Column("Type")]
        public PhoneType Type { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
