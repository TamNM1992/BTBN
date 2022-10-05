using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Data.Models
{

    public class NoiQuyThamQuan
    {
        [Key]
        public Guid ID { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Ten { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string TomTat { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string NoiDung { get; set; }

        public DateTime? NgaySua { get; set; }

        public Guid? IDNguoiSua { get; set; }


    }
}
