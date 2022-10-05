using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.TrungBayChuyenDeRepo;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.TrungBayChuyenDeService
{
    public class TrungBayChuyenDeService : ITrungBayChuyenDeService
    { 
        private ITrungBayChuyenDeRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public TrungBayChuyenDeService(ITrungBayChuyenDeRepository repo, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<TrungBayChuyenDe_ShowOnViewer> GetList(bool admin)
        {
            List<TrungBayChuyenDe_ShowOnViewer> temp1 = new List<TrungBayChuyenDe_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<TrungBayChuyenDe, TrungBayChuyenDe_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<TrungBayChuyenDe_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<TrungBayChuyenDe_ShowOnUser> temp1 = new List<TrungBayChuyenDe_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].TieuDe.Contains(keyWord) == true)
                {
                    temp1.Add(_mapper.Map<TrungBayChuyenDe, TrungBayChuyenDe_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }
        public IEnumerable<TrungBayChuyenDe_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            TrungBayChuyenDe[] array = new TrungBayChuyenDe[pre_count + next_count];
            var temp = _repo.GetRelated();
            temp.SortByField("asc", "NgayTao");
            TrungBayChuyenDe[] arraytemp = temp.ToArray();
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
                if (k - 1 < 0)
                    break;
                array[j] = arraytemp[k - 1];
                k--;

            }
            k = i;
            for (j = pre_count; j < array.Length; j++)
            {
                if (k + 1 >= arraytemp.Length)
                    break;
                array[j] = arraytemp[k + 1];
                k++;

            }
            TrungBayChuyenDe_Related[] relate = new TrungBayChuyenDe_Related[pre_count + next_count];
            for (i = 0; i < array.Length; i++)
            {
                relate[i] = _mapper.Map<TrungBayChuyenDe, TrungBayChuyenDe_Related>(array[i]);
            }
            relate.ToList();

            return relate;

        }
        public bool AddTrungBayChuyenDe(TrungBayChuyenDeDto TrungBayChuyenDeDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var TrungBayChuyenDeEntity = _mapper.Map<TrungBayChuyenDeDto, TrungBayChuyenDe>(TrungBayChuyenDeDto);

            TrungBayChuyenDeEntity.IDNguoiTao = _userID;

            TrungBayChuyenDeEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddTrungBayChuyenDe(TrungBayChuyenDeEntity);
            return temp;
        }
        public bool XoaTrungBayChuyenDe(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaTrungBayChuyenDe(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditTrungBayChuyenDe(Guid IDBaiCanSua, string token, TrungBayChuyenDeDto TrungBayChuyenDeDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditTrungBayChuyenDe(IDBaiCanSua, IDNguoiSua, TrungBayChuyenDeDto);
            return temp;
        }
        public TrungBayChuyenDe_Detail ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }
    }
}
