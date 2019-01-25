using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
            var vertexList = new List<Tuple<int, int>> { new Tuple<int, int>(X1, Y1), new Tuple<int, int>(X2, Y2), new Tuple<int, int>(X3, Y3) };
             vertexList.Sort((x, y) =>
            {
                int result = y.Item1.CompareTo(x.Item1);
                return result == 0 ? result : y.Item2.CompareTo(x.Item2);
            });
            return vertexList;
        }
    }
}
