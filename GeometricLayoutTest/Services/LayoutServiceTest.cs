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
        private Mock<IRightTriangleBuilder> rightTriangleBuilder;
        private LayoutService layoutService;
        
        [TestInitialize]
        public void Setup()
        {
            layoutServiceValidator = new Mock<ILayoutServiceValidator>();
            rightTriangleBuilder = new Mock<IRightTriangleBuilder>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetByRowColumn_Validation_Failed()
        {
            // arrange
            var row = 'R';
            var column = 9;
            var triangle = new RightTriangle();
            layoutServiceValidator.Setup(validator => validator.ValidateByRowColumn(row, column)).Throws(new ArgumentOutOfRangeException());
            
            // act
            layoutService = new LayoutService(layoutServiceValidator.Object, rightTriangleBuilder.Object);
            layoutService.GetByRowColumn(row, column);

            // assert
            rightTriangleBuilder.Verify(builder => builder.Build(It.IsAny<char>(), It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void GetByRowColumn_Successful()
        {
            // arrange
            var row = 'R';
            var column = 9;
            var triangle = new RightTriangle();            
            rightTriangleBuilder.Setup(builder => builder.Build(row, column)).Returns(triangle);

            // act
            layoutService = new LayoutService(layoutServiceValidator.Object, rightTriangleBuilder.Object);
            var result = layoutService.GetByRowColumn(row, column);

            // assert
            Assert.AreEqual(triangle, result);
            layoutServiceValidator.Verify(validator => validator.ValidateByRowColumn(row, column), Times.Once);
            rightTriangleBuilder.Verify(builder => builder.Build(row, column), Times.Once);
        }
    }
}
