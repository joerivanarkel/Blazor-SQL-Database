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
    public class RegionControllerTest
    {
        [Fact]
        public void ShouldReturnCollectionOfRegion()
        {
            IBaseService<Region> mockService = MockUtility.GetMockService<Region>();

            BaseController<Region> controller = new BaseController<Region>(mockService);
            var foundentities = controller.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnRegion()
        {
            IBaseService<Region> mockService = MockUtility.GetMockService<Region>();

            BaseController<Region> controller = new BaseController<Region>(mockService);
            var foundentity = controller.GetById(1);
            Assert.IsType<Region>(foundentity);
        }

        [Fact]
        public void ShouldCreateRegion()
        {
            IBaseService<Region> mockService = MockUtility.GetMockService<Region>();

            Region mockEntity = MockModelService.GetMockRegion();

            BaseController<Region> controller = new BaseController<Region>(mockService);
            bool success = controller.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeleteRegion()
        {
            IBaseService<Region> mockService = MockUtility.GetMockService<Region>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseController<Region> controller = new BaseController<Region>(mockService);
            bool success = controller.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdateRegion()
        {
            IBaseService<Region> mockService = MockUtility.GetMockService<Region>();

            Region mockEntity = MockModelService.GetMockRegion();

            BaseController<Region> controller = new BaseController<Region>(mockService);
            bool success = controller.Update(mockEntity);

            Assert.True(success);
        }
    }
}