
using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Service.AlbumService
{
    public interface IAlbumService
    {
        public IEnumerable<Album_ShowOnViewer> GetList(bool admin);
        public bool AddAlbum(AlbumDto AlbumDto, string token);
        public bool XoaAlbum(Guid ID_BaiCanXoa, string token);
        public bool EditAlbum(Guid IDBaiCanSua, string token, AlbumDto AlbumDto);
        public string ShowDetails(Guid id);
        public IEnumerable<Album_ShowOnUser> SearchByTenAndTieuDe(string keyWord);
    }
}
