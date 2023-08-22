
using EliSetBackend.Domain.Models;

namespace EliSetBackend.Data.Interface
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
    }
}
