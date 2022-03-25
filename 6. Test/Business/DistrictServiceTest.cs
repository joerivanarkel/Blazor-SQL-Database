using AutoFixture;
using Business;
using Common.Models;
using Data.Repositories.Interfaces;
using Xunit;

namespace Test.Business
{
    public class DistrictServiceTest
    {
        [Fact]
        public void ShouldReturnCollectionOfDistrict()
        {
            IRepository<District> mockRepository = MockUtility.GetMockRepository<District>();

            BaseService<District> service = new BaseService<District>(mockRepository);
            var foundentities = service.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnDistrict()
        {
            IRepository<District> mockRepository = MockUtility.GetMockRepository<District>();

            BaseService<District> service = new BaseService<District>(mockRepository);
            var foundentity = service.GetById(1);
            Assert.IsType<District>(foundentity);
        }

        [Fact]
        public void ShouldCreateDistrict()
        {
            IRepository<District> mockRepository = MockUtility.GetMockRepository<District>();

            District mockEntity = MockModelService.GetMockDistrict();

            BaseService<District> service = new BaseService<District>(mockRepository);
            bool success = service.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeleteDistrict()
        {
            IRepository<District> mockRepository = MockUtility.GetMockRepository<District>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseService<District> service = new BaseService<District>(mockRepository);
            bool success = service.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdateDistrict()
        {
            IRepository<District> mockRepository = MockUtility.GetMockRepository<District>();

            District mockEntity = MockModelService.GetMockDistrict();


            BaseService<District> service = new BaseService<District>(mockRepository);
            bool success = service.Update(mockEntity);

            Assert.True(success);
        }
    }
}