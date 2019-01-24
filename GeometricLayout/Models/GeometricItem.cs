using System.ComponentModel.DataAnnotations;

namespace GeometricLayout.Models
{
    public class GeometricItem
    {
        [Required]
        public char Row { get; set; }

        [Required]
        public int Column { get; set; }

        [Required]
        public RightTriangle Triangle { get; set; }
    }
}
