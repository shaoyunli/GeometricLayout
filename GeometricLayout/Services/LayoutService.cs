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
            int rowIndex = Array.IndexOf(rowIds, row);
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
            // TODO: Validate if the vertex coordinates are for right triangle

            return "";

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
    }
}
