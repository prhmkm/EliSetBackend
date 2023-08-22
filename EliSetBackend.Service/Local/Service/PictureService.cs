using EliSetBackend.Core.Helpers;
using EliSetBackend.Core.Model.Base;
using EliSetBackend.Data.Base;
using EliSetBackend.Domain.Models;
using EliSetBackend.Service.Local.Interface;
using Microsoft.Extensions.Options;
using static EliSetBackend.Domain.DTOs.PictureDTO;

namespace EliSetBackend.Service.Local.Service
{
    public class PictureService : IPictureService
    {
        IRepositoryWrapper _repository;
        private readonly AppSettings _appSettings;

        public PictureService(IRepositoryWrapper repository, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _repository = repository;
        }
        public void DeleteById(long id)
        {
            _repository.Picture.DeleteById(id);
        }

        public List<Picture> FindByFolderId(long id)
        {
            return _repository.Picture.FindByFolderId(id);
        }
        public PictureResponse FindById(long? id)
        {
            return _repository.Picture.FindById(id);
        }

        public UploadPic Upload(string objectId, string picture, int? id, int clothesId)
        {
            List<string> _imagName = objectId.Split(".").ToList();
            string imgName = null;
            for (int i = 0; i < _imagName.Count - 1; i++)
            {
                imgName = imgName + _imagName[i] + ".";
            }
            string path = Path.Combine(_appSettings.SaveImagePath + "\\");
            if (id == 1)
            {
                path = Path.Combine(_appSettings.SaveImagePath + "\\Clothes\\");
            }
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string Address = null;
            string imageName = null;

            imageName = Convertor.Base64ToImage(picture, path, objectId.Split(".")[0]);
            Address = _appSettings.PublishImagePath + "//" + imageName;

            //if (thumbnail == true)
            //{
            //    imageNameThumb = Convertor.Base64ToThumbnail(picture, path, objectId.Split(".")[0] + "thumb" /*+ _imagName[_imagName.Count - 1]*/);
            //    thumbnailAddress = null;
            //}

            if (id == 1)
            {
                Address = _appSettings.PublishImagePath + "//Clothes//" + imageName;
            }
            

            //if (thumbnail == true)
            //{
            //    thumbnailAddress = _appSettings.PublishImagePath + "//" + imageNameThumb;
            //    if (id == 1)
            //    {
            //        thumbnailAddress = _appSettings.PublishImagePath + "//Sliders//" + imageNameThumb;
            //    }
            //    if (id == 2)
            //    {
            //        thumbnailAddress = _appSettings.PublishImagePath + "//News//" + imageNameThumb;
            //    }
            //    if (id == 3)
            //    {
            //        thumbnailAddress = _appSettings.PublishImagePath + "//FixedBasicSettings//" + imageNameThumb;
            //    }
            //    if (id == 4)
            //    {
            //        thumbnailAddress = _appSettings.PublishImagePath + "//DataCards//" + imageNameThumb;
            //    }
            //    if (id == 5)
            //    {
            //        thumbnailAddress = _appSettings.PublishImagePath + "//Counters//" + imageNameThumb;
            //    }
            //    if (id == 6)
            //    {
            //        thumbnailAddress = _appSettings.PublishImagePath + "//ContentCards//" + imageNameThumb;
            //    }
            //    if (id == 7)
            //    {
            //        thumbnailAddress = _appSettings.PublishImagePath + "//Blogs//" + imageNameThumb;
            //    }
            //    if (id == 8)
            //    {
            //        thumbnailAddress = _appSettings.PublishImagePath + "//PartnerCompanies//" + imageNameThumb;
            //    }
            //    if (id == 9)
            //    {
            //        thumbnailAddress = _appSettings.PublishImagePath + "//Events//" + imageNameThumb;
            //    }
            //}
            if (imageName == "crash")
            {
                return new UploadPic { Address = null, Id = 0 };
            }
            return new UploadPic { Address = Address, Id = _repository.Picture.Add(new Picture { Address = Address, ImageName = imageName, ClothesId = clothesId }) };
        }

        public Picture GetByAddress(string address)
        {
            return _repository.Picture.GetByAddress(address);
        }
    }
}
