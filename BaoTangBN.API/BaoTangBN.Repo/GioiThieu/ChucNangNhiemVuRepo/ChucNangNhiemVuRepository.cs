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

namespace BaoTangBn.Repo.ChucNangNhiemVuRepo
{
    public class ChucNangNhiemVuRepository : IChucNangNhiemVuRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public ChucNangNhiemVuRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public bool EditChucNangNhiemVu( Guid IDNguoiSua, ChucNangNhiemVuDto ChucNangNhiemVuDto)
        {
            try
            {
                var temp = _context.ChucNangNhiemVu.FirstOrDefault();
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = ChucNangNhiemVuDto.Ten;
                    temp.TomTat = ChucNangNhiemVuDto.TomTat;
                    temp.NoiDung = ChucNangNhiemVuDto.NoiDung;
                    _context.SaveChanges();
                }
                else
                {
                    temp = _mapper.Map<ChucNangNhiemVuDto, ChucNangNhiemVu>(ChucNangNhiemVuDto);
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    _context.ChucNangNhiemVu.Add(temp);
                    _context.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public ChucNangNhiemVu_Detail ShowDetails()
        {
            try
            {
                ChucNangNhiemVu_Detail ChucNangNhiemVu_Detail = new ChucNangNhiemVu_Detail();
                var _ChucNangNhiemVu = _context.ChucNangNhiemVu.SingleOrDefault();
                ChucNangNhiemVu_Detail.Ten = _ChucNangNhiemVu.Ten;
                ChucNangNhiemVu_Detail.NoiDung = _ChucNangNhiemVu.NoiDung;
                return ChucNangNhiemVu_Detail;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
