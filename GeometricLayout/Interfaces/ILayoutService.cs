using System.Collections.Generic;
using GeometricLayout.Interfaces;
using GeometricLayout.Models;

namespace GeometricLayout.Services
{
    public interface ILayoutService
    {
        /// <summary>
        /// Get all triangles in the geometric layout.
        /// </summary>
        /// <returns></returns>
        List<ITriangle> GetAll();

        /// <summary>
        /// Get a single triangle by id which indicates row and column.
        /// </summary>
        /// <param name="id">id which indicates row and column.</param>
        /// <returns>Triangle</returns>
        Triangle GetById(string id);

        /// <summary>
        /// Get a single triangle
        /// </summary>
        /// <param name="coordinates">A string containing vertex coordinates of a triangle.</param>
        /// <returns>GeometricItem</returns>
        IGeometricItem GetByCoordinates(string coordinates);
    }
}
