using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.TrungBayLuuDongRepo;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.TrungBayLuuDongService
{
    public class TrungBayLuuDongService : ITrungBayLuuDongService
    {
        private ITrungBayLuuDongRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public TrungBayLuuDongService(ITrungBayLuuDongRepository repo, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<TrungBayLuuDong_ShowOnViewer> GetList(bool admin)
        {
            List<TrungBayLuuDong_ShowOnViewer> temp1 = new List<TrungBayLuuDong_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<TrungBayLuuDong, TrungBayLuuDong_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<TrungBayLuuDong_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<TrungBayLuuDong_ShowOnUser> temp1 = new List<TrungBayLuuDong_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].TieuDe.Contains(keyWord) == true)
                {
                    temp1.Add(_mapper.Map<TrungBayLuuDong, TrungBayLuuDong_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }
        public IEnumerable<TrungBayLuuDong_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            TrungBayLuuDong[] array = new TrungBayLuuDong[pre_count + next_count];
            var temp = _repo.GetRelated();
            temp.SortByField("asc", "NgayTao");
            TrungBayLuuDong[] arraytemp = temp.ToArray();
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
            TrungBayLuuDong_Related[] relate = new TrungBayLuuDong_Related[pre_count + next_count];
            for (i = 0; i < array.Length; i++)
            {
                relate[i] = _mapper.Map<TrungBayLuuDong, TrungBayLuuDong_Related>(array[i]);
            }
            relate.ToList();

            return relate;

        }
        public bool AddTrungBayLuuDong(TrungBayLuuDongDto TrungBayLuuDongDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var TrungBayLuuDongEntity = _mapper.Map<TrungBayLuuDongDto, TrungBayLuuDong>(TrungBayLuuDongDto);

            TrungBayLuuDongEntity.IDNguoiTao = _userID;

            TrungBayLuuDongEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddTrungBayLuuDong(TrungBayLuuDongEntity);
            return temp;
        }
        public bool XoaTrungBayLuuDong(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaTrungBayLuuDong(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditTrungBayLuuDong(Guid IDBaiCanSua, string token, TrungBayLuuDongDto TrungBayLuuDongDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditTrungBayLuuDong(IDBaiCanSua, IDNguoiSua, TrungBayLuuDongDto);
            return temp;
        }
        public TrungBayLuuDong_Detail ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }
    }
}
