using Common.Models;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class ExistingCityRepository : BaseRepository<ExistingCity>, IExistingCityRepository
    {
        public ExistingCityRepository(Database database) : base(database) { }
    }
}