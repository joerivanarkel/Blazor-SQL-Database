using AutoFixture;
using Business;
using Common.Models;
using Data.Repositories.Interfaces;
using Xunit;

namespace Test.Business
{
    public class PersonServiceTest
    {
        [Fact]
        public void ShouldReturnCollectionOfPerson()
        {
            IRepository<Person> mockRepository = MockUtility.GetMockRepository<Person>();

            BaseService<Person> service = new BaseService<Person>(mockRepository);
            var foundentities = service.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnPerson()
        {
            IRepository<Person> mockRepository = MockUtility.GetMockRepository<Person>();

            BaseService<Person> service = new BaseService<Person>(mockRepository);
            var foundentity = service.GetById(1);
            Assert.IsType<Person>(foundentity);
        }

        [Fact]
        public void ShouldCreatePerson()
        {
            IRepository<Person> mockRepository = MockUtility.GetMockRepository<Person>();

            Person mockEntity = MockModelService.GetMockPerson();

            BaseService<Person> service = new BaseService<Person>(mockRepository);
            bool success = service.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeletePerson()
        {
            IRepository<Person> mockRepository = MockUtility.GetMockRepository<Person>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseService<Person> service = new BaseService<Person>(mockRepository);
            bool success = service.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdatePerson()
        {
            IRepository<Person> mockRepository = MockUtility.GetMockRepository<Person>();

            Person mockEntity = MockModelService.GetMockPerson();


            BaseService<Person> service = new BaseService<Person>(mockRepository);
            bool success = service.Update(mockEntity);

            Assert.True(success);
        }
    }
}