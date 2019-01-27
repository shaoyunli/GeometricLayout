namespace GeometricLayout.Interfaces
{
    public interface ILayoutServiceValidator
    {
        void ValidateByRowColumn(char row, int column);
        void ValidateByCoordinates(int x1, int y1, int x2, int y2, int x3, int y3);
    }
}