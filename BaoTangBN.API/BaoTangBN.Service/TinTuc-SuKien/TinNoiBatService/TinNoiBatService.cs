using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Common.Models;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.TinNoiBatRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BaoTangBn.Service.TinNoiBatService
{
    public class TinNoiBatService : ITinNoiBatService
    {
        private ITinNoiBatRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public TinNoiBatService(ITinNoiBatRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<TinNoiBat_ShowOnViewer> GetList(bool admin)
        {
            List<TinNoiBat_ShowOnViewer> temp1 = new List<TinNoiBat_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<TinNoiBat, TinNoiBat_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<TinNoiBat_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<TinNoiBat_ShowOnUser> temp1 = new List<TinNoiBat_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].TieuDe.Contains(keyWord) == true)
                {
                    temp1.Add (_mapper.Map<TinNoiBat, TinNoiBat_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }
        public IEnumerable<TinNoiBat_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            TinNoiBat[] array = new TinNoiBat[pre_count + next_count];
            var temp = _repo.GetRelated();
            temp.SortByField("asc", "NgayTao");
            TinNoiBat[] arraytemp = temp.ToArray();
            int i;
            int j;
            int k;
            for (i = 0; i < arraytemp.Length; i++)
            {
                if (arraytemp[i].ID == IDBaiViet)
                    break;
            }
            k = i;
            for (j = 0; j < pre_count; j++)
            {
                if (k - 1 <0)
                    break;
                array[j] = arraytemp[k-1];
                k--;
                
            }
            k = i;
            for (j = pre_count; j < array.Length; j++)
            {
                if ( k + 1>= arraytemp.Length)
                    break;
                array[j] = arraytemp[k + 1];
                k++;
                
            }
            TinNoiBat_Related[] relate = new TinNoiBat_Related[pre_count + next_count];
            for ( i = 0; i< array.Length; i++)
            {
                relate[i] = _mapper.Map<TinNoiBat, TinNoiBat_Related>(array[i]);
            }
            relate.ToList();
            
            return relate;

        }
        public bool AddTinNoiBat(TinNoiBatDto tinNoiBatDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var tinNoiBatEntity = _mapper.Map<TinNoiBatDto, TinNoiBat>(tinNoiBatDto);

            tinNoiBatEntity.IDNguoiTao = _userID;

            tinNoiBatEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddTinNoiBat(tinNoiBatEntity);
            return temp;
        }
        public bool XoaTinNoiBat(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaTinNoiBat(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditTinNoiBat(Guid IDBaiCanSua, string token, TinNoiBatDto tinNoiBatDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditTinNoiBat(IDBaiCanSua,IDNguoiSua, tinNoiBatDto);
            return temp;
        }
        public TinNoiBat_Detail ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }

    }
}