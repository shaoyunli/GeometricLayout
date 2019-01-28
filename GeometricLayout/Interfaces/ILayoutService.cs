using GeometricLayout.Models;

namespace GeometricLayout.Interfaces
{
    /// <summary>
    /// Layout service contains the business logic.
    /// </summary>
    public interface ILayoutService
    {
        /// <summary>
        /// Get a single triangle by its row and column.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="column">Column.</param>
        Triangle GetByRowColumn(char row, int column);

        /// <summary>
        /// Get a single geometric item including its row and column as well as the coordinates of the three vertices. 
        /// </summary>
        /// <param name="x1">X axis of vertex1</param>
        /// <param name="y1">Y axis of vertex1</param>
        /// <param name="x2">X axis of vertex2</param>
        /// <param name="y2">Y axis of vertex2</param>
        /// <param name="x3">X axis of vertex3</param>
        /// <param name="y3">Y axis of vertex3</param>
        /// <returns>Id of triangle.</returns>
        TriangleLocation GetByCoordinates(int x1, int y1, int x2, int y2, int x3, int y3);
    }
}
