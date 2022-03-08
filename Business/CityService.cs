using Common.Models;
using Data.Repositories;
using Business.Interfaces;
using Data.Repositories.Interfaces;

namespace Business;
public class CityService : BaseService<City>, ICityService
{
    public CityService(ICityRepository cityRepository): base(cityRepository){}
}
