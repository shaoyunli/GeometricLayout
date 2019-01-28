using GeometricLayout.Models;

namespace GeometricLayout.Interfaces
{
    /// <summary>
    /// Converter to convert between coordinates and row&column.
    /// </summary>
    public interface ITriangleConverter
    {
        /// <summary>
        /// Convert from row & column to coordinates.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        Triangle ConvertFromRowColumnToTriangle(char row, int column);

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
        TriangleLocation ConvertFromTriangleToLocation(int x1, int y1, int x2, int y2, int x3, int y3);
    }
}