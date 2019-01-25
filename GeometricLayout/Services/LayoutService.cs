using System;
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

        public TriangleIndentifier GetByCoordinates(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y)
        {
            throw new System.NotImplementedException();
        }
    }
}
