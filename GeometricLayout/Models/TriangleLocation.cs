using System.ComponentModel.DataAnnotations;

namespace GeometricLayout.Models
{
    public class TriangleLocation
    {
        [Required]
        public char Row { get; set; }

        [Required]
        public int Column { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as TriangleLocation;
            return other.Row == Row && other.Column == Column;
        }
    }
}
