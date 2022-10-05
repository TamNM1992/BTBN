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

namespace BaoTangBn.Repo.NoiQuyThamQuanRepo
{
    public class NoiQuyThamQuanRepository : INoiQuyThamQuanRepository
    {
        private readonly BaoTangBNDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public NoiQuyThamQuanRepository(BaoTangBNDataContext context, IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public bool EditNoiQuyThamQuan( Guid IDNguoiSua, NoiQuyThamQuanDto NoiQuyThamQuanDto)
        {
            try
            {
                var temp = _context.NoiQuyThamQuan.FirstOrDefault();
                if (temp != null)
                {
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    temp.Ten = NoiQuyThamQuanDto.Ten;
                    temp.TomTat = NoiQuyThamQuanDto.TomTat;
                    temp.NoiDung = NoiQuyThamQuanDto.NoiDung;
                    _context.SaveChanges();
                }
                else
                {
                    temp = _mapper.Map<NoiQuyThamQuanDto, NoiQuyThamQuan>(NoiQuyThamQuanDto);
                    temp.IDNguoiSua = IDNguoiSua;
                    temp.NgaySua = DateTime.UtcNow;
                    _context.NoiQuyThamQuan.Add(temp);
                    _context.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public NoiQuyThamQuan_Detail ShowDetails()
        {
            try
            {
                NoiQuyThamQuan_Detail NoiQuyThamQuan_Detail = new NoiQuyThamQuan_Detail();
                var _NoiQuyThamQuan = _context.NoiQuyThamQuan.SingleOrDefault();
                NoiQuyThamQuan_Detail.Ten = _NoiQuyThamQuan.Ten;
                NoiQuyThamQuan_Detail.NoiDung = _NoiQuyThamQuan.NoiDung;
                return NoiQuyThamQuan_Detail;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
