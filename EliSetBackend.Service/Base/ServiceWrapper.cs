using EliSetBackend.Core.Model.Base;
using EliSetBackend.Data.Base;
using EliSetBackend.Service.Local.Interface;
using EliSetBackend.Service.Local.Service;
using Microsoft.Extensions.Options;


namespace EliSetBackend.Service.Base
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly IOptions<AppSettings> _appSettings;
        private IRepositoryWrapper _repository;
        public ServiceWrapper(IRepositoryWrapper repository, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            _repository = repository;
        }

        public IClotheService Clothe => new ClotheService(_repository);

        public IPictureService Picture => new PictureService(_repository,_appSettings);

        public ICategoryService Category => new CategoryService(_repository);

        public void Save()

        {
            _repository.Save();
        }
    }
}
