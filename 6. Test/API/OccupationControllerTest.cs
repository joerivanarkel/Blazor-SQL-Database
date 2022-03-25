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
    public class OccupationControllerTest
    {
        [Fact]
        public void ShouldReturnCollectionOfOccupation()
        {
            IBaseService<Occupation> mockService = MockUtility.GetMockService<Occupation>();

            BaseController<Occupation> controller = new BaseController<Occupation>(mockService);
            var foundentities = controller.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnOccupation()
        {
            IBaseService<Occupation> mockService = MockUtility.GetMockService<Occupation>();

            BaseController<Occupation> controller = new BaseController<Occupation>(mockService);
            var foundentity = controller.GetById(1);
            Assert.IsType<Occupation>(foundentity);
        }

        [Fact]
        public void ShouldCreateOccupation()
        {
            IBaseService<Occupation> mockService = MockUtility.GetMockService<Occupation>();

            Occupation mockEntity = MockModelService.GetMockOccupation();

            BaseController<Occupation> controller = new BaseController<Occupation>(mockService);
            bool success = controller.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeleteOccupation()
        {
            IBaseService<Occupation> mockService = MockUtility.GetMockService<Occupation>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseController<Occupation> controller = new BaseController<Occupation>(mockService);
            bool success = controller.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdateOccupation()
        {
            IBaseService<Occupation> mockService = MockUtility.GetMockService<Occupation>();

            Occupation mockEntity = MockModelService.GetMockOccupation();

            BaseController<Occupation> controller = new BaseController<Occupation>(mockService);
            bool success = controller.Update(mockEntity);

            Assert.True(success);
        }
    }
}