using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.DeTaiKhoaHocAnPhamRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.DeTaiKhoaHocAnPhamService
{

    public class DeTaiKhoaHocAnPhamService : IDeTaiKhoaHocAnPhamService
    {
        private IDeTaiKhoaHocAnPhamRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public DeTaiKhoaHocAnPhamService(IDeTaiKhoaHocAnPhamRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<DeTaiKhoaHocAnPham_ShowOnViewer> GetList(bool admin)
        {
            List<DeTaiKhoaHocAnPham_ShowOnViewer> temp1 = new List<DeTaiKhoaHocAnPham_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<DeTaiKhoaHocAnPham, DeTaiKhoaHocAnPham_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<DeTaiKhoaHocAnPham_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<DeTaiKhoaHocAnPham_ShowOnUser> temp1 = new List<DeTaiKhoaHocAnPham_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].TieuDe.Contains(keyWord) == true)
                {
                    temp1.Add (_mapper.Map<DeTaiKhoaHocAnPham, DeTaiKhoaHocAnPham_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }
        public IEnumerable<DeTaiKhoaHocAnPham_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            DeTaiKhoaHocAnPham[] array = new DeTaiKhoaHocAnPham[pre_count + next_count];
            var temp = _repo.GetRelated();
            temp.SortByField("asc", "NgayTao");
            DeTaiKhoaHocAnPham[] arraytemp = temp.ToArray();
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
            DeTaiKhoaHocAnPham_Related[] relate = new DeTaiKhoaHocAnPham_Related[pre_count + next_count];
            for ( i = 0; i< array.Length; i++)
            {
                relate[i] = _mapper.Map<DeTaiKhoaHocAnPham, DeTaiKhoaHocAnPham_Related>(array[i]);
            }
            relate.ToList();
            
            return relate;

        }
        public bool AddDeTaiKhoaHocAnPham(DeTaiKhoaHocAnPhamDto DeTaiKhoaHocAnPhamDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var DeTaiKhoaHocAnPhamEntity = _mapper.Map<DeTaiKhoaHocAnPhamDto, DeTaiKhoaHocAnPham>(DeTaiKhoaHocAnPhamDto);

            DeTaiKhoaHocAnPhamEntity.IDNguoiTao = _userID;

            DeTaiKhoaHocAnPhamEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddDeTaiKhoaHocAnPham(DeTaiKhoaHocAnPhamEntity);
            return temp;
        }
        public bool XoaDeTaiKhoaHocAnPham(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaDeTaiKhoaHocAnPham(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditDeTaiKhoaHocAnPham(Guid IDBaiCanSua, string token, DeTaiKhoaHocAnPhamDto DeTaiKhoaHocAnPhamDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditDeTaiKhoaHocAnPham(IDBaiCanSua,IDNguoiSua, DeTaiKhoaHocAnPhamDto);
            return temp;
        }
        public DeTaiKhoaHocAnPham_Detail ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }

    }
}