using AutoFixture;
using Business;
using Common.Models;
using Data.Repositories.Interfaces;
using Xunit;

namespace Test.Business
{
    public class OccupationServiceTest
    {
        [Fact]
        public void ShouldReturnCollectionOfOccupation()
        {
            IRepository<Occupation> mockRepository = MockUtility.GetMockRepository<Occupation>();

            BaseService<Occupation> service = new BaseService<Occupation>(mockRepository);
            var foundentities = service.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnOccupation()
        {
            IRepository<Occupation> mockRepository = MockUtility.GetMockRepository<Occupation>();

            BaseService<Occupation> service = new BaseService<Occupation>(mockRepository);
            var foundentity = service.GetById(1);
            Assert.IsType<Occupation>(foundentity);
        }

        [Fact]
        public void ShouldCreateOccupation()
        {
            IRepository<Occupation> mockRepository = MockUtility.GetMockRepository<Occupation>();

            Occupation mockEntity = MockModelService.GetMockOccupation();

            BaseService<Occupation> service = new BaseService<Occupation>(mockRepository);
            bool success = service.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeleteOccupation()
        {
            IRepository<Occupation> mockRepository = MockUtility.GetMockRepository<Occupation>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseService<Occupation> service = new BaseService<Occupation>(mockRepository);
            bool success = service.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdateOccupation()
        {
            IRepository<Occupation> mockRepository = MockUtility.GetMockRepository<Occupation>();

            Occupation mockEntity = MockModelService.GetMockOccupation();


            BaseService<Occupation> service = new BaseService<Occupation>(mockRepository);
            bool success = service.Update(mockEntity);

            Assert.True(success);
        }
    }
}