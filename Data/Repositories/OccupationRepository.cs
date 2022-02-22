using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;

namespace Data.Repositories
{
    public class OccupationRepository : BaseRepository<Occupation>, IOccupationRepository
    {
        public OccupationRepository(Database database) : base(database){}
    }

    public interface IOccupationRepository: IRepository<Occupation> { }
}