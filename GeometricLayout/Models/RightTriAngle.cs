using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using GeometricLayout.Services;

namespace GeometricLayout.Models
{
    /// <summary>
    /// Right triangle model.
    /// </summary>
    public class RightTriangle
    {
        /// <summary>
        /// X-axis of vertex1.
        /// </summary>
        [Required]
        public int X1 { get; set; }

        /// <summary>
        /// Y-axis of vertex1.
        /// </summary>
        [Required]
        public int Y1 { get; set; }

        /// <summary>
        /// X-axis of vertex2.
        /// </summary>
        [Required]
        public int X2 { get; set; }

        /// <summary>
        /// Y-axis of vertex2.
        /// </summary>
        [Required]
        public int Y2 { get; set; }

        /// <summary>
        /// X-axis of vertex3.
        /// </summary>
        [Required]
        public int X3 { get; set; }

        /// <summary>
        /// Y-axis of vertex3.
        /// </summary>
        [Required]
        public int Y3 { get; set; }

        /// <summary>
        ///  Compare if two triangle are same.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as RightTriangle;
            return other.X1 == X1 && other.Y1 == Y1 &&
                other.X2 == X2 && other.Y2 == Y2 &&
                other.X3 == X3 && other.Y3 == Y3;
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(X1, Y1, X2, Y2, X3, Y3);
        }
    }
}
