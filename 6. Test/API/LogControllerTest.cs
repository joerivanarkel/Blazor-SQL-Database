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
    public class LogControllerTest
    {
        [Fact]
        public void ShouldReturnCollectionOfLog()
        {
            IBaseService<Log> mockService = MockUtility.GetMockService<Log>();

            BaseController<Log> controller = new BaseController<Log>(mockService);
            var foundentities = controller.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnLog()
        {
            IBaseService<Log> mockService = MockUtility.GetMockService<Log>();

            BaseController<Log> controller = new BaseController<Log>(mockService);
            var foundentity = controller.GetById(1);
            Assert.IsType<Log>(foundentity);
        }

        [Fact]
        public void ShouldCreateLog()
        {
            IBaseService<Log> mockService = MockUtility.GetMockService<Log>();

            Log mockEntity = MockModelService.GetMockLog();

            BaseController<Log> controller = new BaseController<Log>(mockService);
            bool success = controller.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeleteLog()
        {
            IBaseService<Log> mockService = MockUtility.GetMockService<Log>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseController<Log> controller = new BaseController<Log>(mockService);
            bool success = controller.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdateLog()
        {
            IBaseService<Log> mockService = MockUtility.GetMockService<Log>();

            Log mockEntity = MockModelService.GetMockLog();

            BaseController<Log> controller = new BaseController<Log>(mockService);
            bool success = controller.Update(mockEntity);

            Assert.True(success);
        }
    }
}