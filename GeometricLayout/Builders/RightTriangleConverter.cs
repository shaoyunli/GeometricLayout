using System;
using System.Collections.Generic;
using System.Linq;
using GeometricLayout.Interfaces;
using GeometricLayout.Models;
using GeometricLayout.Configs;

namespace GeometricLayout.Builders
{
    /// <summary>
    /// Converter to convert between coordinates and row&column.
    /// </summary>
    public class RightTriangleConverter : ITriangleConverter
    {
        private const int LegLength = 10;

        /// <summary>
        /// Convert from row & column to coordinates.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public Triangle ConvertFromRowColumnToTriangle(char row, int column)
        {
            var rowIndex = row - LayoutConstants.MinRow;
            int columnPosition = (column - 1) / 2;
            bool isOddColumn = column % 2 != 0;

            int baseX = columnPosition * LegLength;
            int baseY = rowIndex * LegLength;

            return new Triangle()
            {
                X1 = isOddColumn ? baseX : baseX + LegLength,
                Y1 = isOddColumn ? baseY + LegLength : baseY,
                X2 = baseX,
                Y2 = baseY,
                X3 = baseX + LegLength,
                Y3 = baseY + LegLength
            };
        }

        /// <summary>
        /// Convert from coordinates to row & column.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <returns></returns>
        public TriangleLocation ConvertFromTriangleToLocation(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            var sortedTupleList = ConvertToSortedTupleList(x1, y1, x2, y2, x3, y3);
            ValidateCoordinates(sortedTupleList);

            var isInOddColumn = sortedTupleList[1].Item1 == sortedTupleList[0].Item1;           

            var row = sortedTupleList[0].Item2 / LayoutConstants.LegLength + LayoutConstants.MinRow;
            var column = (sortedTupleList[0].Item1 / LayoutConstants.LegLength) * 2 + LayoutConstants.MinColumn;

            return new TriangleLocation()
            {
                Row = (char)row,
                Column = isInOddColumn ? column : column + 1
            };
        }

        private List<Tuple<int, int>> ConvertToSortedTupleList(int x1, int y1, int x2, int y2, int x3, int y3)
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

        private void ValidateCoordinates(List<Tuple<int, int>> coordinates)
        {
            var xCoordinates = coordinates.Select(p => p.Item1).ToList<int>();
            var yCoordinates = coordinates.Select(p => p.Item2).ToList<int>();

            if (xCoordinates.Max() - xCoordinates.Min() != 10 || yCoordinates.Max() - yCoordinates.Min() != 10)
            {
                throw new ArgumentOutOfRangeException("The three vertices are in the same line.");
            }

            if (coordinates[2].Item1 - coordinates[0].Item1 != 10 || coordinates[2].Item2 - coordinates[0].Item2 != 10)
            {
                throw new ArgumentOutOfRangeException("The given triangle is not a required shape.");
            }
        }
    }
}