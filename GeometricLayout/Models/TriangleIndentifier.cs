using System.ComponentModel.DataAnnotations;

namespace GeometricLayout.Models
{
    public class TriangleIndentifier
    {
        [Required]
        public char Row { get; set; }

        [Required]
        public int Column { get; set; }

        public override string ToString()
        {
            return Row + Column.ToString();
        }
    }
}
