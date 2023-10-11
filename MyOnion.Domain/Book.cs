using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnion.Domain
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(200)]
        public string? Title { get; set; }
        public int? Price { get; set; }
    }
}
