using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GeometricLayout.Controllers;
using GeometricLayout.Services;
using GeometricLayout.Interfaces;
using GeometricLayout.Models;

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
        public void GetByRowColumn_Verify_Service_GetById_Called()
        {
            // arrange
            var row = 'F';
            var column = 1;
            var triangle = new RightTriangle()
            {
                X1 = 0,
                Y1 = 0,
                X2 = 0,
                Y2 = 10,
                X3 = 10,
                Y3 = 0
            };

            var item =new GeometricItem()
            {
                Row = row,
                Column = column,
                Triangle = triangle
            };

            mockLayoutService.Setup(src => src.GetByRowColumn(row, column)).Returns(item);
            layoutController = new LayoutController(mockLayoutService.Object);

            // act
            var okResult = layoutController.GetByRowColumn(row, column);

            // assert
            Assert.AreEqual(item, okResult.Value);
            mockLayoutService.Verify(srv => srv.GetByRowColumn(row, column), Times.Once);
        }

        [TestMethod]
        public void GetByCoordinates_Verify_Service_GetByCoordinates_Called()
        {
            // arrange
            int x1, y1, x2, y2, x3, y3;
            x1 = y1 = x2 = y3 = 0;
            y2 = x3 = 10;
            var row = 'F';
            var column = 1;

            var triangle = new RightTriangle()
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                X3 = x3,
                Y3 = y3
            };

            var geometricItem = new GeometricItem()
            {
                Row = row,
                Column = column,
                Triangle = triangle
            };

            mockLayoutService.Setup(src => src.GetByCoordinates(x1, y1, x2, y2, x3, y3)).Returns(geometricItem);

            layoutController = new LayoutController(mockLayoutService.Object);

            // act
            var okResult = layoutController.GetByCoordinates(x1, y1, x2, y2, x3, y3);

            // assert
            Assert.AreEqual(geometricItem, okResult.Value);
            mockLayoutService.Verify(srv => srv.GetByCoordinates(x1, y1, x2, y2, x3, y3), Times.Once);
        }

    }
}
