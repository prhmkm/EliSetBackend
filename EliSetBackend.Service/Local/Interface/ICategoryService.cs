

using EliSetBackend.Domain.Models;

namespace EliSetBackend.Service.Local.Interface
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
    }
}
