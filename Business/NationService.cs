using Common.Models;
using Data.Repositories;
using Business.Interfaces;

namespace Business
{
    public class NationService : BaseService<Nation>, INationService
    {
        public NationService(INationRepository nationRepository) : base(nationRepository) { }
    }
}
