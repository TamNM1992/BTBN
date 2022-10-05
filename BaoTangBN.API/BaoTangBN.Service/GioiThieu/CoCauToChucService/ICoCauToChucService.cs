
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.CoCauToChucService
{
    public interface ICoCauToChucService
    {
        public bool EditCoCauToChuc(string token, CoCauToChucDto CoCauToChucDto);
        public CoCauToChuc_Detail ShowDetails();
    }
}
