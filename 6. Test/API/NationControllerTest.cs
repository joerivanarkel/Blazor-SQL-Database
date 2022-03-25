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
    public class NationControllerTest
    {
        [Fact]
        public void ShouldReturnCollectionOfNation()
        {
            IBaseService<Nation> mockService = MockUtility.GetMockService<Nation>();

            BaseController<Nation> controller = new BaseController<Nation>(mockService);
            var foundentities = controller.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnNation()
        {
            IBaseService<Nation> mockService = MockUtility.GetMockService<Nation>();

            BaseController<Nation> controller = new BaseController<Nation>(mockService);
            var foundentity = controller.GetById(1);
            Assert.IsType<Nation>(foundentity);
        }

        [Fact]
        public void ShouldCreateNation()
        {
            IBaseService<Nation> mockService = MockUtility.GetMockService<Nation>();

            Nation mockEntity = MockModelService.GetMockNation();

            BaseController<Nation> controller = new BaseController<Nation>(mockService);
            bool success = controller.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeleteNation()
        {
            IBaseService<Nation> mockService = MockUtility.GetMockService<Nation>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseController<Nation> controller = new BaseController<Nation>(mockService);
            bool success = controller.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdateNation()
        {
            IBaseService<Nation> mockService = MockUtility.GetMockService<Nation>();

            Nation mockEntity = MockModelService.GetMockNation();

            BaseController<Nation> controller = new BaseController<Nation>(mockService);
            bool success = controller.Update(mockEntity);

            Assert.True(success);
        }
    }
}