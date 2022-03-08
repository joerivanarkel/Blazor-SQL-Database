using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;

namespace API.Controllers
{
    public class RegionController : BaseController<Region>
    {
        public RegionController(IRegionService regionService) : base(regionService) { }
    }
}