using GeometricLayout.Models;

namespace GeometricLayout.Interfaces
{
    public interface IRightTriangleConverter
    {
        RightTriangle ConvertToRightTriangle(char row, int column);
        TriangleLocation ConvertToLocation(int x1, int y1, int x2, int y2, int x3, int y3);
    }
}