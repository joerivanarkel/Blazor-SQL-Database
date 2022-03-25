using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Business;
using Business.Interfaces;
using Common.Models;
using Xunit;
using API;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Test.API
{
    public class PersonControllerTest
    {
        [Fact]
        public void ShouldReturnCollectionOfPerson()
        {
            IBaseService<Person> mockService = MockUtility.GetMockService<Person>();

            BaseController<Person> controller = new BaseController<Person>(mockService);
            var foundentities = controller.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnPerson()
        {
            IBaseService<Person> mockService = MockUtility.GetMockService<Person>();

            BaseController<Person> controller = new BaseController<Person>(mockService);
            var foundentity = controller.GetById(1);
            Assert.IsType<Person>(foundentity);
        }

        [Fact]
        public void ShouldCreatePerson()
        {
            IBaseService<Person> mockService = MockUtility.GetMockService<Person>();

            Person mockEntity = MockModelService.GetMockPerson();

            BaseController<Person> controller = new BaseController<Person>(mockService);
            bool success = controller.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeletePerson()
        {
            IBaseService<Person> mockService = MockUtility.GetMockService<Person>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseController<Person> controller = new BaseController<Person>(mockService);
            bool success = controller.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdatePerson()
        {
            IBaseService<Person> mockService = MockUtility.GetMockService<Person>();

            Person mockEntity = MockModelService.GetMockPerson();

            BaseController<Person> controller = new BaseController<Person>(mockService);
            bool success = controller.Update(mockEntity);

            Assert.True(success);
        }
    }
}