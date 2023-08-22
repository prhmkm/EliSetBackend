using EliSetBackend.Data.Interface;
using EliSetBackend.Data.Repository;
using EliSetBackend.Domain.Models;

namespace EliSetBackend.Data.Base
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private EliSet_DBContext _repoContext;

        public RepositoryWrapper(EliSet_DBContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IClotheRepository Clothe => new ClotheRepository(_repoContext);

        public IPictureRepository Picture => new PictureRepository(_repoContext);

        public ICategoryRepository Category => new CategoryRepository(_repoContext);

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
