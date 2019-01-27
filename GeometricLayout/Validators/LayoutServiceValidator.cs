using System;
using GeometricLayout.Interfaces;
using GeometricLayout.Configs;
using System.Collections.Generic;

namespace GeometricLayout.Validators
{
    /// <summary>
    /// Validator for validating layout service functions' input.
    /// </summary>
    public class LayoutServiceValidator : ILayoutServiceValidator
    {
        /// <summary>
        /// Validate input for getting coordinates by row and column.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void ValidateByRowColumn(char row, int column)
        {
            if (row < LayoutConstants.MinRow || row > LayoutConstants.MaxRow)
            {
                throw new ArgumentOutOfRangeException("The row of the triangle location is invalid.");
            }

            if (column < LayoutConstants.MinColumn || column > LayoutConstants.MaxColumn)
            {
                throw new ArgumentOutOfRangeException("The column of the triangle location is invalid.");
            }
        }

        /// <summary>
        /// Validate input for getting row and column by coordinates.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        public void ValidateByCoordinates(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            var data = new List<int>() { x1, y1, x2, y2, x3, y3 };
            var min = 0;
            var max = (LayoutConstants.MaxColumn * LayoutConstants.LegLength) / 2;

            var invalid = data.Find(p => p < min || p > max || p % LayoutConstants.LegLength != 0);
            if (invalid != 0)
            {
                throw new ArgumentOutOfRangeException("The coordinates provided are invalid.");
            }
        }
    }
}
