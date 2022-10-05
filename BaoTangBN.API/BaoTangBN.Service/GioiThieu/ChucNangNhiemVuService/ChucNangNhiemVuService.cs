using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.ChucNangNhiemVuRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.ChucNangNhiemVuService
{

    public class ChucNangNhiemVuService : IChucNangNhiemVuService
    {
        private IChucNangNhiemVuRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public ChucNangNhiemVuService(IChucNangNhiemVuRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

       
        public bool EditChucNangNhiemVu( string token, ChucNangNhiemVuDto ChucNangNhiemVuDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditChucNangNhiemVu(IDNguoiSua, ChucNangNhiemVuDto);
            return temp;
        }
        public ChucNangNhiemVu_Detail ShowDetails()
        {
            return _repo.ShowDetails();
        }

    }
}