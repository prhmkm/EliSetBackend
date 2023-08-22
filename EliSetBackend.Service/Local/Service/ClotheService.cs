using EliSetBackend.Data.Base;
using EliSetBackend.Domain.Models;
using EliSetBackend.Service.Local.Interface;
using static EliSetBackend.Domain.DTOs.ClotheDTO;

namespace EliSetBackend.Service.Local.Service
{
    public class ClotheService : IClotheService
    {
        IRepositoryWrapper _repository;

        public ClotheService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public int Add(Clothe clothe)
        {
            return _repository.Clothe.Add(clothe);
        }

        public void Edit(Clothe clothe)
        {
            _repository.Clothe.Edit(clothe);
        }

        public List<GetAllClothes> GetAll(int categoryId)
        {
            return _repository.Clothe.GetAll(categoryId);   
        }
    }
}
