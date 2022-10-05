using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.ThoiGianMoCuaRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.ThoiGianMoCuaService
{

    public class ThoiGianMoCuaService : IThoiGianMoCuaService
    {
        private IThoiGianMoCuaRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public ThoiGianMoCuaService(IThoiGianMoCuaRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

       
        public bool EditThoiGianMoCua( string token, ThoiGianMoCuaDto ThoiGianMoCuaDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditThoiGianMoCua(IDNguoiSua, ThoiGianMoCuaDto);
            return temp;
        }
        public ThoiGianMoCua_Detail ShowDetails()
        {
            return _repo.ShowDetails();
        }

    }
}