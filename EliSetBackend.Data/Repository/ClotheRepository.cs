using EliSetBackend.Data.Base;
using EliSetBackend.Data.Interface;
using EliSetBackend.Domain.Models;
using static EliSetBackend.Domain.DTOs.ClotheDTO;

namespace EliSetBackend.Data.Repository
{
    public class ClotheRepository : BaseRepository<Clothe>, IClotheRepository
    {
        EliSet_DBContext _repositoryContext;
        public ClotheRepository(EliSet_DBContext RepositoryContext) : base(RepositoryContext)
        {
            _repositoryContext = RepositoryContext;
        }

        public int Add(Clothe clothe)
        {
            Create(clothe);
            Save();
            return clothe.Id;
        }

        public void Edit(Clothe clothe)
        {
            Update(clothe);
            Save();
        }

        public List<GetAllClothes> GetAll(int categoryId)
        {
            List<GetAllClothes> response = new List<GetAllClothes>();

            var res = _repositoryContext.Clothes.Where(s =>
            (s.IsDelete == false) &&
            (s.IsActive == true) &&
            (categoryId != 0 ? s.CategoryId == categoryId : true)).
            ToList();

            foreach (var item in res)
            {
                GetAllClothes getAllClothes = new GetAllClothes()
                {
                    Id = item.Id,
                    CategoryId = item.CategoryId,
                    CategoryTitle = _repositoryContext.Categories.FirstOrDefault(s => s.Id == item.CategoryId)?.Name,
                    Description = item.Description,
                    Title = item.Title,
                    Pictures = new List<string>()
                };
                if (_repositoryContext.Pictures.Any(s => (s.ClothesId == item.Id)))
                {
                    getAllClothes.Pictures.AddRange(GetAllPictures(item.Id));
                }
                response.Add(getAllClothes);
            }
            return response;
        }
        private List<string> GetAllPictures(int clothesId)
        {
            return _repositoryContext.Pictures.Where(s =>
            s.ClothesId == clothesId).
            Select(o => o.Address).
            ToList();
        }
    }
}
