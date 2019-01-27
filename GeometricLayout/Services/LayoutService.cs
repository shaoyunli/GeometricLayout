using System;
using System.Collections.Generic;
using System.Linq;
using GeometricLayout.Interfaces;
using GeometricLayout.Models;
using GeometricLayout.Configs;

namespace GeometricLayout.Services
{
    public class LayoutService : ILayoutService
    {
        private ILayoutServiceValidator _layoutServiceValidator;
        private IRightTriangleConverter _rightTriangleBuilder;

        public LayoutService(ILayoutServiceValidator layoutServiceValidator, IRightTriangleConverter rightTriangleBuilder)
        {
            _layoutServiceValidator = layoutServiceValidator;
            _rightTriangleBuilder = rightTriangleBuilder;
        }

        public RightTriangle GetByRowColumn(char row, int column)
        {
            _layoutServiceValidator.ValidateByRowColumn(row, column);

            return _rightTriangleBuilder.ConvertToRightTriangle(row, column);
        }

        public TriangleLocation GetByCoordinates(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            _layoutServiceValidator.ValidateByCoordinates(x1, y1, x2, y2, x3, y3);
            return _rightTriangleBuilder.ConvertToLocation(x1, y1, x2, y2, x3, y3);
        }
    }
}
