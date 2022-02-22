using Business;
using Common.Models;
using Data.Repositories;

namespace Business
{
    public class NationService : BaseService<Nation>, INationService
    {
        public NationService(INationRepository nationRepository) : base(nationRepository) { }
    }
}

public interface INationService : IBaseService<Nation> { }