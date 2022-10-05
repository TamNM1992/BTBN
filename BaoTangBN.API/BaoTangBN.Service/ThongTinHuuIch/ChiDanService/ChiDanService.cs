using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.ChiDanRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.ChiDanService
{

    public class ChiDanService : IChiDanService
    {
        private IChiDanRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public ChiDanService(IChiDanRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

       
        public bool EditChiDan( string token, ChiDanDto ChiDanDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditChiDan(IDNguoiSua, ChiDanDto);
            return temp;
        }
        public ChiDan_Detail ShowDetails()
        {
            return _repo.ShowDetails();
        }

    }
}