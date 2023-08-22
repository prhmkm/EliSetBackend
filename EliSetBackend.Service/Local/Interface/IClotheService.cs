using EliSetBackend.Domain.Models;
using static EliSetBackend.Domain.DTOs.ClotheDTO;

namespace EliSetBackend.Service.Local.Interface
{
    public interface IClotheService
    {
        int Add(Clothe clothe);
        void Edit(Clothe clothe);
        List<GetAllClothes> GetAll(int categoryId);
    }
}
