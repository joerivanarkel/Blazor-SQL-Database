using Common.Models;
using Business.Interfaces;

namespace API.Controllers
{
    public class RegionController : BaseController<Region>
    {
        public RegionController(IRegionService regionService) : base(regionService) { }
    }
}