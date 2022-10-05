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

namespace BaoTangBn.Repo.ChiDanRepo
{
    public class ChiDanRepository : IChiDanRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public ChiDanRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public bool EditChiDan( Guid IDNguoiSua, ChiDanDto ChiDanDto)
        {
            try
            {
                var temp = _context.ChiDan.FirstOrDefault();
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = ChiDanDto.Ten;
                    temp.TomTat = ChiDanDto.TomTat;
                    temp.NoiDung = ChiDanDto.NoiDung;
                    _context.SaveChanges();
                }
                else
                {
                    temp = _mapper.Map<ChiDanDto, ChiDan>(ChiDanDto);
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    _context.ChiDan.Add(temp);
                    _context.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public ChiDan_Detail ShowDetails()
        {
            try
            {
                ChiDan_Detail chiDan_Detail = new ChiDan_Detail();
                var _ChiDan = _context.ChiDan.SingleOrDefault();
                chiDan_Detail.Ten = _ChiDan.Ten;
                chiDan_Detail.NoiDung = _ChiDan.NoiDung;
                return chiDan_Detail;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
