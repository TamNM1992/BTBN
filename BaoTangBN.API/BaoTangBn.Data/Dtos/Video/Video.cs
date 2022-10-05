using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Data.Dtos
{
    public class VideoDto
    {
        public string Ten { get; set; }
        public string MaVideo { get; set; }
        public string MoTa { get; set; }
        public string? AnhMinhHoa { get; set; }
        public bool? DaXoa { get; set; }

    }
    public class Video_ShowOnViewer
    {
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public string MaVideo { get; set; }

        public string? AnhMinhHoa { get; set; }

    }
    public class Video_ShowOnUser
    {
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string? AnhMinhHoa { get; set; }

    }
    public class Video_Related
    {
        public string Ten { get; set; }
        public DateTime NgayTao { get; set; }
    }
    public class Video_Detail
    {
        public string MaVideo { get; set; }
    }
}
