using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.KienThucLichSuVanHoaRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.KienThucLichSuVanHoaService
{

    public class KienThucLichSuVanHoaService : IKienThucLichSuVanHoaService
    {
        private IKienThucLichSuVanHoaRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public KienThucLichSuVanHoaService(IKienThucLichSuVanHoaRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<KienThucLichSuVanHoa_ShowOnViewer> GetList(bool admin)
        {
            List<KienThucLichSuVanHoa_ShowOnViewer> temp1 = new List<KienThucLichSuVanHoa_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<KienThucLichSuVanHoa, KienThucLichSuVanHoa_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<KienThucLichSuVanHoa_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<KienThucLichSuVanHoa_ShowOnUser> temp1 = new List<KienThucLichSuVanHoa_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].TieuDe.Contains(keyWord) == true)
                {
                    temp1.Add (_mapper.Map<KienThucLichSuVanHoa, KienThucLichSuVanHoa_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }
        public IEnumerable<KienThucLichSuVanHoa_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            KienThucLichSuVanHoa[] array = new KienThucLichSuVanHoa[pre_count + next_count];
            var temp = _repo.GetRelated();
            temp.SortByField("asc", "NgayTao");
            KienThucLichSuVanHoa[] arraytemp = temp.ToArray();
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
            KienThucLichSuVanHoa_Related[] relate = new KienThucLichSuVanHoa_Related[pre_count + next_count];
            for ( i = 0; i< array.Length; i++)
            {
                relate[i] = _mapper.Map<KienThucLichSuVanHoa, KienThucLichSuVanHoa_Related>(array[i]);
            }
            relate.ToList();
            
            return relate;

        }
        public bool AddKienThucLichSuVanHoa(KienThucLichSuVanHoaDto KienThucLichSuVanHoaDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var KienThucLichSuVanHoaEntity = _mapper.Map<KienThucLichSuVanHoaDto, KienThucLichSuVanHoa>(KienThucLichSuVanHoaDto);

            KienThucLichSuVanHoaEntity.IDNguoiTao = _userID;

            KienThucLichSuVanHoaEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddKienThucLichSuVanHoa(KienThucLichSuVanHoaEntity);
            return temp;
        }
        public bool XoaKienThucLichSuVanHoa(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaKienThucLichSuVanHoa(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditKienThucLichSuVanHoa(Guid IDBaiCanSua, string token, KienThucLichSuVanHoaDto KienThucLichSuVanHoaDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditKienThucLichSuVanHoa(IDBaiCanSua,IDNguoiSua, KienThucLichSuVanHoaDto);
            return temp;
        }
        public KienThucLichSuVanHoa_Detail ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }

    }
}