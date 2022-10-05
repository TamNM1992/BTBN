using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.HoatDongGiaoDucRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.HoatDongGiaoDucService
{

    public class HoatDongGiaoDucService : IHoatDongGiaoDucService
    {
        private IHoatDongGiaoDucRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public HoatDongGiaoDucService(IHoatDongGiaoDucRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<HoatDongGiaoDuc_ShowOnViewer> GetList(bool admin)
        {
            List<HoatDongGiaoDuc_ShowOnViewer> temp1 = new List<HoatDongGiaoDuc_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<HoatDongGiaoDuc, HoatDongGiaoDuc_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<HoatDongGiaoDuc_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<HoatDongGiaoDuc_ShowOnUser> temp1 = new List<HoatDongGiaoDuc_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].TieuDe.Contains(keyWord) == true)
                {
                    temp1.Add (_mapper.Map<HoatDongGiaoDuc, HoatDongGiaoDuc_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }
        public IEnumerable<HoatDongGiaoDuc_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            HoatDongGiaoDuc[] array = new HoatDongGiaoDuc[pre_count + next_count];
            var temp = _repo.GetRelated();
            temp.SortByField("asc", "NgayTao");
            HoatDongGiaoDuc[] arraytemp = temp.ToArray();
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
            HoatDongGiaoDuc_Related[] relate = new HoatDongGiaoDuc_Related[pre_count + next_count];
            for ( i = 0; i< array.Length; i++)
            {
                relate[i] = _mapper.Map<HoatDongGiaoDuc, HoatDongGiaoDuc_Related>(array[i]);
            }
            relate.ToList();
            
            return relate;

        }
        public bool AddHoatDongGiaoDuc(HoatDongGiaoDucDto HoatDongGiaoDucDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var HoatDongGiaoDucEntity = _mapper.Map<HoatDongGiaoDucDto, HoatDongGiaoDuc>(HoatDongGiaoDucDto);

            HoatDongGiaoDucEntity.IDNguoiTao = _userID;

            HoatDongGiaoDucEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddHoatDongGiaoDuc(HoatDongGiaoDucEntity);
            return temp;
        }
        public bool XoaHoatDongGiaoDuc(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaHoatDongGiaoDuc(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditHoatDongGiaoDuc(Guid IDBaiCanSua, string token, HoatDongGiaoDucDto HoatDongGiaoDucDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditHoatDongGiaoDuc(IDBaiCanSua,IDNguoiSua, HoatDongGiaoDucDto);
            return temp;
        }
        public HoatDongGiaoDuc_Detail ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }

    }
}