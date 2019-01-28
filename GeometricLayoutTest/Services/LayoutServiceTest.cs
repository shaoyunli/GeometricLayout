using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GeometricLayout.Services;
using GeometricLayout.Interfaces;
using GeometricLayout.Models;

namespace GeometricLayoutTest.Services
{
    [TestClass]
   public class LayoutServiceTest
    {
        private Mock<ILayoutServiceValidator> layoutServiceValidator;
        private Mock<ITriangleConverter> triangleBuilder;
        private LayoutService layoutService;
        
        [TestInitialize]
        public void Setup()
        {
            layoutServiceValidator = new Mock<ILayoutServiceValidator>();
            triangleBuilder = new Mock<ITriangleConverter>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetByRowColumn_Input_Validation_Failed()
        {
            // arrange
            var row = 'R';
            var column = 9;
            layoutServiceValidator.Setup(validator => validator.ValidateByRowColumn(row, column)).Throws(new ArgumentOutOfRangeException());
            
            // act
            layoutService = new LayoutService(layoutServiceValidator.Object, triangleBuilder.Object);
            layoutService.GetByRowColumn(row, column);

            // assert
            triangleBuilder.Verify(builder => builder.ConvertToRightTriangle(It.IsAny<char>(), It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void GetByRowColumn_Successful()
        {
            // arrange
            var row = 'R';
            var column = 9;
            var triangle = new Triangle();            
            triangleBuilder.Setup(builder => builder.ConvertToRightTriangle(row, column)).Returns(triangle);

            // act
            layoutService = new LayoutService(layoutServiceValidator.Object, triangleBuilder.Object);
            var result = layoutService.GetByRowColumn(row, column);

            // assert
            Assert.AreEqual(triangle, result);
            layoutServiceValidator.Verify(validator => validator.ValidateByRowColumn(row, column), Times.Once);
            triangleBuilder.Verify(builder => builder.ConvertToRightTriangle(row, column), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetByCoordinates_Input_Validation_Failed()
        {
            // arrange
            var x1 = 10;
            var y1 = 30;
            var x2 = 10;
            var y2 = 20;
            var x3 = 20;
            var y3 = 30;

            layoutServiceValidator.Setup(validator => validator.ValidateByCoordinates(x1, y1, x2, y2, x3, y3)).Throws(new ArgumentOutOfRangeException());

            // act
            layoutService = new LayoutService(layoutServiceValidator.Object, triangleBuilder.Object);
            layoutService.GetByCoordinates(x1, y1, x2, y2, x3, y3);

            // assert
            layoutServiceValidator.Verify(validator => validator.ValidateByCoordinates(x1, y1, x2, y2, x3, y3), Times.Once);
        }

        [TestMethod]
        public void GetByCoordinates_Successful_Returns_RightTriangle_Location()
        {
            // arrange
            var x1 = 10;
            var y1 = 30;
            var x2 = 10;
            var y2 = 20;
            var x3 = 20;
            var y3 = 30;
            var location = new TriangleLocation() {
                Row = 'F',
                Column = 1
            };

            triangleBuilder.Setup(builder => builder.ConvertToLocation(x1, y1, x2, y2, x3, y3)).Returns(location);

            // act
            layoutService = new LayoutService(layoutServiceValidator.Object, triangleBuilder.Object);
            var result = layoutService.GetByCoordinates(x1, y1, x2, y2, x3, y3);

            // assert
            layoutServiceValidator.Verify(validator => validator.ValidateByCoordinates(x1, y1, x2, y2, x3, y3), Times.Once);
            triangleBuilder.Verify(builder => builder.ConvertToLocation(x1, y1, x2, y2, x3, y3), Times.Once);
            Assert.AreEqual(result, location);
        }
    }
}
