using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricLayout.Models;
using GeometricLayout.Services;
using GeometricLayout.Validators;
using GeometricLayout.Builders;

namespace GeometricLayoutTest.Services
{
    [TestClass]
    public class LayoutServiceIntegrationTest
    {
        private LayoutService _layoutService;
        private static readonly dynamic _testCases = new[]
        {
                new { caseId = "F1" ,  row = 'F', column = 1,  coordinates = new { X1 = 0,  Y1 = 50, X2 = 0,  Y2 = 60, X3 = 10, Y3 = 60 }},
                new { caseId = "F2" ,  row = 'F', column = 2,  coordinates = new { X1 = 0,  Y1 = 50, X2 = 10, Y2 = 50, X3 = 10, Y3 = 60 }},
                new { caseId = "F3" ,  row = 'F', column = 3,  coordinates = new { X1 = 10, Y1 = 50, X2 = 10, Y2 = 60, X3 = 20, Y3 = 60 }},
                new { caseId = "F4" ,  row = 'F', column = 4,  coordinates = new { X1 = 10, Y1 = 50, X2 = 20, Y2 = 50, X3 = 20, Y3 = 60 }},
                new { caseId = "F5" ,  row = 'F', column = 5,  coordinates = new { X1 = 20, Y1 = 50, X2 = 20, Y2 = 60, X3 = 30, Y3 = 60 }},
                new { caseId = "F6" ,  row = 'F', column = 6,  coordinates = new { X1 = 20, Y1 = 50, X2 = 30, Y2 = 50, X3 = 30, Y3 = 60 }},
                new { caseId = "F7" ,  row = 'F', column = 7,  coordinates = new { X1 = 30, Y1 = 50, X2 = 30, Y2 = 60, X3 = 40, Y3 = 60 }},
                new { caseId = "F8" ,  row = 'F', column = 8,  coordinates = new { X1 = 30, Y1 = 50, X2 = 40, Y2 = 50, X3 = 40, Y3 = 60 }},
                new { caseId = "F9" ,  row = 'F', column = 9,  coordinates = new { X1 = 40, Y1 = 50, X2 = 40, Y2 = 60, X3 = 50, Y3 = 60 }},
                new { caseId = "F10" , row = 'F', column = 10, coordinates = new { X1 = 40, Y1 = 50, X2 = 50, Y2 = 50, X3 = 50, Y3 = 60 }},
                new { caseId = "F11" , row = 'F', column = 11, coordinates = new { X1 = 50, Y1 = 50, X2 = 50, Y2 = 60, X3 = 60, Y3 = 60 }},
                new { caseId = "F12" , row = 'F', column = 12, coordinates = new { X1 = 50, Y1 = 50, X2 = 60, Y2 = 50, X3 = 60, Y3 = 60 }},

                new { caseId = "E1" ,  row = 'E', column = 1,  coordinates = new { X1 = 0,  Y1 = 40, X2 = 0,  Y2 = 50, X3 = 10, Y3 = 50 }},
                new { caseId = "E2" ,  row = 'E', column = 2,  coordinates = new { X1 = 0,  Y1 = 40, X2 = 10, Y2 = 40, X3 = 10, Y3 = 50 }},
                new { caseId = "E3" ,  row = 'E', column = 3,  coordinates = new { X1 = 10, Y1 = 40, X2 = 10, Y2 = 50, X3 = 20, Y3 = 50 }},
                new { caseId = "E4" ,  row = 'E', column = 4,  coordinates = new { X1 = 10, Y1 = 40, X2 = 20, Y2 = 40, X3 = 20, Y3 = 50 }},
                new { caseId = "E5" ,  row = 'E', column = 5,  coordinates = new { X1 = 20, Y1 = 40, X2 = 20, Y2 = 50, X3 = 30, Y3 = 50 }},
                new { caseId = "E6" ,  row = 'E', column = 6,  coordinates = new { X1 = 20, Y1 = 40, X2 = 30, Y2 = 40, X3 = 30, Y3 = 50 }},
                new { caseId = "E7" ,  row = 'E', column = 7,  coordinates = new { X1 = 30, Y1 = 40, X2 = 30, Y2 = 50, X3 = 40, Y3 = 50 }},
                new { caseId = "E8" ,  row = 'E', column = 8,  coordinates = new { X1 = 30, Y1 = 40, X2 = 40, Y2 = 40, X3 = 40, Y3 = 50 }},
                new { caseId = "E9" ,  row = 'E', column = 9,  coordinates = new { X1 = 40, Y1 = 40, X2 = 40, Y2 = 50, X3 = 50, Y3 = 50 }},
                new { caseId = "E10" , row = 'E', column = 10, coordinates = new { X1 = 40, Y1 = 40, X2 = 50, Y2 = 40, X3 = 50, Y3 = 50 }},
                new { caseId = "E11" , row = 'E', column = 11, coordinates = new { X1 = 50, Y1 = 40, X2 = 50, Y2 = 50, X3 = 60, Y3 = 50 }},
                new { caseId = "E12" , row = 'E', column = 12, coordinates = new { X1 = 50, Y1 = 40, X2 = 60, Y2 = 40, X3 = 60, Y3 = 50 }},

                new { caseId = "D1" ,  row = 'D', column = 1,  coordinates = new { X1 = 0,  Y1 = 30, X2 = 0,  Y2 = 40, X3 = 10, Y3 = 40 }},
                new { caseId = "D2" ,  row = 'D', column = 2,  coordinates = new { X1 = 0,  Y1 = 30, X2 = 10, Y2 = 30, X3 = 10, Y3 = 40 }},
                new { caseId = "D3" ,  row = 'D', column = 3,  coordinates = new { X1 = 10, Y1 = 30, X2 = 10, Y2 = 40, X3 = 20, Y3 = 40 }},
                new { caseId = "D4" ,  row = 'D', column = 4,  coordinates = new { X1 = 10, Y1 = 30, X2 = 20, Y2 = 30, X3 = 20, Y3 = 40 }},
                new { caseId = "D5" ,  row = 'D', column = 5,  coordinates = new { X1 = 20, Y1 = 30, X2 = 20, Y2 = 40, X3 = 30, Y3 = 40 }},
                new { caseId = "D6" ,  row = 'D', column = 6,  coordinates = new { X1 = 20, Y1 = 30, X2 = 30, Y2 = 30, X3 = 30, Y3 = 40 }},
                new { caseId = "D7" ,  row = 'D', column = 7,  coordinates = new { X1 = 30, Y1 = 30, X2 = 30, Y2 = 40, X3 = 40, Y3 = 40 }},
                new { caseId = "D8" ,  row = 'D', column = 8,  coordinates = new { X1 = 30, Y1 = 30, X2 = 40, Y2 = 30, X3 = 40, Y3 = 40 }},
                new { caseId = "D9" ,  row = 'D', column = 9,  coordinates = new { X1 = 40, Y1 = 30, X2 = 40, Y2 = 40, X3 = 50, Y3 = 40 }},
                new { caseId = "D10" , row = 'D', column = 10, coordinates = new { X1 = 40, Y1 = 30, X2 = 50, Y2 = 30, X3 = 50, Y3 = 40 }},
                new { caseId = "D11" , row = 'D', column = 11, coordinates = new { X1 = 50, Y1 = 30, X2 = 50, Y2 = 40, X3 = 60, Y3 = 40 }},
                new { caseId = "D12" , row = 'D', column = 12, coordinates = new { X1 = 50, Y1 = 30, X2 = 60, Y2 = 30, X3 = 60, Y3 = 40 }},

                new { caseId = "C1" ,  row = 'C', column = 1,  coordinates = new { X1 = 0,  Y1 = 20, X2 = 0,  Y2 = 30, X3 = 10, Y3 = 30 }},
                new { caseId = "C2" ,  row = 'C', column = 2,  coordinates = new { X1 = 0,  Y1 = 20, X2 = 10, Y2 = 20, X3 = 10, Y3 = 30 }},
                new { caseId = "C3" ,  row = 'C', column = 3,  coordinates = new { X1 = 10, Y1 = 20, X2 = 10, Y2 = 30, X3 = 20, Y3 = 30 }},
                new { caseId = "C4" ,  row = 'C', column = 4,  coordinates = new { X1 = 10, Y1 = 20, X2 = 20, Y2 = 20, X3 = 20, Y3 = 30 }},
                new { caseId = "C5" ,  row = 'C', column = 5,  coordinates = new { X1 = 20, Y1 = 20, X2 = 20, Y2 = 30, X3 = 30, Y3 = 30 }},
                new { caseId = "C6" ,  row = 'C', column = 6,  coordinates = new { X1 = 20, Y1 = 20, X2 = 30, Y2 = 20, X3 = 30, Y3 = 30 }},
                new { caseId = "C7" ,  row = 'C', column = 7,  coordinates = new { X1 = 30, Y1 = 20, X2 = 30, Y2 = 30, X3 = 40, Y3 = 30 }},
                new { caseId = "C8" ,  row = 'C', column = 8,  coordinates = new { X1 = 30, Y1 = 20, X2 = 40, Y2 = 20, X3 = 40, Y3 = 30 }},
                new { caseId = "C9" ,  row = 'C', column = 9,  coordinates = new { X1 = 40, Y1 = 20, X2 = 40, Y2 = 30, X3 = 50, Y3 = 30 }},
                new { caseId = "C10" , row = 'C', column = 10, coordinates = new { X1 = 40, Y1 = 20, X2 = 50, Y2 = 20, X3 = 50, Y3 = 30 }},
                new { caseId = "C11" , row = 'C', column = 11, coordinates = new { X1 = 50, Y1 = 20, X2 = 50, Y2 = 30, X3 = 60, Y3 = 30 }},
                new { caseId = "C12" , row = 'C', column = 12, coordinates = new { X1 = 50, Y1 = 20, X2 = 60, Y2 = 20, X3 = 60, Y3 = 30 }},

                new { caseId = "B1" ,  row = 'B', column = 1,  coordinates = new { X1 = 0,  Y1 = 10, X2 = 0,  Y2 = 20, X3 = 10, Y3 = 20 }},
                new { caseId = "B2" ,  row = 'B', column = 2,  coordinates = new { X1 = 0,  Y1 = 10, X2 = 10, Y2 = 10, X3 = 10, Y3 = 20 }},
                new { caseId = "B3" ,  row = 'B', column = 3,  coordinates = new { X1 = 10, Y1 = 10, X2 = 10, Y2 = 20, X3 = 20, Y3 = 20 }},
                new { caseId = "B4" ,  row = 'B', column = 4,  coordinates = new { X1 = 10, Y1 = 10, X2 = 20, Y2 = 10, X3 = 20, Y3 = 20 }},
                new { caseId = "B5" ,  row = 'B', column = 5,  coordinates = new { X1 = 20, Y1 = 10, X2 = 20, Y2 = 20, X3 = 30, Y3 = 20 }},
                new { caseId = "B6" ,  row = 'B', column = 6,  coordinates = new { X1 = 20, Y1 = 10, X2 = 30, Y2 = 10, X3 = 30, Y3 = 20 }},
                new { caseId = "B7" ,  row = 'B', column = 7,  coordinates = new { X1 = 30, Y1 = 10, X2 = 30, Y2 = 20, X3 = 40, Y3 = 20 }},
                new { caseId = "B8" ,  row = 'B', column = 8,  coordinates = new { X1 = 30, Y1 = 10, X2 = 40, Y2 = 10, X3 = 40, Y3 = 20 }},
                new { caseId = "B9" ,  row = 'B', column = 9,  coordinates = new { X1 = 40, Y1 = 10, X2 = 40, Y2 = 20, X3 = 50, Y3 = 20 }},
                new { caseId = "B10" , row = 'B', column = 10, coordinates = new { X1 = 40, Y1 = 10, X2 = 50, Y2 = 10, X3 = 50, Y3 = 20 }},
                new { caseId = "B11" , row = 'B', column = 11, coordinates = new { X1 = 50, Y1 = 10, X2 = 50, Y2 = 20, X3 = 60, Y3 = 20 }},
                new { caseId = "B12" , row = 'B', column = 12, coordinates = new { X1 = 50, Y1 = 10, X2 = 60, Y2 = 10, X3 = 60, Y3 = 20 }},

                new { caseId = "A1" ,  row = 'A', column = 1,  coordinates = new { X1 = 0,  Y1 = 0,  X2 = 0,  Y2 = 10, X3 = 10, Y3 = 10 }},
                new { caseId = "A2" ,  row = 'A', column = 2,  coordinates = new { X1 = 0,  Y1 = 0,  X2 = 10, Y2 = 0,  X3 = 10, Y3 = 10 }},
                new { caseId = "A3" ,  row = 'A', column = 3,  coordinates = new { X1 = 10, Y1 = 0,  X2 = 10, Y2 = 10, X3 = 20, Y3 = 10 }},
                new { caseId = "A4" ,  row = 'A', column = 4,  coordinates = new { X1 = 10, Y1 = 0,  X2 = 20, Y2 = 0,  X3 = 20, Y3 = 10 }},
                new { caseId = "A5" ,  row = 'A', column = 5,  coordinates = new { X1 = 20, Y1 = 0,  X2 = 20, Y2 = 10, X3 = 30, Y3 = 10 }},
                new { caseId = "A6" ,  row = 'A', column = 6,  coordinates = new { X1 = 20, Y1 = 0,  X2 = 30, Y2 = 0,  X3 = 30, Y3 = 10 }},
                new { caseId = "A7" ,  row = 'A', column = 7,  coordinates = new { X1 = 30, Y1 = 0,  X2 = 30, Y2 = 10, X3 = 40, Y3 = 10 }},
                new { caseId = "A8" ,  row = 'A', column = 8,  coordinates = new { X1 = 30, Y1 = 0,  X2 = 40, Y2 = 0,  X3 = 40, Y3 = 10 }},
                new { caseId = "A9" ,  row = 'A', column = 9,  coordinates = new { X1 = 40, Y1 = 0,  X2 = 40, Y2 = 10, X3 = 50, Y3 = 10 }},
                new { caseId = "A10" , row = 'A', column = 10, coordinates = new { X1 = 40, Y1 = 0,  X2 = 50, Y2 = 0,  X3 = 50, Y3 = 10 }},
                new { caseId = "A11" , row = 'A', column = 11, coordinates = new { X1 = 50, Y1 = 0,  X2 = 50, Y2 = 10, X3 = 60, Y3 = 10 }},
                new { caseId = "A12" , row = 'A', column = 12, coordinates = new { X1 = 50, Y1 = 0,  X2 = 60, Y2 = 0,  X3 = 60, Y3 = 10 }}
            };

        [TestInitialize]
        public void Setup()
        {            
            _layoutService = new LayoutService(new LayoutServiceValidator(), new RightTriangleBuilder());
        }

        [TestMethod]
        public void GetByRowColumn_Successful()
        {
            // arrange

            foreach (var testCase in _testCases)
            {
                // arrange
                char row = testCase.row;
                int column = testCase.column;

                // act
                var result = _layoutService.GetByRowColumn(row, column);

                var resultToList = result.ToVertexList();
                var triangle = new RightTriangle()
                {
                    X1 = testCase.coordinates.X1,
                    Y1 = testCase.coordinates.Y1,
                    X2 = testCase.coordinates.X2,
                    Y2 = testCase.coordinates.Y2,
                    X3 = testCase.coordinates.X3,
                    Y3 = testCase.coordinates.Y3
                };
                var expectToList = triangle.ToVertexList();

                // assert
                Assert.IsTrue(expectToList.SequenceEqual(resultToList), $"{testCase.caseId}");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The row of the Id referenced is invalid.")]
        public void GetByRowColum_Fails_Invalid_Row()
        {
            // act
            _layoutService.GetByRowColumn('U', 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The column of the Id referenced is invalid.")]
        public void GetByRowColum_Fails_Invalid_Column_Greater_than12()
        {
            // act
            _layoutService.GetByRowColumn('F', 13);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The column of the Id referenced is invalid.")]
        public void GetByRowColum_Fails_Invalid_Column_Lessthan1()
        {
            // act
            _layoutService.GetByRowColumn('F', 0);
        }

        [TestMethod]
        public void GetByCoordinates_Successful()
        {
            // arrange
            foreach (var testCase in _testCases)
            {
                var expectedResult = testCase.row.ToString() + testCase.column.ToString();

                // act
                var result = _layoutService.GetByCoordinates(
                    testCase.coordinates.X1,
                    testCase.coordinates.Y1,
                    testCase.coordinates.X2,
                    testCase.coordinates.Y2,
                    testCase.coordinates.X3,
                    testCase.coordinates.Y3);

                // assert
                Assert.AreEqual(expectedResult, result);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Doordinates provided are not valid.")]
        public void GetByCoordinates_Fails_Return_Invalid_Row()
        {
            // act
            var result = _layoutService.GetByCoordinates(0, 60, 0, 70, 10, 60);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Doordinates provided are not valid.")]
        public void GetByCoordinates_Fails_Return_Invalid_Column()
        {
            // act
            var result = _layoutService.GetByCoordinates(60, 50, 60, 60, 70, 50);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Doordinates provided are not valid.")]
        public void GetByCoordinates_Fails_Return_Invalid_RightTriangle_Coordinates()
        {
            // act
            var result = _layoutService.GetByCoordinates(0, 50, 0, 60, 20, 50);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Doordinates provided are not valid.")]
        public void GetByCoordinates_Fails_Return_Invalid_RightTriangle_Direction_Right()
        {
            // act
            var result = _layoutService.GetByCoordinates(10, 30, 10, 40, 20, 30);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Doordinates provided are not valid.")]
        public void GetByCoordinates_Fails_Return_Invalid_RightTriangle_Direction_Left()
        {
            // act
            var result = _layoutService.GetByCoordinates(10, 40, 20, 30, 20, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Doordinates provided are not valid.")]
        public void GetByCoordinates_Fails_Return_Invalid_Triangle_Coordinates()
        {
            // act
            var result = _layoutService.GetByCoordinates(0, 50, 10, 50, 20, 50);
        }

        [TestMethod]
        public void ConvertToTupleList_Test()
        {
            int x1 = 40;
            int y1 = 20;
            int x2 = 30;
            int y2 = 30;
            int x3 = 40;
            int y3 = 30;


            var expect = new List<Tuple<int, int>>() { new Tuple<int, int>(30, 30), new Tuple<int, int>(40, 20), new Tuple<int, int>(40, 30) };

            // act
            var result = LayoutService.ConvertToTupleList(x1, y1, x2, y2, x3, y3);

            // assert
            Assert.IsTrue(expect.SequenceEqual(result));
        }
    }
}



