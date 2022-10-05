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

namespace BaoTangBn.Repo.ThoiGianMoCuaRepo
{
    public class ThoiGianMoCuaRepository : IThoiGianMoCuaRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public ThoiGianMoCuaRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public bool EditThoiGianMoCua( Guid IDNguoiSua, ThoiGianMoCuaDto ThoiGianMoCuaDto)
        {
            try
            {
                var temp = _context.ThoiGianMoCua.FirstOrDefault();
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = ThoiGianMoCuaDto.Ten;
                    temp.TomTat = ThoiGianMoCuaDto.TomTat;
                    temp.NoiDung = ThoiGianMoCuaDto.NoiDung;
                    _context.SaveChanges();
                }
                else
                {
                    temp = _mapper.Map<ThoiGianMoCuaDto, ThoiGianMoCua>(ThoiGianMoCuaDto);
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    _context.ThoiGianMoCua.Add(temp);
                    _context.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public ThoiGianMoCua_Detail ShowDetails()
        {
            try
            {
                ThoiGianMoCua_Detail ThoiGianMoCua_Detail = new ThoiGianMoCua_Detail();
                var _ThoiGianMoCua = _context.ThoiGianMoCua.SingleOrDefault();
                ThoiGianMoCua_Detail.Ten = _ThoiGianMoCua.Ten;
                ThoiGianMoCua_Detail.NoiDung = _ThoiGianMoCua.NoiDung;
                return ThoiGianMoCua_Detail;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
