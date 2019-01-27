namespace GeometricLayout.Interfaces
{
    /// <summary>
    /// Validator for validating layout service functions' input.
    /// </summary>
    public interface ILayoutServiceValidator
    {
        /// <summary>
        /// Validate input for getting coordinates by row and column.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        void ValidateByRowColumn(char row, int column);

        /// <summary>
        /// Validate input for getting row and column by coordinates.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        void ValidateByCoordinates(int x1, int y1, int x2, int y2, int x3, int y3);
    }
}