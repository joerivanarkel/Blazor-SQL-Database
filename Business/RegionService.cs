using Business;
using Common.Models;
using Data.Repositories;

namespace Business
{
    public class RegionService : BaseService<Region>, IRegionService
    {
        public RegionService(IRegionRepository regionRepository) : base(regionRepository) { }
    }
}

public interface IRegionService : IBaseService<Region> { }