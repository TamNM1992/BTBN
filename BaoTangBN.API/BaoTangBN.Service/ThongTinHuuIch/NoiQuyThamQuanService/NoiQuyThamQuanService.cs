using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.NoiQuyThamQuanRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.NoiQuyThamQuanService
{

    public class NoiQuyThamQuanService : INoiQuyThamQuanService
    {
        private INoiQuyThamQuanRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public NoiQuyThamQuanService(INoiQuyThamQuanRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

       
        public bool EditNoiQuyThamQuan( string token, NoiQuyThamQuanDto NoiQuyThamQuanDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditNoiQuyThamQuan(IDNguoiSua, NoiQuyThamQuanDto);
            return temp;
        }
        public NoiQuyThamQuan_Detail ShowDetails()
        {
            return _repo.ShowDetails();
        }

    }
}