using System;
using System.Collections.Generic;
using System.Linq;
using GeometricLayout.Interfaces;
using GeometricLayout.Models;

namespace GeometricLayout.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly static char[] rowIds = { 'F', 'E', 'D', 'C', 'B', 'A' };

        public RightTriangle GetByRowColumn(char row, int column)
        {
            int rowIndex;

            // Validate row
            rowIndex = Array.IndexOf(rowIds, row);
            if (rowIndex == -1)
                throw new ArgumentOutOfRangeException("The row of the Id referenced is invalid.");
           
            // Validate column
            if (column < 1 || column > 12)
            {
                throw new ArgumentOutOfRangeException("The column of the Id referenced is invalid.");
            }            

            var triangle = new RightTriangle();

            if (column % 2 == 0)
            {
                int columnPosition = column / 2;
                triangle.X1 = columnPosition * 10 - 10;
                triangle.Y1 = rowIndex * 10 + 10;
                triangle.X2 = columnPosition * 10;
                triangle.Y2 = rowIndex * 10;
                triangle.X3 = columnPosition * 10;
                triangle.Y3 = rowIndex * 10 + 10;
            }
            else
            {
                int columnPosition = (int)Math.Ceiling((double)column / 2);
                triangle.X1 = columnPosition * 10 - 10;
                triangle.Y1 = rowIndex * 10;
                triangle.X2 = columnPosition * 10 - 10;
                triangle.Y2 = rowIndex * 10 + 10;
                triangle.X3 = columnPosition * 10;
                triangle.Y3 = rowIndex * 10;                
            }

            return triangle;
        }

        public string GetByCoordinates(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            List<Tuple<int, int>> coordinateList = ConvertToTupleList(x1, y1, x2, y2, x3, y3);
            
            int rowIndex, column;
            
            if (coordinateList[0].Item1 == coordinateList[1].Item1)
            {
                ValidateRightTriangleLegs(coordinateList, true);
                rowIndex = coordinateList[0].Item2 / 10;
                column = coordinateList[2].Item1 / 10 * 2 -1;
                return ConvertToId(rowIndex, column);
            }

            if (coordinateList[1].Item1 == coordinateList[2].Item1)
            {
                ValidateRightTriangleLegs(coordinateList, false);
                rowIndex = coordinateList[1].Item2 / 10;
                column = coordinateList[1].Item1 / 10 * 2;
                return ConvertToId(rowIndex, column);
            }

            throw new ArgumentOutOfRangeException("Coordinates provided are not valid.");
        }

        public static List<Tuple<int, int>> ConvertToTupleList(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            List<Tuple<int, int>> coordinatesTuples = new List<Tuple<int, int>>() {
                new Tuple<int, int>(x1, y1), new Tuple<int, int>(x2, y2), new Tuple<int, int>(x3, y3)};

            coordinatesTuples.Sort((x, y) =>
            {
                int result = y.Item1.CompareTo(x.Item1);
                return result == 0 ? result : y.Item2.CompareTo(x.Item2);
            });

            return coordinatesTuples;
        }

        private void ValidateRightTriangleLegs(List<Tuple<int, int>> coordinateList, bool isOddColumn)
        {
            int leg1, leg2;

            if (isOddColumn == true)
            {
                leg1 = coordinateList[1].Item2 - coordinateList[0].Item2;
                leg2 = coordinateList[2].Item1 - coordinateList[0].Item1;
            }
            else
            {
                leg1 = coordinateList[2].Item1 - coordinateList[0].Item1;
                leg2 = coordinateList[2].Item2 - coordinateList[1].Item2;
            }                      

            if (leg1 != leg2)
            {
                throw new ArgumentOutOfRangeException("Coordinates provided are not valid.");
            }

            if (leg1 != 10)
            {
                throw new ArgumentOutOfRangeException("Coordinates provided are not valid.");
            }
        }

        private string ConvertToId(int rowIndex, int column)
        {
            try
            {
                if (column < 0 || column > 12)
                {
                    throw new ArgumentOutOfRangeException("Coordinates provided are not valid.");
                }

                return rowIds[rowIndex].ToString() + column.ToString();
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("Coordinates provided are not valid.");
            }
        }
    }
}
