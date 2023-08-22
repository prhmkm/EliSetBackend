using EliSetBackend.Domain.Models;
using static EliSetBackend.Domain.DTOs.PictureDTO;

namespace EliSetBackend.Service.Local.Interface
{
    public interface IPictureService
    {
        PictureResponse FindById(long? id);
        UploadPic Upload(string objectId, string picture, int? id,int clothesId);
        void DeleteById(long id);
        List<Picture> FindByFolderId(long id);
        public Picture GetByAddress(string address);
    }
}
