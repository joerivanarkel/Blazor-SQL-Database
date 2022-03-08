using Common.Models;
using Data.Repositories;
using Business.Interfaces;
using Data.Repositories.Interfaces;

namespace Business
{
    public class OccupationService : BaseService<Occupation>, IOccupationService
    {
        public OccupationService(IOccupationRepository occupationRepository) : base(occupationRepository) { }
    }
}
