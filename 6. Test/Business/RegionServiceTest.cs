using AutoFixture;
using Business;
using Common.Models;
using Data.Repositories.Interfaces;
using Xunit;

namespace Test.Business
{
    public class RegionServiceTest
    {
        [Fact]
        public void ShouldReturnCollectionOfRegion()
        {
            IRepository<Region> mockRepository = MockUtility.GetMockRepository<Region>();

            BaseService<Region> service = new BaseService<Region>(mockRepository);
            var foundentities = service.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnRegion()
        {
            IRepository<Region> mockRepository = MockUtility.GetMockRepository<Region>();

            BaseService<Region> service = new BaseService<Region>(mockRepository);
            var foundentity = service.GetById(1);
            Assert.IsType<Region>(foundentity);
        }

        [Fact]
        public void ShouldCreateRegion()
        {
            IRepository<Region> mockRepository = MockUtility.GetMockRepository<Region>();

            Region mockEntity = MockModelService.GetMockRegion();

            BaseService<Region> service = new BaseService<Region>(mockRepository);
            bool success = service.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeleteRegion()
        {
            IRepository<Region> mockRepository = MockUtility.GetMockRepository<Region>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseService<Region> service = new BaseService<Region>(mockRepository);
            bool success = service.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdateRegion()
        {
            IRepository<Region> mockRepository = MockUtility.GetMockRepository<Region>();

            Region mockEntity = MockModelService.GetMockRegion();


            BaseService<Region> service = new BaseService<Region>(mockRepository);
            bool success = service.Update(mockEntity);

            Assert.True(success);
        }
    }
}