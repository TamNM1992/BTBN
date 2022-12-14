using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.HuongDanThamQuanRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.HuongDanThamQuanService
{

    public class HuongDanThamQuanService : IHuongDanThamQuanService
    {
        private IHuongDanThamQuanRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public HuongDanThamQuanService(IHuongDanThamQuanRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<HuongDanThamQuan_ShowOnViewer> GetList(bool admin)
        {
            List<HuongDanThamQuan_ShowOnViewer> temp1 = new List<HuongDanThamQuan_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<HuongDanThamQuan, HuongDanThamQuan_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<HuongDanThamQuan_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<HuongDanThamQuan_ShowOnUser> temp1 = new List<HuongDanThamQuan_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].TieuDe.Contains(keyWord) == true)
                {
                    temp1.Add (_mapper.Map<HuongDanThamQuan, HuongDanThamQuan_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }
        public IEnumerable<HuongDanThamQuan_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            HuongDanThamQuan[] array = new HuongDanThamQuan[pre_count + next_count];
            var temp = _repo.GetRelated();
            temp.SortByField("asc", "NgayTao");
            HuongDanThamQuan[] arraytemp = temp.ToArray();
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
            HuongDanThamQuan_Related[] relate = new HuongDanThamQuan_Related[pre_count + next_count];
            for ( i = 0; i< array.Length; i++)
            {
                relate[i] = _mapper.Map<HuongDanThamQuan, HuongDanThamQuan_Related>(array[i]);
            }
            relate.ToList();
            
            return relate;

        }
        public bool AddHuongDanThamQuan(HuongDanThamQuanDto HuongDanThamQuanDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var HuongDanThamQuanEntity = _mapper.Map<HuongDanThamQuanDto, HuongDanThamQuan>(HuongDanThamQuanDto);

            HuongDanThamQuanEntity.IDNguoiTao = _userID;

            HuongDanThamQuanEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddHuongDanThamQuan(HuongDanThamQuanEntity);
            return temp;
        }
        public bool XoaHuongDanThamQuan(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaHuongDanThamQuan(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditHuongDanThamQuan(Guid IDBaiCanSua, string token, HuongDanThamQuanDto HuongDanThamQuanDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditHuongDanThamQuan(IDBaiCanSua,IDNguoiSua, HuongDanThamQuanDto);
            return temp;
        }
        public HuongDanThamQuan_Detail ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }

    }
}