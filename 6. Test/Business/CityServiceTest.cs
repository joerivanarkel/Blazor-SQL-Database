using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Business;
using Common.Models;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Xunit;

namespace Test.Business
{
    public class CityServiceTest
    {
        [Fact]
        public void ShouldReturnCollectionOfCity()
        {
            IRepository<City> mockRepository = MockUtility.GetMockRepository<City>();

            BaseService<City> service = new BaseService<City>(mockRepository);
            var foundentities = service.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnCity()
        {
            IRepository<City> mockRepository = MockUtility.GetMockRepository<City>();

            BaseService<City> service = new BaseService<City>(mockRepository);
            var foundentity = service.GetById(1);
            Assert.IsType<City>(foundentity);
        }

        [Fact]
        public void ShouldCreateCity()
        {
            IRepository<City> mockRepository = MockUtility.GetMockRepository<City>();

            City mockEntity = MockModelService.GetMockCity();

            BaseService<City> service = new BaseService<City>(mockRepository);
            bool success = service.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeleteCity()
        {
            IRepository<City> mockRepository = MockUtility.GetMockRepository<City>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseService<City> service = new BaseService<City>(mockRepository);
            bool success = service.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdateCity()
        {
            IRepository<City> mockRepository = MockUtility.GetMockRepository<City>();

            City mockEntity = MockModelService.GetMockCity();

            BaseService<City> service = new BaseService<City>(mockRepository);
            bool success = service.Update(mockEntity);

            Assert.True(success);
        }
    }
}