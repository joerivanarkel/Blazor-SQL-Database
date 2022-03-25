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
    public class DistrictControllerTest
    {
        [Fact]
        public void ShouldReturnCollectionOfDistrict()
        {
            IBaseService<District> mockService = MockUtility.GetMockService<District>();

            BaseController<District> controller = new BaseController<District>(mockService);
            var foundentities = controller.GetAll();
            Assert.NotEmpty(foundentities);
        }

        [Fact]
        public void ShouldReturnDistrict()
        {
            IBaseService<District> mockService = MockUtility.GetMockService<District>();

            BaseController<District> controller = new BaseController<District>(mockService);
            var foundentity = controller.GetById(1);
            Assert.IsType<District>(foundentity);
        }

        [Fact]
        public void ShouldCreateDistrict()
        {
            IBaseService<District> mockService = MockUtility.GetMockService<District>();

            District mockEntity = MockModelService.GetMockDistrict();

            BaseController<District> controller = new BaseController<District>(mockService);
            bool success = controller.Create(mockEntity);

            Assert.True(success);
        }

        [Fact]
        public void ShouldDeleteDistrict()
        {
            IBaseService<District> mockService = MockUtility.GetMockService<District>();

            Fixture fixture = new Fixture();
            int mockId = fixture.Create<int>();

            BaseController<District> controller = new BaseController<District>(mockService);
            bool success = controller.Delete(mockId);

            Assert.True(success);
        }

        [Fact]
        public void ShouldUpdateDistrict()
        {
            IBaseService<District> mockService = MockUtility.GetMockService<District>();

            District mockEntity = MockModelService.GetMockDistrict();

            BaseController<District> controller = new BaseController<District>(mockService);
            bool success = controller.Update(mockEntity);

            Assert.True(success);
        }
    }
}