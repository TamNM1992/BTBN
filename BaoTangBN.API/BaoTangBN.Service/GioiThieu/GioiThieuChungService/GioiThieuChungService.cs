using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.GioiThieuChungRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.GioiThieuChungService
{

    public class GioiThieuChungService : IGioiThieuChungService
    {
        private IGioiThieuChungRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public GioiThieuChungService(IGioiThieuChungRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

       
        public bool EditGioiThieuChung( string token, GioiThieuChungDto GioiThieuChungDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditGioiThieuChung(IDNguoiSua, GioiThieuChungDto);
            return temp;
        }
        public GioiThieuChung_Detail ShowDetails()
        {
            return _repo.ShowDetails();
        }

    }
}