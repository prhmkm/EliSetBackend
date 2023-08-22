using EliSetBackend.Domain.Models;
using static EliSetBackend.Domain.DTOs.ClotheDTO;

namespace EliSetBackend.Data.Interface
{
    public interface IClotheRepository
    {
        int Add(Clothe clothe);
        void Edit(Clothe clothe);
        List<GetAllClothes> GetAll(int categoryId);
        Clothe GetById(int id);
    }
}
