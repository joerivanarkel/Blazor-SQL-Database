using Common.Models;
using Data.Repositories;
using Business.Interfaces;
using Data.Repositories.Interfaces;

namespace Business
{
    public class ExistingCityService : BaseService<ExistingCity>, IExistingCityService
    {
        public ExistingCityService(IExistingCityRepository existingCityRepository) : base(existingCityRepository){}
    }
}
