using System;
using System.Collections.Generic;
using GeometricLayout.Interfaces;

namespace GeometricLayout.Models
{
    public abstract class Triangle: ITriangle
    {
        public Triangle(Coordinate coordinate1, Coordinate coordinate2, Coordinate coordinate3)
        {
            ValidateCoordinates(coordinate1, coordinate2, coordinate3);
            List<Coordinate> Coordinates = new List<Coordinate>();
            Coordinates.Add(coordinate1);
            Coordinates.Add(coordinate2);
            Coordinates.Add(coordinate3);
        }

        public List<Coordinate> Coordinates { get; private set; }

        protected abstract void ValidateSpecificTriangle(Coordinate coordinate1, Coordinate coordinate2, Coordinate coordinate3);

        private void ValidateCoordinates(Coordinate coordinate1, Coordinate coordinate2, Coordinate coordinate3)
        {
            ValidateGenericTriangle(coordinate1, coordinate2, coordinate3);
            ValidateSpecificTriangle(coordinate1, coordinate2, coordinate3);
        }

        private void ValidateGenericTriangle(Coordinate coordinate1, Coordinate coordinate2, Coordinate coordinate3)
        {
            return;
        }

    }
}
