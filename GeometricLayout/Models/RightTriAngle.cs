using System.ComponentModel.DataAnnotations;

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
    }
}
