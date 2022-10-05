using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.AlbumRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.AlbumService
{

    public class AlbumService : IAlbumService
    {
        private IAlbumRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public AlbumService(IAlbumRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<Album_ShowOnViewer> GetList(bool admin)
        {
            List<Album_ShowOnViewer> temp1 = new List<Album_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            if (admin == false)
            {
                temp3.RemoveAll(x => x.TrangThaiXuatBan == false);
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<Album, Album_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }
        public IEnumerable<Album_ShowOnUser> SearchByTenAndTieuDe(string keyWord)
        {
            List<Album_ShowOnUser> temp1 = new List<Album_ShowOnUser>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);
            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i].Ten.Contains(keyWord) == true || temp3[i].Mota.Contains(keyWord) == true)
                {
                    temp1.Add (_mapper.Map<Album, Album_ShowOnUser>(temp3[i]));
                }
            }
            return temp1;
        }

        public bool AddAlbum(AlbumDto AlbumDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var AlbumEntity = _mapper.Map<AlbumDto, Album>(AlbumDto);

            AlbumEntity.IDNguoiTao = _userID;

            AlbumEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddAlbum(AlbumEntity);
            return temp;
        }
        public bool XoaAlbum(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaAlbum(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditAlbum(Guid IDBaiCanSua, string token, AlbumDto AlbumDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditAlbum(IDBaiCanSua,IDNguoiSua, AlbumDto);
            return temp;
        }
        public string ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }

    }
}