using System;
using System.ComponentModel.DataAnnotations;

namespace GeometricLayout.Models
{
    /// <summary>
    /// Location model.
    /// </summary>
    public class TriangleLocation
    {
        /// <summary>
        /// Row of location.
        /// </summary>
        [Required]
        public char Row { get; set; }

        /// <summary>
        /// Column of location.
        /// </summary>
        [Required]
        public int Column { get; set; }

        /// <summary>
        /// Compare if two locations are same.
        /// </summary>
        /// <param name="obj">the other location.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as TriangleLocation;
            return other.Row == Row && other.Column == Column;
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }
    }
}
