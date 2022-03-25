using Common.Models;
using Data.Repositories;
using Business.Interfaces;
using Data.Repositories.Interfaces;

namespace Business
{
    public class DistrictService : BaseService<District>, IDistrictService
    {
        public DistrictService(IDistrictRepository districtRepository) : base(districtRepository){}
    }
}
