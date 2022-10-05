using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Data.Dtos
{
    public class AlbumDto
    {

        public string Ten { get; set; }
        public string Mota { get; set; }
        public string NoiDungAlbum { get; set; }
        public bool TrangThaiXuatBan { get; set; }
        public bool? DaXoa { get; set; }

    }
    public class Album_ShowOnViewer
    {
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public string NoiDungAlbum { get; set; }
    }
    public class Album_ShowOnUser
    {
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public string Mota { get; set; }
        public string NoiDungAlbum { get; set; }

        public bool TrangThaiXuatBan { get; set; }

    }
    public class Album_Related
    {
        public string Ten { get; set; }
        public DateTime NgayTao { get; set; }
    }
    public class Album_Detail
    {
        public string NoiDungAlbum { get; set; }

    }
}
