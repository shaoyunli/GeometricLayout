namespace GeometricLayout.Models
{
    public class Coordinate
    {
        public Coordinate(int xCoordinate, int yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;        
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
