using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using GeometricLayout.Services;

namespace GeometricLayout.Models
{
    public class RightTriangle
    {       

        [Required]
        public int X1 { get; set; }

        [Required]
        public int Y1 { get; set; }

        [Required]
        public int X2 { get; set; }

        [Required]
        public int Y2 { get; set; }

        [Required]
        public int X3 { get; set; }

        [Required]
        public int Y3 { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as RightTriangle;
            return other.X1 == X1 && other.Y1 == Y1 &&
                other.X2 == X2 && other.Y2 == Y2 &&
                other.X3 == X3 && other.Y3 == Y3;
        }

        public List<Tuple<int, int>> ToVertexList()
        {
            return LayoutService.ConvertToTupleList(X1, Y1, X2, Y2, X3, Y3);
        }
    }
}
