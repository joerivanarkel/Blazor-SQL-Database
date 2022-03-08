using Common.Models;
using Data.Repositories;
using Business.Interfaces;
using Data.Repositories.Interfaces;

namespace Business
{
    public class RegionService : BaseService<Region>, IRegionService
    {
        public RegionService(IRegionRepository regionRepository) : base(regionRepository) { }
    }
}
