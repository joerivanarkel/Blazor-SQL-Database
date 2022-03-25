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
    public class CityControllerTest
    {
        [Fact]
        public void ShouldReturnCollectionOfCity()
        {
            IBaseService<City> mockService = MockUtility.GetMockService<City>();

            BaseController<City> controller = new BaseController<City>(mockService);
            var foundentities = controller.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnCity()
        {
            IBaseService<City> mockService = MockUtility.GetMockService<City>();

            BaseController<City> controller = new BaseController<City>(mockService);
            var foundentity = controller.GetById(1);
            Assert.IsType<City>(foundentity);
        }

        [Fact]
        public void ShouldCreateCity()
        {
            IBaseService<City> mockService = MockUtility.GetMockService<City>();

            City mockEntity = MockModelService.GetMockCity();

            BaseController<City> controller = new BaseController<City>(mockService);
            bool success = controller.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeleteCity()
        {
            IBaseService<City> mockService = MockUtility.GetMockService<City>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseController<City> controller = new BaseController<City>(mockService);
            bool success = controller.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdateCity()
        {
            IBaseService<City> mockService = MockUtility.GetMockService<City>();

            City mockEntity = MockModelService.GetMockCity();

            BaseController<City> controller = new BaseController<City>(mockService);
            bool success = controller.Update(mockEntity);

            Assert.True(success);
        }
    }
}