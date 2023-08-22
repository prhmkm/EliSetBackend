using EliSetBackend.Domain.Models;
using static EliSetBackend.Domain.DTOs.PictureDTO;

namespace EliSetBackend.Data.Interface
{
    public interface IPictureRepository
    {
        PictureResponse FindById(long? id);
        long Add(Picture picture);
        void DeleteById(long id);
        List<Picture> FindByFolderId(long id);
        Picture GetByAddress(string address);
    }
}
