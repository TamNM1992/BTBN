
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.ChiDanService
{
    public interface IChiDanService
    {
        public bool EditChiDan(string token, ChiDanDto ChiDanDto);
        public ChiDan_Detail ShowDetails();
    }
}
