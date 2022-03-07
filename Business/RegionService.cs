using Common.Models;
using Data.Repositories;
using Business.Interfaces;

namespace Business
{
    public class RegionService : BaseService<Region>, IRegionService
    {
        public RegionService(IRegionRepository regionRepository) : base(regionRepository) { }
    }
}
