using AutoFixture;
using Business;
using Common.Models;
using Data.Repositories.Interfaces;
using Xunit;

namespace Test.Business
{
    public class LogServiceTest
    {
        [Fact]
        public void ShouldReturnCollectionOfLog()
        {
            IRepository<Log> mockRepository = MockUtility.GetMockRepository<Log>();

            BaseService<Log> service = new BaseService<Log>(mockRepository);
            var foundentities = service.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnLog()
        {
            IRepository<Log> mockRepository = MockUtility.GetMockRepository<Log>();

            BaseService<Log> service = new BaseService<Log>(mockRepository);
            var foundentity = service.GetById(1);
            Assert.IsType<Log>(foundentity);
        }

        [Fact]
        public void ShouldCreateLog()
        {
            IRepository<Log> mockRepository = MockUtility.GetMockRepository<Log>();

            Log mockEntity = MockModelService.GetMockLog();

            BaseService<Log> service = new BaseService<Log>(mockRepository);
            bool success = service.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeleteLog()
        {
            IRepository<Log> mockRepository = MockUtility.GetMockRepository<Log>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseService<Log> service = new BaseService<Log>(mockRepository);
            bool success = service.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdateLog()
        {
            IRepository<Log> mockRepository = MockUtility.GetMockRepository<Log>();

            Log mockEntity = MockModelService.GetMockLog();


            BaseService<Log> service = new BaseService<Log>(mockRepository);
            bool success = service.Update(mockEntity);

            Assert.True(success);
        }
    }
}