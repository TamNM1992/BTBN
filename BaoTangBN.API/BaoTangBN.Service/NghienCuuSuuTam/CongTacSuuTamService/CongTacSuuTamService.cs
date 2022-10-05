using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.CongTacSuuTamRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.CongTacSuuTamService
{

    public class CongTacSuuTamService : ICongTacSuuTamService
    {
        private ICongTacSuuTamRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public CongTacSuuTamService(ICongTacSuuTamRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<CongTacSuuTam_ShowOnViewer> GetList(bool admin)
        {
            List<CongTacSuuTam_ShowOnViewer> temp1 = new List<CongTacSuuTam_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<CongTacSuuTam, CongTacSuuTam_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<CongTacSuuTam_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<CongTacSuuTam_ShowOnUser> temp1 = new List<CongTacSuuTam_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].TieuDe.Contains(keyWord) == true)
                {
                    temp1.Add (_mapper.Map<CongTacSuuTam, CongTacSuuTam_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }
        public IEnumerable<CongTacSuuTam_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            CongTacSuuTam[] array = new CongTacSuuTam[pre_count + next_count];
            var temp = _repo.GetRelated();
            temp.SortByField("asc", "NgayTao");
            CongTacSuuTam[] arraytemp = temp.ToArray();
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
            CongTacSuuTam_Related[] relate = new CongTacSuuTam_Related[pre_count + next_count];
            for ( i = 0; i< array.Length; i++)
            {
                relate[i] = _mapper.Map<CongTacSuuTam, CongTacSuuTam_Related>(array[i]);
            }
            relate.ToList();
            
            return relate;

        }
        public bool AddCongTacSuuTam(CongTacSuuTamDto CongTacSuuTamDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var CongTacSuuTamEntity = _mapper.Map<CongTacSuuTamDto, CongTacSuuTam>(CongTacSuuTamDto);

            CongTacSuuTamEntity.IDNguoiTao = _userID;

            CongTacSuuTamEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddCongTacSuuTam(CongTacSuuTamEntity);
            return temp;
        }
        public bool XoaCongTacSuuTam(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaCongTacSuuTam(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditCongTacSuuTam(Guid IDBaiCanSua, string token, CongTacSuuTamDto CongTacSuuTamDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditCongTacSuuTam(IDBaiCanSua,IDNguoiSua, CongTacSuuTamDto);
            return temp;
        }
        public CongTacSuuTam_Detail ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }

    }
}