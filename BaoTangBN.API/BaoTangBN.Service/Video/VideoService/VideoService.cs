using AutoMapper;
using BaoTangBn.Common;
using BaoTangBn.Common.Extensions;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using BaoTangBn.Repo.VideoRepo;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;



namespace BaoTangBn.Service.VideoService
{

    public class VideoService : IVideoService
    {
        private IVideoRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public VideoService(IVideoRepository repo ,IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<Video_ShowOnViewer> GetList(bool admin)
        {
            List<Video_ShowOnViewer> temp1 = new List<Video_ShowOnViewer>();
            var temp2 = _repo.GetAll();
            var temp3 = temp2.ToList();

            temp3.RemoveAll(x => x.DaXoa == true);

            for (int i = 0; i < temp3.Count; i++)
            {
                temp1.Add(_mapper.Map<Video, Video_ShowOnViewer>(temp3[i]));
            }
            return temp1;
        }

        public bool AddVideo(VideoDto VideoDto, string token)
        {
            var _userID = General.GetIDInToken(token);
            var VideoEntity = _mapper.Map<VideoDto, Video>(VideoDto);

            VideoEntity.IDNguoiTao = _userID;

            VideoEntity.NgayTao = DateTime.UtcNow;
            var temp = _repo.AddVideo(VideoEntity);
            return temp;
        }
        public bool XoaVideo(Guid ID_BaiCanXoa, string token)
        {
            var ID_NguoiXoa = General.GetIDInToken(token);


            var temp = _repo.XoaVideo(ID_BaiCanXoa, ID_NguoiXoa);
            return temp;
        }
        public bool EditVideo(Guid IDBaiCanSua, string token, VideoDto VideoDto)
        {
            var IDNguoiSua = General.GetIDInToken(token);

            var temp = _repo.EditVideo(IDBaiCanSua,IDNguoiSua, VideoDto);
            return temp;
        }
        public string ShowDetails(Guid id)
        {
            return _repo.ShowDetails(id);
        }

    }
}