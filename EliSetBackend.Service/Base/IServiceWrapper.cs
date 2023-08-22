using EliSetBackend.Service.Local.Interface;

namespace EliSetBackend.Service.Base
{
    public interface IServiceWrapper
    {
        IClotheService Clothe { get; }
        IPictureService Picture { get; }
        ICategoryService Category { get; }
        void Save();
    }
}
