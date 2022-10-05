using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Data.Models
{
    public class BaoVatQuocGia
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Ten { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string TieuDe { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Nguon { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string NoiDung { get; set; }
        public string? AnhMinhHoa { get; set; }
        
        [Required]
        public bool TrangThaiXuatBan { get; set; }
        public bool? DaXoa { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public DateTime? NgayXoa { get; set; }
        [Required]
        public Guid IDNguoiTao { get; set; }
        public Guid? IDNguoiSua { get; set; }
        public Guid? IDNguoiXoa { get; set; }


    }
}
