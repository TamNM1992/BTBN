using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Data.Dtos
{
    public class ChucNangNhiemVuDto
    {
        public string Ten { get; set; }

        public string TomTat { get; set; }

        public string NoiDung { get; set; }



    }
    public class ChucNangNhiemVu_Detail
    {

        public string Ten { get; set; }

        public string NoiDung { get; set; }

    }
}
