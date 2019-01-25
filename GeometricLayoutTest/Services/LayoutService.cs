using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricLayout.Models;
using GeometricLayout.Services;

namespace GeometricLayoutTest.Test.Services
{
    [TestClass]
    public class LayoutServiceTest
    {
        private LayoutService layoutService;

        public void Setup()
        {
            layoutService = new LayoutService();
        }

        public void GetByRowColumn()
        {
            var testCases = new[]
            {
                new { row = 'A', column = 1,  result = new RightTriangle(){ X1 = 0,  Y1 = 50, X2 = 0,  Y2 = 60, X3 = 10, Y3 = 50 }},
                new { row = 'A', column = 2,  result = new RightTriangle(){ X1 = 0,  Y1 = 60, X2 = 10, Y2 = 60, X3 = 10, Y3 = 50 }},
                new { row = 'A', column = 3,  result = new RightTriangle(){ X1 = 10, Y1 = 50, X2 = 10, Y2 = 60, X3 = 20, Y3 = 50 }},
                new { row = 'A', column = 4,  result = new RightTriangle(){ X1 = 10, Y1 = 60, X2 = 20, Y2 = 60, X3 = 20, Y3 = 50 }},
                new { row = 'A', column = 5,  result = new RightTriangle(){ X1 = 20, Y1 = 50, X2 = 20, Y2 = 60, X3 = 30, Y3 = 50 }},
                new { row = 'A', column = 6,  result = new RightTriangle(){ X1 = 20, Y1 = 60, X2 = 30, Y2 = 60, X3 = 30, Y3 = 50 }},
                new { row = 'A', column = 7,  result = new RightTriangle(){ X1 = 30, Y1 = 50, X2 = 30, Y2 = 60, X3 = 40, Y3 = 50 }},
                new { row = 'A', column = 8,  result = new RightTriangle(){ X1 = 30, Y1 = 60, X2 = 40, Y2 = 60, X3 = 40, Y3 = 50 }},
                new { row = 'A', column = 9,  result = new RightTriangle(){ X1 = 40, Y1 = 50, X2 = 40, Y2 = 60, X3 = 50, Y3 = 50 }},
                new { row = 'A', column = 10, result = new RightTriangle(){ X1 = 40, Y1 = 60, X2 = 50, Y2 = 60, X3 = 50, Y3 = 50 }},
                new { row = 'A', column = 11, result = new RightTriangle(){ X1 = 50, Y1 = 50, X2 = 50, Y2 = 60, X3 = 60, Y3 = 50 }},
                new { row = 'A', column = 12, result = new RightTriangle(){ X1 = 50, Y1 =60,  X2 = 60, Y2 = 60, X3 = 60, Y3 = 50 }},

                new { row = 'B', column = 1,  result = new RightTriangle(){ X1 = 0,  Y1 = 40, X2 = 0,  Y2 = 50, X3 = 10, Y3 = 40 }},
                new { row = 'B', column = 2,  result = new RightTriangle(){ X1 = 0,  Y1 = 50, X2 = 10, Y2 = 50, X3 = 10, Y3 = 40 }},
                new { row = 'B', column = 3,  result = new RightTriangle(){ X1 = 10, Y1 = 40, X2 = 10, Y2 = 50, X3 = 20, Y3 = 40 }},
                new { row = 'B', column = 4,  result = new RightTriangle(){ X1 = 10, Y1 = 50, X2 = 20, Y2 = 50, X3 = 20, Y3 = 40 }},
                new { row = 'B', column = 5,  result = new RightTriangle(){ X1 = 20, Y1 = 40, X2 = 20, Y2 = 50, X3 = 30, Y3 = 40 }},
                new { row = 'B', column = 6,  result = new RightTriangle(){ X1 = 20, Y1 = 50, X2 = 30, Y2 = 50, X3 = 30, Y3 = 40 }},
                new { row = 'B', column = 7,  result = new RightTriangle(){ X1 = 30, Y1 = 40, X2 = 30, Y2 = 50, X3 = 40, Y3 = 40 }},
                new { row = 'B', column = 8,  result = new RightTriangle(){ X1 = 30, Y1 = 50, X2 = 40, Y2 = 50, X3 = 40, Y3 = 40 }},
                new { row = 'B', column = 9,  result = new RightTriangle(){ X1 = 40, Y1 = 40, X2 = 40, Y2 = 50, X3 = 50, Y3 = 40 }},
                new { row = 'B', column = 10, result = new RightTriangle(){ X1 = 40, Y1 = 50, X2 = 50, Y2 = 50, X3 = 50, Y3 = 40 }},
                new { row = 'B', column = 11, result = new RightTriangle(){ X1 = 50, Y1 = 40, X2 = 50, Y2 = 50, X3 = 60, Y3 = 40 }},
                new { row = 'B', column = 12, result = new RightTriangle(){ X1 = 50, Y1 = 50, X2 = 60, Y2 = 50, X3 = 60, Y3 = 40 }},

                new { row = 'C', column = 1,  result = new RightTriangle(){ X1 = 0,  Y1 = 30, X2 = 0,  Y2 = 40, X3 = 10, Y3 = 30 }},
                new { row = 'C', column = 2,  result = new RightTriangle(){ X1 = 0,  Y1 = 40, X2 = 10, Y2 = 40, X3 = 10, Y3 = 30 }},
                new { row = 'C', column = 3,  result = new RightTriangle(){ X1 = 10, Y1 = 30, X2 = 10, Y2 = 40, X3 = 20, Y3 = 30 }},
                new { row = 'C', column = 4,  result = new RightTriangle(){ X1 = 10, Y1 = 40, X2 = 20, Y2 = 40, X3 = 20, Y3 = 30 }},
                new { row = 'C', column = 5,  result = new RightTriangle(){ X1 = 20, Y1 = 30, X2 = 20, Y2 = 40, X3 = 30, Y3 = 30 }},
                new { row = 'C', column = 6,  result = new RightTriangle(){ X1 = 20, Y1 = 40, X2 = 30, Y2 = 40, X3 = 30, Y3 = 30 }},
                new { row = 'C', column = 7,  result = new RightTriangle(){ X1 = 30, Y1 = 30, X2 = 30, Y2 = 40, X3 = 40, Y3 = 30 }},
                new { row = 'C', column = 8,  result = new RightTriangle(){ X1 = 30, Y1 = 40, X2 = 40, Y2 = 40, X3 = 40, Y3 = 30 }},
                new { row = 'C', column = 9,  result = new RightTriangle(){ X1 = 40, Y1 = 30, X2 = 40, Y2 = 40, X3 = 50, Y3 = 30 }},
                new { row = 'C', column = 10, result = new RightTriangle(){ X1 = 40, Y1 = 40, X2 = 50, Y2 = 40, X3 = 50, Y3 = 30 }},
                new { row = 'C', column = 11, result = new RightTriangle(){ X1 = 50, Y1 = 30, X2 = 50, Y2 = 40, X3 = 60, Y3 = 30 }},
                new { row = 'C', column = 12, result = new RightTriangle(){ X1 = 50, Y1 = 40, X2 = 60, Y2 = 40, X3 = 60, Y3 = 30 }},

                new { row = 'D', column = 1,  result = new RightTriangle(){ X1 = 0,  Y1 = 20, X2 = 0,  Y2 = 30, X3 = 10, Y3 = 20 }},
                new { row = 'D', column = 2,  result = new RightTriangle(){ X1 = 0,  Y1 = 30, X2 = 10, Y2 = 30, X3 = 10, Y3 = 20 }},
                new { row = 'D', column = 3,  result = new RightTriangle(){ X1 = 10, Y1 = 20, X2 = 10, Y2 = 30, X3 = 20, Y3 = 20 }},
                new { row = 'D', column = 4,  result = new RightTriangle(){ X1 = 10, Y1 = 30, X2 = 20, Y2 = 30, X3 = 20, Y3 = 20 }},
                new { row = 'D', column = 5,  result = new RightTriangle(){ X1 = 20, Y1 = 20, X2 = 20, Y2 = 30, X3 = 30, Y3 = 20 }},
                new { row = 'D', column = 6,  result = new RightTriangle(){ X1 = 20, Y1 = 30, X2 = 30, Y2 = 30, X3 = 30, Y3 = 20 }},
                new { row = 'D', column = 7,  result = new RightTriangle(){ X1 = 30, Y1 = 20, X2 = 30, Y2 = 30, X3 = 40, Y3 = 20 }},
                new { row = 'D', column = 8,  result = new RightTriangle(){ X1 = 30, Y1 = 30, X2 = 40, Y2 = 30, X3 = 40, Y3 = 20 }},
                new { row = 'D', column = 9,  result = new RightTriangle(){ X1 = 40, Y1 = 20, X2 = 40, Y2 = 30, X3 = 50, Y3 = 20 }},
                new { row = 'D', column = 10, result = new RightTriangle(){ X1 = 40, Y1 = 30, X2 = 50, Y2 = 30, X3 = 50, Y3 = 20 }},
                new { row = 'D', column = 11, result = new RightTriangle(){ X1 = 50, Y1 = 20, X2 = 50, Y2 = 30, X3 = 60, Y3 = 20 }},
                new { row = 'D', column = 12, result = new RightTriangle(){ X1 = 50, Y1 = 30, X2 = 60, Y2 = 30, X3 = 60, Y3 = 20 }},

                new { row = 'E', column = 1,  result = new RightTriangle(){ X1 = 0,  Y1 = 10, X2 = 0,  Y2 = 20, X3 = 20, Y3 = 10 }},
                new { row = 'E', column = 2,  result = new RightTriangle(){ X1 = 0,  Y1 = 20, X2 = 10, Y2 = 20, X3 = 20, Y3 = 10 }},
                new { row = 'E', column = 3,  result = new RightTriangle(){ X1 = 10, Y1 = 10, X2 = 10, Y2 = 20, X3 = 20, Y3 = 10 }},
                new { row = 'E', column = 4,  result = new RightTriangle(){ X1 = 10, Y1 = 20, X2 = 20, Y2 = 20, X3 = 20, Y3 = 10 }},
                new { row = 'E', column = 5,  result = new RightTriangle(){ X1 = 20, Y1 = 10, X2 = 20, Y2 = 20, X3 = 20, Y3 = 10 }},
                new { row = 'E', column = 6,  result = new RightTriangle(){ X1 = 20, Y1 = 20, X2 = 30, Y2 = 20, X3 = 20, Y3 = 10 }},
                new { row = 'E', column = 7,  result = new RightTriangle(){ X1 = 30, Y1 = 10, X2 = 30, Y2 = 20, X3 = 20, Y3 = 10 }},
                new { row = 'E', column = 8,  result = new RightTriangle(){ X1 = 30, Y1 = 20, X2 = 40, Y2 = 20, X3 = 20, Y3 = 10 }},
                new { row = 'E', column = 9,  result = new RightTriangle(){ X1 = 40, Y1 = 10, X2 = 40, Y2 = 20, X3 = 20, Y3 = 10 }},
                new { row = 'E', column = 10, result = new RightTriangle(){ X1 = 40, Y1 = 20, X2 = 50, Y2 = 20, X3 = 20, Y3 = 10 }},
                new { row = 'E', column = 11, result = new RightTriangle(){ X1 = 50, Y1 = 10, X2 = 50, Y2 = 20, X3 = 20, Y3 = 10 }},
                new { row = 'E', column = 12, result = new RightTriangle(){ X1 = 50, Y1 = 20, X2 = 60, Y2 = 20, X3 = 20, Y3 = 10 }},

                new { row = 'F', column = 1,  result = new RightTriangle(){ X1 = 0,  Y1 = 0,  X2 = 0,  Y2 = 10, X3 = 10, Y3 = 0 }},
                new { row = 'F', column = 2,  result = new RightTriangle(){ X1 = 0,  Y1 = 10, X2 = 10, Y2 = 10, X3 = 10, Y3 = 0 }},
                new { row = 'F', column = 3,  result = new RightTriangle(){ X1 = 10, Y1 = 0,  X2 = 10, Y2 = 10, X3 = 10, Y3 = 0 }},
                new { row = 'F', column = 4,  result = new RightTriangle(){ X1 = 10, Y1 = 10, X2 = 20, Y2 = 10, X3 = 10, Y3 = 0 }},
                new { row = 'F', column = 5,  result = new RightTriangle(){ X1 = 20, Y1 = 0,  X2 = 20, Y2 = 10, X3 = 10, Y3 = 0 }},
                new { row = 'F', column = 6,  result = new RightTriangle(){ X1 = 20, Y1 = 10, X2 = 30, Y2 = 10, X3 = 10, Y3 = 0 }},
                new { row = 'F', column = 7,  result = new RightTriangle(){ X1 = 30, Y1 = 0,  X2 = 30, Y2 = 10, X3 = 10, Y3 = 0 }},
                new { row = 'F', column = 8,  result = new RightTriangle(){ X1 = 30, Y1 = 10, X2 = 40, Y2 = 10, X3 = 10, Y3 = 0 }},
                new { row = 'F', column = 9,  result = new RightTriangle(){ X1 = 40, Y1 = 0,  X2 = 40, Y2 = 10, X3 = 10, Y3 = 0 }},
                new { row = 'F', column = 10, result = new RightTriangle(){ X1 = 40, Y1 = 10, X2 = 50, Y2 = 10, X3 = 10, Y3 = 0 }},
                new { row = 'F', column = 11, result = new RightTriangle(){ X1 = 50, Y1 = 0,  X2 = 50, Y2 = 10, X3 = 10, Y3 = 0 }},
                new { row = 'F', column = 12, result = new RightTriangle(){ X1 = 50, Y1 = 10, X2 = 60, Y2 = 10, X3 = 10, Y3 = 0 }}
            };

            foreach(var testCase in testCases)
            {
                char row = testCase.row;
                int column = testCase.column;
                var result = layoutService.GetByRowColumn(row, column);

                Assert.AreEqual(testCase.result, result);
            }
        }
    }
}



