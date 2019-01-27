using GeometricLayout.Interfaces;
using GeometricLayout.Models;
using GeometricLayout.Configs;

namespace GeometricLayout.Builders
{
    public class RightTriangleBuilder : IRightTriangleBuilder
    {
        private const int LegLength = 10;

        public RightTriangle Build(char row, int column)
        {
            var rowIndex = row - LayoutConstants.MinRow;
            int columnPosition = (column - 1) / 2;
            bool isOddColumn = column % 2 != 0;

            int baseX = columnPosition * LegLength;
            int baseY = rowIndex * LegLength;

            return new RightTriangle()
            {
                X1 = isOddColumn ? baseX : baseX + LegLength,
                Y1 = isOddColumn ? baseY + LegLength : baseY,
                X2 = baseX,
                Y2 = baseY,
                X3 = baseX + LegLength,
                Y3 = baseY + LegLength
            };
        }
    }
}