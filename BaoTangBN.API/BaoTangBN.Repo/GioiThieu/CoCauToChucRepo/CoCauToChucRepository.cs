using AutoMapper;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;

namespace BaoTangBn.Repo.CoCauToChucRepo
{
    public class CoCauToChucRepository : ICoCauToChucRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public CoCauToChucRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public bool EditCoCauToChuc( Guid IDNguoiSua, CoCauToChucDto CoCauToChucDto)
        {
            try
            {
                var temp = _context.CoCauToChuc.FirstOrDefault();
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = CoCauToChucDto.Ten;
                    temp.TomTat = CoCauToChucDto.TomTat;
                    temp.NoiDung = CoCauToChucDto.NoiDung;
                    _context.SaveChanges();
                }
                else
                {
                    temp = _mapper.Map<CoCauToChucDto, CoCauToChuc>(CoCauToChucDto);
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    _context.CoCauToChuc.Add(temp);
                    _context.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public CoCauToChuc_Detail ShowDetails()
        {
            try
            {
                CoCauToChuc_Detail CoCauToChuc_Detail = new CoCauToChuc_Detail();
                var _CoCauToChuc = _context.CoCauToChuc.SingleOrDefault();
                CoCauToChuc_Detail.Ten = _CoCauToChuc.Ten;
                CoCauToChuc_Detail.NoiDung = _CoCauToChuc.NoiDung;
                return CoCauToChuc_Detail;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
