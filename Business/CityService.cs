using Common.Models;
using Data.Repositories;

namespace Business;
public class CityService : BaseService<City>, ICityService
{
    public CityService(ICityRepository cityRepository): base(cityRepository){}
}

public interface ICityService : IBaseService<City> {}
