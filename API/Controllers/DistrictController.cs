using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;

namespace API.Controllers
{
    public class DistrictController : BaseController<District>
    {
        public DistrictController(IDistrictService districtService) : base(districtService) { }
    }
}