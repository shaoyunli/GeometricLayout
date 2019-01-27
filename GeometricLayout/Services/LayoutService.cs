using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using GeometricLayout.Interfaces;
using GeometricLayout.Models;

namespace GeometricLayout.Services
{
    public class LayoutService : ILayoutService
    {
        private const int lengthOfLeg = 10;
        private const int minColumnNumber = 1;
        private const int maxColumnNumber = 12;

        private readonly static char MinRowId = 'A';
        private readonly static char MaxRowId = 'F';

        public RightTriangle GetByRowColumn(char row, int column)
        {
            int rowIndex;

            // Validate row
            rowIndex = row - MinRowId;
            if (row < MinRowId || row > MaxRowId || column < minColumnNumber || column > maxColumnNumber)
                throw new ArgumentOutOfRangeException("The column of the Id referenced is invalid.");

            var triangle = new RightTriangle();
            // todo: RightTriangle(X2, Y2, Type)
            int columnPosition = (column - 1) / 2;

            triangle.X2 = columnPosition * lengthOfLeg;
            triangle.Y2 = rowIndex * lengthOfLeg;
            triangle.X3 = triangle.X2 + lengthOfLeg;
            triangle.Y3 = triangle.Y2 + lengthOfLeg;

            if (column % 2 == 0)
            {
                triangle.X1 = triangle.X2 + lengthOfLeg;
                triangle.Y1 = triangle.Y2;
            }
            else
            {
                triangle.X1 = triangle.X2;
                triangle.Y1 = triangle.Y2 + lengthOfLeg;
            }

            return triangle;
        }

        public string GetByCoordinates(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            var baseCoordinate = GetNumericalCoordinate(x1, y1, x2, y2, x3, y3);
            var isOddTriangle = IsOddColumnTriangle(x1, y1, x2, y2, x3, y3, baseCoordinate);
            int row = baseCoordinate.Item2 / 10;
            int column = (baseCoordinate.Item1 / 10) * 2 + (isOddTriangle ? 1 : 2);
            return ConvertToId(row, column);
        }

        public static List<Tuple<int, int>> ConvertToTupleList(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            List<Tuple<int, int>> coordinatesTuples = new List<Tuple<int, int>>() {
                new Tuple<int, int>(x1, y1), new Tuple<int, int>(x2, y2), new Tuple<int, int>(x3, y3)};

            coordinatesTuples.Sort((x, y) =>
            {
                int result = x.Item1.CompareTo(y.Item1);
                return result != 0 ? result : x.Item2.CompareTo(y.Item2);
            });

            return coordinatesTuples;
        }


        private static Tuple<int, int> GetNumericalCoordinate(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            var xCoordinate = new List<int>() { x1, x2, x3 }.Min();
            var yCoordinate = new List<int>() { y1, y2, y3 }.Min();
            return new Tuple<int, int>(xCoordinate, yCoordinate);
        }

        private static bool IsOddColumnTriangle(int x1, int y1, int x2, int y2, int x3, int y3, Tuple<int, int> baseCoordinate)
        {
            var baseX = baseCoordinate.Item1;
            var baseY = baseCoordinate.Item2;
            var vertex = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(x1- baseX, y1 - baseY),
                new Tuple<int, int>(x2- baseX, y2 - baseY),
                new Tuple<int, int>(x3- baseX, y3 - baseY),
            };
            var v2 = vertex.Find(p => p.Item1 == p.Item2 && p.Item1 == 0);
            var v3 = vertex.Find(p => p.Item1 == p.Item2 && p.Item1 == 10);
            var rightAngleVertice = vertex.Find(p => (Math.Abs(p.Item1 - p.Item2) == 10 && Math.Min(p.Item1, p.Item2) == 0));
            if (rightAngleVertice == null || v2 == null || v3 == null)
                throw new ArgumentOutOfRangeException("Coordinates provided are not valid.");

            return rightAngleVertice.Item1 < rightAngleVertice.Item2;
        }

        private string ConvertToId(int rowIndex, int column)
        {
            try
            {
                if (rowIndex < 0 || rowIndex > 5 || column < 1 || column > 12)
                {
                    throw new ArgumentOutOfRangeException("Coordinates provided are not valid.");
                }

                return ((char)(MinRowId + rowIndex)).ToString() + column.ToString();
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException("Coordinates provided are not valid.");
            }
        }
    }
}
