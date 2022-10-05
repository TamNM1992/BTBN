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

namespace BaoTangBn.Repo.GioiThieuChungRepo
{
    public class GioiThieuChungRepository : IGioiThieuChungRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public GioiThieuChungRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public bool EditGioiThieuChung( Guid IDNguoiSua, GioiThieuChungDto GioiThieuChungDto)
        {
            try
            {
                var temp = _context.GioiThieuChung.FirstOrDefault();
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = GioiThieuChungDto.Ten;
                    temp.TomTat = GioiThieuChungDto.TomTat;
                    temp.NoiDung = GioiThieuChungDto.NoiDung;
                    _context.SaveChanges();
                }
                else
                {
                    temp = _mapper.Map<GioiThieuChungDto, GioiThieuChung>(GioiThieuChungDto);
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    _context.GioiThieuChung.Add(temp);
                    _context.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public GioiThieuChung_Detail ShowDetails()
        {
            try
            {
                GioiThieuChung_Detail GioiThieuChung_Detail = new GioiThieuChung_Detail();
                var _GioiThieuChung = _context.GioiThieuChung.SingleOrDefault();
                GioiThieuChung_Detail.Ten = _GioiThieuChung.Ten;
                GioiThieuChung_Detail.NoiDung = _GioiThieuChung.NoiDung;
                return GioiThieuChung_Detail;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
