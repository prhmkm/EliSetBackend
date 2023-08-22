using EliSetBackend.Data.Base;
using EliSetBackend.Data.Interface;
using EliSetBackend.Domain.Models;

namespace EliSetBackend.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        EliSet_DBContext _repositoryContext;
        public CategoryRepository(EliSet_DBContext RepositoryContext) : base(RepositoryContext)
        {
            _repositoryContext = RepositoryContext;
        }

        public List<Category> GetCategories()
        {
                return FindByCondition(w => w.IsDeleted == false).ToList();
            
        }
    }
}
