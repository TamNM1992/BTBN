using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Data.Dtos
{
    public class HienVatTieuBieuDto
    {

        public string Ten { get; set; }
        public string TieuDe { get; set; }
        public string Nguon { get; set; }
        public string NoiDung { get; set; }
        public string? AnhMinhHoa { get; set; }
        
        public bool TrangThaiXuatBan { get; set; }
        public bool? DaXoa { get; set; }



    }
    public class HienVatTieuBieu_ShowOnViewer
    {
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public string TieuDe { get; set; }
        public string Nguon { get; set; }
        public string? AnhMinhHoa { get; set; }

        public DateTime NgayTao { get; set; }
    }
    public class HienVatTieuBieu_ShowOnUser
    {
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public string TieuDe { get; set; }
        public bool TrangThaiXuatBan { get; set; }

    }
    public class HienVatTieuBieu_Related
    {
        public string Ten { get; set; }
        public DateTime NgayTao { get; set; }
    }
    public class HienVatTieuBieu_Detail
    {
        public string NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public string Nguon { get; set; }

    }
}
