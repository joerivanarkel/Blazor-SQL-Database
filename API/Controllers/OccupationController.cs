using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;

namespace API.Controllers
{
    public class OccupationController : BaseController<Occupation>
    {
        public OccupationController(IOccupationService occupationService) : base(occupationService) { }
    }
}