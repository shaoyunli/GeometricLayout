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

        public List<Tuple<int, int>> ToVertexList()
        {
            return LayoutService.ConvertToTupleList(X1, Y1, X2, Y2, X3, Y3);
        }
    }
}
