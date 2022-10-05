
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.NoiQuyThamQuanService
{
    public interface INoiQuyThamQuanService
    {
        public bool EditNoiQuyThamQuan(string token, NoiQuyThamQuanDto NoiQuyThamQuanDto);
        public NoiQuyThamQuan_Detail ShowDetails();
    }
}
