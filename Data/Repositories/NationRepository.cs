using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;

namespace Data.Repositories
{
    public class NationRepository : BaseRepository<Nation>, INationRepository
    {
        public NationRepository(Database database) : base(database){}
    }

    public interface INationRepository : IRepository<Nation> { }
}