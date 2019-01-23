using System;

namespace GeometricLayout.Models
{
    public class RightTriangle : Triangle
    {
        public RightTriangle(Coordinate coordinate1, Coordinate coordinate2, Coordinate coordinate3) :
            base(coordinate1, coordinate2, coordinate3)
        {
        }

        protected override void ValidateSpecificTriangle(Coordinate coordinate1, Coordinate coordinate2, Coordinate coordinate3)
        {
            return;
        }
    }
}
