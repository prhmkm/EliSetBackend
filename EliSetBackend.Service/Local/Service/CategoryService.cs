using EliSetBackend.Core.Model.Base;
using EliSetBackend.Data.Base;
using EliSetBackend.Domain.Models;
using EliSetBackend.Service.Local.Interface;
using Microsoft.Extensions.Options;

namespace EliSetBackend.Service.Local.Service
{
    public class CategoryService : ICategoryService
    {
        IRepositoryWrapper _repository;


        public CategoryService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public List<Category> GetCategories()
        {
            return _repository.Category.GetCategories();
        }
    }
}
