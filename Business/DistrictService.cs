using Business;
using Common.Models;
using Data.Repositories;

namespace Business
{
    public class DistrictService : BaseService<District>, IDistrictService
    {
        public DistrictService(IDistrictRepository districtRepository) : base(districtRepository){}
    }
}

public interface IDistrictService : IBaseService<District> { }