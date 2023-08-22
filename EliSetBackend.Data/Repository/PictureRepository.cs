﻿using EliSetBackend.Data.Base;
using EliSetBackend.Data.Interface;
using EliSetBackend.Domain.DTOs;
using EliSetBackend.Domain.Models;
using static EliSetBackend.Domain.DTOs.PictureDTO;

namespace EliSetBackend.Data.Repository
{
    public class PictureRepository : BaseRepository<Picture>, IPictureRepository
    {
        EliSet_DBContext _repositoryContext;
        public PictureRepository(EliSet_DBContext RepositoryContext) : base(RepositoryContext)
        {
            _repositoryContext = RepositoryContext;
        }


        public long Add(Picture picture)
        {
            Create(picture);
            Save();
            return picture.Id;
        }

        public void DeleteById(long id)
        {
            _repositoryContext.Remove(_repositoryContext.Pictures.FirstOrDefault(a => a.Id == id));
            _repositoryContext.SaveChanges();
        }
        public List<Picture> FindByFolderId(long id)
        {
            return _repositoryContext.Pictures.ToList();
        }

        public PictureResponse FindById(long? id)
        {
            //PictureResponse picture = new PictureResponse
            //{
            //    Address = "",
            //    FolderId = 0,
            //    Id = 0,
            //    ImageName = "",
            //    Thumbnail = ""
            //};
            //var q = (from a in _repositoryContext.Pictures
            //         join b in _repositoryContext.Folders on a.FolderId equals b.Id
            //         where a.Id == id
            //         select new PictureResponse
            //         {
            //             Id = a.Id,
            //             Address = a.Address,
            //             FolderId = a.FolderId,
            //             ImageName = a.ImageName,
            //             Thumbnail = a.Thumbnail
            //         }).FirstOrDefault();

            //if (q != null)
            //{
            //    return q;
            //}
            //else
            //{
            //    return picture;
            //}
            PictureResponse picture = new PictureResponse();
            return picture;
        }

        public Picture GetByAddress(string address)
        {
            return FindByCondition(w => w.Address == address).FirstOrDefault();
        }
    }
}
