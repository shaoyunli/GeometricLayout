using GeometricLayout.Models;

namespace GeometricLayout.Services
{
    public interface ILayoutService
    {
        /// <summary>
        /// Get a single triangle by its row and column.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="column">Column.</param>
        GeometricItem GetByRowColumn(char row, int column);

        /// <summary>
        /// Get a single geometric item including its row and column as well as the coordinates of the three vertices. 
        /// </summary>
        /// <param name="v1X">X axis of vertex1</param>
        /// <param name="v1Y">Y axis of vertex1</param>
        /// <param name="v2X">X axis of vertex2</param>
        /// <param name="v2Y">Y axis of vertex2</param>
        /// <param name="v3X">X axis of vertex3</param>
        /// <param name="v3Y">Y axis of vertex3</param>
        /// <returns></returns>
        GeometricItem GetByCoordinates(int v1X, int v1Y, int v2X, int v2Y, int v3X, int v3Y);
    }
}
