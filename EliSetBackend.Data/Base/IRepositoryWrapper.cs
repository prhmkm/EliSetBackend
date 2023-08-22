using EliSetBackend.Data.Interface;

namespace EliSetBackend.Data.Base
{
    public interface IRepositoryWrapper
    {
        IClotheRepository Clothe { get; }
        IPictureRepository Picture { get; }
        ICategoryRepository Category { get; }
        void Save();
    }
}
