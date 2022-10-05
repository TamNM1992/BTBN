using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.BaoVatQuocGiaRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.BaoVatQuocGiaService
{

    public class BaoVatQuocGiaService : IBaoVatQuocGiaService
    {
        private IBaoVatQuocGiaRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public BaoVatQuocGiaService(IBaoVatQuocGiaRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<BaoVatQuocGia_ShowOnViewer> GetList(bool admin)
        {
            List<BaoVatQuocGia_ShowOnViewer> temp1 = new List<BaoVatQuocGia_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<BaoVatQuocGia, BaoVatQuocGia_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<BaoVatQuocGia_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<BaoVatQuocGia_ShowOnUser> temp1 = new List<BaoVatQuocGia_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].TieuDe.Contains(keyWord) == true)
                {
                    temp1.Add (_mapper.Map<BaoVatQuocGia, BaoVatQuocGia_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }
        public IEnumerable<BaoVatQuocGia_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            BaoVatQuocGia[] array = new BaoVatQuocGia[pre_count + next_count];
            var temp = _repo.GetRelated();
            temp.SortByField("asc", "NgayTao");
            BaoVatQuocGia[] arraytemp = temp.ToArray();
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
            BaoVatQuocGia_Related[] relate = new BaoVatQuocGia_Related[pre_count + next_count];
            for ( i = 0; i< array.Length; i++)
            {
                relate[i] = _mapper.Map<BaoVatQuocGia, BaoVatQuocGia_Related>(array[i]);
            }
            relate.ToList();
            
            return relate;

        }
        public bool AddBaoVatQuocGia(BaoVatQuocGiaDto BaoVatQuocGiaDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var BaoVatQuocGiaEntity = _mapper.Map<BaoVatQuocGiaDto, BaoVatQuocGia>(BaoVatQuocGiaDto);

            BaoVatQuocGiaEntity.IDNguoiTao = _userID;

            BaoVatQuocGiaEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddBaoVatQuocGia(BaoVatQuocGiaEntity);
            return temp;
        }
        public bool XoaBaoVatQuocGia(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaBaoVatQuocGia(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditBaoVatQuocGia(Guid IDBaiCanSua, string token, BaoVatQuocGiaDto BaoVatQuocGiaDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditBaoVatQuocGia(IDBaiCanSua,IDNguoiSua, BaoVatQuocGiaDto);
            return temp;
        }
        public BaoVatQuocGia_Detail ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }

    }
}