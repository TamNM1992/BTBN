using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.TrungBaythuongXuyenRepo;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.TrungBayThuongXuyenService
{
    public class TrungBayThuongXuyenService : ITrungBayThuongXuyenService
    {
        private ITrungBayThuongXuyenRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public TrungBayThuongXuyenService(ITrungBayThuongXuyenRepository repo, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<TrungBayThuongXuyen_ShowOnViewer> GetList(bool admin)
        {
            List<TrungBayThuongXuyen_ShowOnViewer> temp1 = new List<TrungBayThuongXuyen_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<TrungBayThuongXuyen, TrungBayThuongXuyen_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<TrungBayThuongXuyen_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<TrungBayThuongXuyen_ShowOnUser> temp1 = new List<TrungBayThuongXuyen_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].TieuDe.Contains(keyWord) == true)
                {
                    temp1.Add(_mapper.Map<TrungBayThuongXuyen, TrungBayThuongXuyen_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }
        public IEnumerable<TrungBayThuongXuyen_Related> GetRelated(Guid IDBaiViet, int pre_count, int next_count)
        {
            TrungBayThuongXuyen[] array = new TrungBayThuongXuyen[pre_count + next_count];
            var temp = _repo.GetRelated();
            temp.SortByField("asc", "NgayTao");
            TrungBayThuongXuyen[] arraytemp = temp.ToArray();
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
            TrungBayThuongXuyen_Related[] relate = new TrungBayThuongXuyen_Related[pre_count + next_count];
            for (i = 0; i < array.Length; i++)
            {
                relate[i] = _mapper.Map<TrungBayThuongXuyen, TrungBayThuongXuyen_Related>(array[i]);
            }
            relate.ToList();

            return relate;

        }
        public bool AddTrungBayThuongXuyen(TrungBayThuongXuyenDto TrungBayThuongXuyenDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var TrungBayThuongXuyenEntity = _mapper.Map<TrungBayThuongXuyenDto, TrungBayThuongXuyen>(TrungBayThuongXuyenDto);

            TrungBayThuongXuyenEntity.IDNguoiTao = _userID;

            TrungBayThuongXuyenEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddTrungBayThuongXuyen(TrungBayThuongXuyenEntity);
            return temp;
        }
        public bool XoaTrungBayThuongXuyen(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaTrungBayThuongXuyen(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditTrungBayThuongXuyen(Guid IDBaiCanSua, string token, TrungBayThuongXuyenDto TrungBayThuongXuyenDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditTrungBayThuongXuyen(IDBaiCanSua, IDNguoiSua, TrungBayThuongXuyenDto);
            return temp;
        }
        public TrungBayThuongXuyen_Detail ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }
    }
}
