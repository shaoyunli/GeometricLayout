using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GeometricLayout.Controllers;
using GeometricLayout.Services;
using GeometricLayout.Interfaces;

namespace GeometricLayoutTest.Controllers
{
    [TestClass]
    public class LayoutControllerTest
    {
        private Mock<ILayoutService> mockLayoutService;
        private LayoutController layoutController;

        [TestInitialize]
        public void Setup()
        {
            mockLayoutService = new Mock<ILayoutService>();
        }

        [TestMethod]
        public void GetAll_Verify_Service_GetAll_Called()
        {
            // arrange
            var mockTriangles = new List<ITriangle>();

            for(var i = 0; i < 72; i++)
            {
                var mockTriangle = new Mock<ITriangle>();
                mockTriangles.Add(mockTriangle.Object);
            }

            mockLayoutService.Setup(src => src.GetAll()).Returns(mockTriangles);

            layoutController = new LayoutController(mockLayoutService.Object);

            // act
            var okResult = layoutController.GetAll();

            // assert
            Assert.AreEqual(mockTriangles, okResult.Value);
            mockLayoutService.Verify(srv => srv.GetAll(), Times.Once);
        }
    }
}
