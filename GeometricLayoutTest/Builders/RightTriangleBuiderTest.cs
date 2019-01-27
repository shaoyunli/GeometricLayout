using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricLayout.Builders;
using GeometricLayout.Models;

namespace GeometricLayoutTest.Builders
{
    [TestClass]
    public class RightTriangleBuiderTest
    {
        private RightTriangleBuilder _rightTriangleBuilder;

        [TestInitialize]
        public void Setup()
        {
            _rightTriangleBuilder = new RightTriangleBuilder();
        }

        [TestMethod]
        public void Build_PointUp_RightTriangle_For_Odd_Column()
        {
            // arrange
            var row = 'C';
            var column = 3;
            var triangle = new RightTriangle()
            {
                X1 = 10,
                Y1 = 30,
                X2 = 10,
                Y2 = 20,
                X3 = 20,
                Y3 = 30,
            };

            // act
            var result = _rightTriangleBuilder.Build(row, column);

            // assert
            Assert.IsTrue(result.Equals(triangle));
        }

        [TestMethod]
        public void Build_PointDown_RightTriangle_For_Even_Column()
        {
            // arrange
            var row = 'C';
            var column = 4;
            var triangle = new RightTriangle()
            {
                X1 = 20,
                Y1 = 20,
                X2 = 10,
                Y2 = 20,
                X3 = 20,
                Y3 = 30,
            };

            // act
            var result = _rightTriangleBuilder.Build(row, column);

            // assert
            Assert.IsTrue(result.Equals(triangle));
        }
    }
}
