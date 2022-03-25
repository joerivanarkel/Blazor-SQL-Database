using AutoFixture;
using Business;
using Common.Models;
using Data.Repositories.Interfaces;
using Xunit;

namespace Test.Business
{
    public class NationServiceTest
    {
        [Fact]
        public void ShouldReturnCollectionOfNation()
        {
            IRepository<Nation> mockRepository = MockUtility.GetMockRepository<Nation>();

            BaseService<Nation> service = new BaseService<Nation>(mockRepository);
            var foundentities = service.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnNation()
        {
            IRepository<Nation> mockRepository = MockUtility.GetMockRepository<Nation>();

            BaseService<Nation> service = new BaseService<Nation>(mockRepository);
            var foundentity = service.GetById(1);
            Assert.IsType<Nation>(foundentity);
        }

        [Fact]
        public void ShouldCreateNation()
        {
            IRepository<Nation> mockRepository = MockUtility.GetMockRepository<Nation>();

            Nation mockEntity = MockModelService.GetMockNation();

            BaseService<Nation> service = new BaseService<Nation>(mockRepository);
            bool success = service.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeleteNation()
        {
            IRepository<Nation> mockRepository = MockUtility.GetMockRepository<Nation>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseService<Nation> service = new BaseService<Nation>(mockRepository);
            bool success = service.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdateNation()
        {
            IRepository<Nation> mockRepository = MockUtility.GetMockRepository<Nation>();

            Nation mockEntity = MockModelService.GetMockNation();


            BaseService<Nation> service = new BaseService<Nation>(mockRepository);
            bool success = service.Update(mockEntity);

            Assert.True(success);
        }
    }
}