using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricLayout.Models;
using System.Linq;

namespace GeometricLayoutTest.Models
{
    [TestClass]
    public class RightTriangleTest
    {
        [TestMethod]
        public void ToVertexList_Even_Column_Number_Sort()
        {
            // arrange
            var triangle = new RightTriangle()
            {
                X1 = 40,
                Y1 = 20,
                X2 = 30,
                Y2 = 30,
                X3 = 40,
                Y3 = 30
            };
            
            var expect = new List<Tuple<int, int>>() { new Tuple<int, int>(30, 30), new Tuple<int, int>(40, 20), new Tuple<int, int>(40, 30) };

            // act
            var result = triangle.ToVertexList();

            // assert
            Assert.IsTrue(expect.SequenceEqual(result));
        }
    }
}
