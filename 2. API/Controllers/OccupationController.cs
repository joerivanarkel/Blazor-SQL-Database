using Common.Models;
using Business.Interfaces;

namespace API.Controllers
{
    public class OccupationController : BaseController<Occupation>
    {
        public OccupationController(IOccupationService occupationService) : base(occupationService) { }
    }
}