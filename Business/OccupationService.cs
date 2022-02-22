using Business;
using Common.Models;
using Data.Repositories;

namespace Business
{
    public class OccupationService : BaseService<Occupation>, IOccupationService
    {
        public OccupationService(IOccupationRepository occupationRepository) : base(occupationRepository) { }
    }
}

public interface IOccupationService : IBaseService<Occupation> { }