using GeometricLayout.Interfaces;

namespace GeometricLayout.Models
{
    public class GeometricItem
    {
        public GeometricItem(string id, ITriangle triangle)
        {
            Id = id;
            Triangle = triangle;
        }

        public string Id { get; private set; }

        public ITriangle Triangle { get; private set; }
    }
}
