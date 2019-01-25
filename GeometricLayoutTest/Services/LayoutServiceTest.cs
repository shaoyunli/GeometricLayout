using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricLayout.Models;
using GeometricLayout.Services;

namespace GeometricLayoutTest.Test.Services
{
    [TestClass]
    public class LayoutServiceTest
    {
        private LayoutService layoutService;

        [TestInitialize]
        public void Setup()
        {
            layoutService = new LayoutService();
        }

        [TestMethod]
        public void GetByRowColumn()
        {
            // arrange
            var testCases = new[]
            {
                new { caseId = "A1" ,  row = 'A', column = 1,  expect = new RightTriangle(){ X1 = 0,  Y1 = 50, X2 = 0,  Y2 = 60, X3 = 10, Y3 = 50 }},
                new { caseId = "A2" ,  row = 'A', column = 2,  expect = new RightTriangle(){ X1 = 0,  Y1 = 60, X2 = 10, Y2 = 50, X3 = 10, Y3 = 60 }},
                new { caseId = "A3" ,  row = 'A', column = 3,  expect = new RightTriangle(){ X1 = 10, Y1 = 50, X2 = 10, Y2 = 60, X3 = 20, Y3 = 50 }},
                new { caseId = "A4" ,  row = 'A', column = 4,  expect = new RightTriangle(){ X1 = 10, Y1 = 60, X2 = 20, Y2 = 50, X3 = 20, Y3 = 60 }},
                new { caseId = "A5" ,  row = 'A', column = 5,  expect = new RightTriangle(){ X1 = 20, Y1 = 50, X2 = 20, Y2 = 60, X3 = 30, Y3 = 50 }},
                new { caseId = "A6" ,  row = 'A', column = 6,  expect = new RightTriangle(){ X1 = 20, Y1 = 60, X2 = 30, Y2 = 50, X3 = 30, Y3 = 60 }},
                new { caseId = "A7" ,  row = 'A', column = 7,  expect = new RightTriangle(){ X1 = 30, Y1 = 50, X2 = 30, Y2 = 60, X3 = 40, Y3 = 50 }},
                new { caseId = "A8" ,  row = 'A', column = 8,  expect = new RightTriangle(){ X1 = 30, Y1 = 60, X2 = 40, Y2 = 50, X3 = 40, Y3 = 60 }},
                new { caseId = "A9" ,  row = 'A', column = 9,  expect = new RightTriangle(){ X1 = 40, Y1 = 50, X2 = 40, Y2 = 60, X3 = 50, Y3 = 50 }},
                new { caseId = "A10" , row = 'A', column = 10, expect = new RightTriangle(){ X1 = 40, Y1 = 60, X2 = 50, Y2 = 50, X3 = 50, Y3 = 60 }},
                new { caseId = "A11" , row = 'A', column = 11, expect = new RightTriangle(){ X1 = 50, Y1 = 50, X2 = 50, Y2 = 60, X3 = 60, Y3 = 50 }},
                new { caseId = "A12" , row = 'A', column = 12, expect = new RightTriangle(){ X1 = 50, Y1 =60,  X2 = 60, Y2 = 50, X3 = 60, Y3 = 60 }},

                new { caseId = "B1" ,  row = 'B', column = 1,  expect = new RightTriangle(){ X1 = 0,  Y1 = 40, X2 = 0,  Y2 = 50, X3 = 10, Y3 = 40 }},
                new { caseId = "B2" ,  row = 'B', column = 2,  expect = new RightTriangle(){ X1 = 0,  Y1 = 50, X2 = 10, Y2 = 40, X3 = 10, Y3 = 50 }},
                new { caseId = "B3" ,  row = 'B', column = 3,  expect = new RightTriangle(){ X1 = 10, Y1 = 40, X2 = 10, Y2 = 50, X3 = 20, Y3 = 40 }},
                new { caseId = "B4" ,  row = 'B', column = 4,  expect = new RightTriangle(){ X1 = 10, Y1 = 50, X2 = 20, Y2 = 40, X3 = 20, Y3 = 50 }},
                new { caseId = "B5" ,  row = 'B', column = 5,  expect = new RightTriangle(){ X1 = 20, Y1 = 40, X2 = 20, Y2 = 50, X3 = 30, Y3 = 40 }},
                new { caseId = "B6" ,  row = 'B', column = 6,  expect = new RightTriangle(){ X1 = 20, Y1 = 50, X2 = 30, Y2 = 40, X3 = 30, Y3 = 50 }},
                new { caseId = "B7" ,  row = 'B', column = 7,  expect = new RightTriangle(){ X1 = 30, Y1 = 40, X2 = 30, Y2 = 50, X3 = 40, Y3 = 40 }},
                new { caseId = "B8" ,  row = 'B', column = 8,  expect = new RightTriangle(){ X1 = 30, Y1 = 50, X2 = 40, Y2 = 40, X3 = 40, Y3 = 50 }},
                new { caseId = "B9" ,  row = 'B', column = 9,  expect = new RightTriangle(){ X1 = 40, Y1 = 40, X2 = 40, Y2 = 50, X3 = 50, Y3 = 40 }},
                new { caseId = "B10" , row = 'B', column = 10, expect = new RightTriangle(){ X1 = 40, Y1 = 50, X2 = 50, Y2 = 40, X3 = 50, Y3 = 50 }},
                new { caseId = "B11" , row = 'B', column = 11, expect = new RightTriangle(){ X1 = 50, Y1 = 40, X2 = 50, Y2 = 50, X3 = 60, Y3 = 40 }},
                new { caseId = "B12" , row = 'B', column = 12, expect = new RightTriangle(){ X1 = 50, Y1 = 50, X2 = 60, Y2 = 40, X3 = 60, Y3 = 50 }},

                new { caseId = "C1" ,  row = 'C', column = 1,  expect = new RightTriangle(){ X1 = 0,  Y1 = 30, X2 = 0,  Y2 = 40, X3 = 10, Y3 = 30 }},
                new { caseId = "C2" ,  row = 'C', column = 2,  expect = new RightTriangle(){ X1 = 0,  Y1 = 40, X2 = 10, Y2 = 30, X3 = 10, Y3 = 40 }},
                new { caseId = "C3" ,  row = 'C', column = 3,  expect = new RightTriangle(){ X1 = 10, Y1 = 30, X2 = 10, Y2 = 40, X3 = 20, Y3 = 30 }},
                new { caseId = "C4" ,  row = 'C', column = 4,  expect = new RightTriangle(){ X1 = 10, Y1 = 40, X2 = 20, Y2 = 30, X3 = 20, Y3 = 40 }},
                new { caseId = "C5" ,  row = 'C', column = 5,  expect = new RightTriangle(){ X1 = 20, Y1 = 30, X2 = 20, Y2 = 40, X3 = 30, Y3 = 30 }},
                new { caseId = "C6" ,  row = 'C', column = 6,  expect = new RightTriangle(){ X1 = 20, Y1 = 40, X2 = 30, Y2 = 30, X3 = 30, Y3 = 40 }},
                new { caseId = "C7" ,  row = 'C', column = 7,  expect = new RightTriangle(){ X1 = 30, Y1 = 30, X2 = 30, Y2 = 40, X3 = 40, Y3 = 30 }},
                new { caseId = "C8" ,  row = 'C', column = 8,  expect = new RightTriangle(){ X1 = 30, Y1 = 40, X2 = 40, Y2 = 30, X3 = 40, Y3 = 40 }},
                new { caseId = "C9" ,  row = 'C', column = 9,  expect = new RightTriangle(){ X1 = 40, Y1 = 30, X2 = 40, Y2 = 40, X3 = 50, Y3 = 30 }},
                new { caseId = "C10" , row = 'C', column = 10, expect = new RightTriangle(){ X1 = 40, Y1 = 40, X2 = 50, Y2 = 30, X3 = 50, Y3 = 40 }},
                new { caseId = "C11" , row = 'C', column = 11, expect = new RightTriangle(){ X1 = 50, Y1 = 30, X2 = 50, Y2 = 40, X3 = 60, Y3 = 30 }},
                new { caseId = "C12" , row = 'C', column = 12, expect = new RightTriangle(){ X1 = 50, Y1 = 40, X2 = 60, Y2 = 30, X3 = 60, Y3 = 40 }},

                new { caseId = "D1" ,  row = 'D', column = 1,  expect = new RightTriangle(){ X1 = 0,  Y1 = 20, X2 = 0,  Y2 = 30, X3 = 10, Y3 = 20 }},
                new { caseId = "D2" ,  row = 'D', column = 2,  expect = new RightTriangle(){ X1 = 0,  Y1 = 30, X2 = 10, Y2 = 20, X3 = 10, Y3 = 30 }},
                new { caseId = "D3" ,  row = 'D', column = 3,  expect = new RightTriangle(){ X1 = 10, Y1 = 20, X2 = 10, Y2 = 30, X3 = 20, Y3 = 20 }},
                new { caseId = "D4" ,  row = 'D', column = 4,  expect = new RightTriangle(){ X1 = 10, Y1 = 30, X2 = 20, Y2 = 20, X3 = 20, Y3 = 30 }},
                new { caseId = "D5" ,  row = 'D', column = 5,  expect = new RightTriangle(){ X1 = 20, Y1 = 20, X2 = 20, Y2 = 30, X3 = 30, Y3 = 20 }},
                new { caseId = "D6" ,  row = 'D', column = 6,  expect = new RightTriangle(){ X1 = 20, Y1 = 30, X2 = 30, Y2 = 20, X3 = 30, Y3 = 30 }},
                new { caseId = "D7" ,  row = 'D', column = 7,  expect = new RightTriangle(){ X1 = 30, Y1 = 20, X2 = 30, Y2 = 30, X3 = 40, Y3 = 20 }},
                new { caseId = "D8" ,  row = 'D', column = 8,  expect = new RightTriangle(){ X1 = 30, Y1 = 30, X2 = 40, Y2 = 20, X3 = 40, Y3 = 30 }},
                new { caseId = "D9" ,  row = 'D', column = 9,  expect = new RightTriangle(){ X1 = 40, Y1 = 20, X2 = 40, Y2 = 30, X3 = 50, Y3 = 20 }},
                new { caseId = "D10" , row = 'D', column = 10, expect = new RightTriangle(){ X1 = 40, Y1 = 30, X2 = 50, Y2 = 20, X3 = 50, Y3 = 30 }},
                new { caseId = "D11" , row = 'D', column = 11, expect = new RightTriangle(){ X1 = 50, Y1 = 20, X2 = 50, Y2 = 30, X3 = 60, Y3 = 20 }},
                new { caseId = "D12" , row = 'D', column = 12, expect = new RightTriangle(){ X1 = 50, Y1 = 30, X2 = 60, Y2 = 20, X3 = 60, Y3 = 30 }},

                new { caseId = "E1" ,  row = 'E', column = 1,  expect = new RightTriangle(){ X1 = 0,  Y1 = 10, X2 = 0,  Y2 = 20, X3 = 10, Y3 = 10 }},
                new { caseId = "E2" ,  row = 'E', column = 2,  expect = new RightTriangle(){ X1 = 0,  Y1 = 20, X2 = 10, Y2 = 10, X3 = 10, Y3 = 20 }},
                new { caseId = "E3" ,  row = 'E', column = 3,  expect = new RightTriangle(){ X1 = 10, Y1 = 10, X2 = 10, Y2 = 20, X3 = 20, Y3 = 10 }},
                new { caseId = "E4" ,  row = 'E', column = 4,  expect = new RightTriangle(){ X1 = 10, Y1 = 20, X2 = 20, Y2 = 10, X3 = 20, Y3 = 20 }},
                new { caseId = "E5" ,  row = 'E', column = 5,  expect = new RightTriangle(){ X1 = 20, Y1 = 10, X2 = 20, Y2 = 20, X3 = 30, Y3 = 10 }},
                new { caseId = "E6" ,  row = 'E', column = 6,  expect = new RightTriangle(){ X1 = 20, Y1 = 20, X2 = 30, Y2 = 10, X3 = 30, Y3 = 20 }},
                new { caseId = "E7" ,  row = 'E', column = 7,  expect = new RightTriangle(){ X1 = 30, Y1 = 10, X2 = 30, Y2 = 20, X3 = 40, Y3 = 10 }},
                new { caseId = "E8" ,  row = 'E', column = 8,  expect = new RightTriangle(){ X1 = 30, Y1 = 20, X2 = 40, Y2 = 10, X3 = 40, Y3 = 20 }},
                new { caseId = "E9" ,  row = 'E', column = 9,  expect = new RightTriangle(){ X1 = 40, Y1 = 10, X2 = 40, Y2 = 20, X3 = 50, Y3 = 10 }},
                new { caseId = "E10" , row = 'E', column = 10, expect = new RightTriangle(){ X1 = 40, Y1 = 20, X2 = 50, Y2 = 10, X3 = 50, Y3 = 20 }},
                new { caseId = "E11" , row = 'E', column = 11, expect = new RightTriangle(){ X1 = 50, Y1 = 10, X2 = 50, Y2 = 20, X3 = 60, Y3 = 10 }},
                new { caseId = "E12" , row = 'E', column = 12, expect = new RightTriangle(){ X1 = 50, Y1 = 20, X2 = 60, Y2 = 10, X3 = 60, Y3 = 20 }},

                new { caseId = "F1" ,  row = 'F', column = 1,  expect = new RightTriangle(){ X1 = 0,  Y1 = 0,  X2 = 0,  Y2 = 10, X3 = 10, Y3 = 0 }},
                new { caseId = "F2" ,  row = 'F', column = 2,  expect = new RightTriangle(){ X1 = 0,  Y1 = 10, X2 = 10, Y2 = 0,  X3 = 10, Y3 = 10 }},
                new { caseId = "F3" ,  row = 'F', column = 3,  expect = new RightTriangle(){ X1 = 10, Y1 = 0,  X2 = 10, Y2 = 10, X3 = 20, Y3 = 0 }},
                new { caseId = "F4" ,  row = 'F', column = 4,  expect = new RightTriangle(){ X1 = 10, Y1 = 10, X2 = 20, Y2 = 0,  X3 = 20, Y3 = 10 }},
                new { caseId = "F5" ,  row = 'F', column = 5,  expect = new RightTriangle(){ X1 = 20, Y1 = 0,  X2 = 20, Y2 = 10, X3 = 30, Y3 = 0 }},
                new { caseId = "F6" ,  row = 'F', column = 6,  expect = new RightTriangle(){ X1 = 20, Y1 = 10, X2 = 30, Y2 = 0,  X3 = 30, Y3 = 10 }},
                new { caseId = "F7" ,  row = 'F', column = 7,  expect = new RightTriangle(){ X1 = 30, Y1 = 0,  X2 = 30, Y2 = 10, X3 = 40, Y3 = 0 }},
                new { caseId = "F8" ,  row = 'F', column = 8,  expect = new RightTriangle(){ X1 = 30, Y1 = 10, X2 = 40, Y2 = 0,  X3 = 40, Y3 = 10 }},
                new { caseId = "F9" ,  row = 'F', column = 9,  expect = new RightTriangle(){ X1 = 40, Y1 = 0,  X2 = 40, Y2 = 10, X3 = 50, Y3 = 0 }},
                new { caseId = "F10" , row = 'F', column = 10, expect = new RightTriangle(){ X1 = 40, Y1 = 10, X2 = 50, Y2 = 0,  X3 = 50, Y3 = 10 }},
                new { caseId = "F11" , row = 'F', column = 11, expect = new RightTriangle(){ X1 = 50, Y1 = 0,  X2 = 50, Y2 = 10, X3 = 60, Y3 = 0 }},
                new { caseId = "F12" , row = 'F', column = 12, expect = new RightTriangle(){ X1 = 50, Y1 = 10, X2 = 60, Y2 = 0,  X3 = 60, Y3 = 10 }}
            };

            foreach(var testCase in testCases)
            {
                char row = testCase.row;
                int column = testCase.column;

                // act
                var result = layoutService.GetByRowColumn(row, column);

                var resultToList = result.ToVertexList();
                var expectToList = testCase.expect.ToVertexList();

                // assert
                Assert.IsTrue(expectToList.SequenceEqual(resultToList));
            }
        }
    }
}



