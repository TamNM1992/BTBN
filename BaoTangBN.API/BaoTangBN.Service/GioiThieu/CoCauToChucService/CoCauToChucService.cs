using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.CoCauToChucRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.CoCauToChucService
{

    public class CoCauToChucService : ICoCauToChucService
    {
        private ICoCauToChucRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public CoCauToChucService(ICoCauToChucRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

       
        public bool EditCoCauToChuc( string token, CoCauToChucDto CoCauToChucDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditCoCauToChuc(IDNguoiSua, CoCauToChucDto);
            return temp;
        }
        public CoCauToChuc_Detail ShowDetails()
        {
            return _repo.ShowDetails();
        }

    }
}