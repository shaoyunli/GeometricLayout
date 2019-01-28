using System;
using System.Collections.Generic;
using System.Linq;
using GeometricLayout.Interfaces;
using GeometricLayout.Models;
using GeometricLayout.Configs;

namespace GeometricLayout.Services
{
    /// <summary>
    /// Layout service contains the business logic.
    /// </summary>
    public class LayoutService : ILayoutService
    {
        private ILayoutServiceValidator _layoutServiceValidator;
        private ITriangleConverter _triangleConverter;

        /// <summary>
        /// Constructor of layout service.
        /// </summary>
        /// <param name="layoutServiceValidator"></param>
        /// <param name="triangleConverter"></param>
        public LayoutService(ILayoutServiceValidator layoutServiceValidator, ITriangleConverter triangleConverter)
        {
            _layoutServiceValidator = layoutServiceValidator;
            _triangleConverter = triangleConverter;
        }

        /// <summary>
        /// Get a single triangle by its row and column.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="column">Column.</param>
        public Triangle GetByRowColumn(char row, int column)
        {
            _layoutServiceValidator.ValidateByRowColumn(row, column);

            return _triangleConverter.ConvertFromRowColumnToTriangle(row, column);
        }

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
        public TriangleLocation GetByCoordinates(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            _layoutServiceValidator.ValidateByCoordinates(x1, y1, x2, y2, x3, y3);
            return _triangleConverter.ConvertFromTriangleToLocation(x1, y1, x2, y2, x3, y3);
        }
    }
}
