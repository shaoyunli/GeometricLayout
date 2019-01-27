using GeometricLayout.Models;

namespace GeometricLayout.Interfaces
{
    public interface IRightTriangleBuilder
    {
        RightTriangle Build(char row, int column);
    }
}