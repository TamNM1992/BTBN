using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.CacBoSuuTapRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.CacBoSuuTapService
{

    public class CacBoSuuTapService : ICacBoSuuTapService
    {
        private ICacBoSuuTapRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public CacBoSuuTapService(ICacBoSuuTapRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<CacBoSuuTap_ShowOnViewer> GetList(bool admin)
        {
            List<CacBoSuuTap_ShowOnViewer> temp1 = new List<CacBoSuuTap_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<CacBoSuuTap, CacBoSuuTap_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<CacBoSuuTap_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<CacBoSuuTap_ShowOnUser> temp1 = new List<CacBoSuuTap_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].TieuDe.Contains(keyWord) == true)
                {
                    temp1.Add (_mapper.Map<CacBoSuuTap, CacBoSuuTap_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }
        public IEnumerable<CacBoSuuTap_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            CacBoSuuTap[] array = new CacBoSuuTap[pre_count + next_count];
            var temp = _repo.GetRelated();
            temp.SortByField("asc", "NgayTao");
            CacBoSuuTap[] arraytemp = temp.ToArray();
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
            CacBoSuuTap_Related[] relate = new CacBoSuuTap_Related[pre_count + next_count];
            for ( i = 0; i< array.Length; i++)
            {
                relate[i] = _mapper.Map<CacBoSuuTap, CacBoSuuTap_Related>(array[i]);
            }
            relate.ToList();
            
            return relate;

        }
        public bool AddCacBoSuuTap(CacBoSuuTapDto CacBoSuuTapDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var CacBoSuuTapEntity = _mapper.Map<CacBoSuuTapDto, CacBoSuuTap>(CacBoSuuTapDto);

            CacBoSuuTapEntity.IDNguoiTao = _userID;

            CacBoSuuTapEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddCacBoSuuTap(CacBoSuuTapEntity);
            return temp;
        }
        public bool XoaCacBoSuuTap(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaCacBoSuuTap(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditCacBoSuuTap(Guid IDBaiCanSua, string token, CacBoSuuTapDto CacBoSuuTapDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditCacBoSuuTap(IDBaiCanSua,IDNguoiSua, CacBoSuuTapDto);
            return temp;
        }
        public CacBoSuuTap_Detail ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }

    }
}