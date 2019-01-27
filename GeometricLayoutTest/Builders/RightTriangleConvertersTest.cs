using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricLayout.Builders;
using GeometricLayout.Models;

namespace GeometricLayoutTest.Builders
{
    [TestClass]
    public class RightTriangleConvertersTest
    {
        private RightTriangleConverter _rightTriangleConverter;

        [TestInitialize]
        public void Setup()
        {
            _rightTriangleConverter = new RightTriangleConverter();
        }

        [TestMethod]
        public void ConvertToRightTriangle_PointUp_RightTriangle_For_Odd_Column()
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
            var result = _rightTriangleConverter.ConvertToRightTriangle(row, column);

            // assert
            Assert.IsTrue(result.Equals(triangle));
        }

        [TestMethod]
        public void ConvertToRightTriangle_PointDown_RightTriangle_For_Even_Column()
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
            var result = _rightTriangleConverter.ConvertToRightTriangle(row, column);

            // assert
            Assert.IsTrue(result.Equals(triangle));
        }

        [TestMethod]
        public void ConvertToLocation_PointUp_RightTriangle_For_Odd_Column()
        {
            // arrange
            var x1 = 10;
            var y1 = 30;
            var x2 = 10;
            var y2 = 20;
            var x3 = 20;
            var y3 = 30;

            TriangleLocation location = new TriangleLocation()
            {
                Row = 'C',
                Column = 3
            };

            // act
            var result = _rightTriangleConverter.ConvertToLocation(x1, y1, x2, y2, x3, y3);

            // assert
            Assert.AreEqual(location, result);
        }

        [TestMethod]
        public void ConvertToLocation_PointDown_RightTriangle_For_Even_Column()
        {
            // arrange
            var x1 = 20;
            var y1 = 20;
            var x2 = 10;
            var y2 = 20;
            var x3 = 20;
            var y3 = 30;

            TriangleLocation location = new TriangleLocation()
            {
                Row = 'C',
                Column = 4
            };

            // act
            var result = _rightTriangleConverter.ConvertToLocation(x1, y1, x2, y2, x3, y3);

            // assert
            Assert.AreEqual(location, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Coordinates provided are not valid.")]
        public void ConvertToLocation_Fails_Invalid_RightTriangle_Coordinates()
        {
            // act
            var result = _rightTriangleConverter.ConvertToLocation(0, 50, 0, 60, 20, 50);
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Coordinates provided are not valid.")]
        public void ConvertToLocation_Fails_Invalid_RightTriangle_Direction_Left()
        {
            // act
            var result = _rightTriangleConverter.ConvertToLocation(10, 40, 20, 30, 20, 40);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Coordinates provided are not valid.")]
        public void ConvertToLocation_Fails_Invalid_RightTriangle_Direction_Right()
        {
            // act
            var result = _rightTriangleConverter.ConvertToLocation(10, 30, 10, 40, 20, 30);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Coordinates provided are not valid.")]
        public void ConvertToLocation_Fails_Invalid_Triangle_Coordinates()
        {
            // act
            var result = _rightTriangleConverter.ConvertToLocation(0, 50, 10, 50, 20, 50);
        }

    }
}
