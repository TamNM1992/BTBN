using BaoTangBn.Data.Dtos;
using BaoTangBn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Repo.AlbumRepo
{
    public interface IAlbumRepository
    {
        public IEnumerable<Album> GetAll();
        public bool AddAlbum(Album Album);
        public bool XoaAlbum(Guid IDBaiCanXoa, Guid IDNguoiXoa);
        public bool EditAlbum(Guid IDBaiCanSua, Guid IDNguoiSua, AlbumDto AlbumDto);
        public string ShowDetails(Guid id);
        
    }
}
