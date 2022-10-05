using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.KhaiQuatKhaoCoHocRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.KhaiQuatKhaoCoHocService
{

    public class KhaiQuatKhaoCoHocService : IKhaiQuatKhaoCoHocService
    {
        private IKhaiQuatKhaoCoHocRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public KhaiQuatKhaoCoHocService(IKhaiQuatKhaoCoHocRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<KhaiQuatKhaoCoHoc_ShowOnViewer> GetList(bool admin)
        {
            List<KhaiQuatKhaoCoHoc_ShowOnViewer> temp1 = new List<KhaiQuatKhaoCoHoc_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<KhaiQuatKhaoCoHoc, KhaiQuatKhaoCoHoc_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<KhaiQuatKhaoCoHoc_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<KhaiQuatKhaoCoHoc_ShowOnUser> temp1 = new List<KhaiQuatKhaoCoHoc_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].TieuDe.Contains(keyWord) == true)
                {
                    temp1.Add (_mapper.Map<KhaiQuatKhaoCoHoc, KhaiQuatKhaoCoHoc_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }
        public IEnumerable<KhaiQuatKhaoCoHoc_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            KhaiQuatKhaoCoHoc[] array = new KhaiQuatKhaoCoHoc[pre_count + next_count];
            var temp = _repo.GetRelated();
            temp.SortByField("asc", "NgayTao");
            KhaiQuatKhaoCoHoc[] arraytemp = temp.ToArray();
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
            KhaiQuatKhaoCoHoc_Related[] relate = new KhaiQuatKhaoCoHoc_Related[pre_count + next_count];
            for ( i = 0; i< array.Length; i++)
            {
                relate[i] = _mapper.Map<KhaiQuatKhaoCoHoc, KhaiQuatKhaoCoHoc_Related>(array[i]);
            }
            relate.ToList();
            
            return relate;

        }
        public bool AddKhaiQuatKhaoCoHoc(KhaiQuatKhaoCoHocDto KhaiQuatKhaoCoHocDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var KhaiQuatKhaoCoHocEntity = _mapper.Map<KhaiQuatKhaoCoHocDto, KhaiQuatKhaoCoHoc>(KhaiQuatKhaoCoHocDto);

            KhaiQuatKhaoCoHocEntity.IDNguoiTao = _userID;

            KhaiQuatKhaoCoHocEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddKhaiQuatKhaoCoHoc(KhaiQuatKhaoCoHocEntity);
            return temp;
        }
        public bool XoaKhaiQuatKhaoCoHoc(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaKhaiQuatKhaoCoHoc(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditKhaiQuatKhaoCoHoc(Guid IDBaiCanSua, string token, KhaiQuatKhaoCoHocDto KhaiQuatKhaoCoHocDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditKhaiQuatKhaoCoHoc(IDBaiCanSua,IDNguoiSua, KhaiQuatKhaoCoHocDto);
            return temp;
        }
        public KhaiQuatKhaoCoHoc_Detail ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }

    }
}