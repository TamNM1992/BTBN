using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.NoiQuyThamQuanRepo
{
    public interface INoiQuyThamQuanRepository
    {
        public bool EditNoiQuyThamQuan( Guid IDNguoiSua, NoiQuyThamQuanDto NoiQuyThamQuanDto);
        public NoiQuyThamQuan_Detail ShowDetails();
    }
}
