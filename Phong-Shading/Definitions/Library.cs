using System.Drawing;

namespace Filler.Definitions
{
    public static class Library
    {
        public const double Eps = 1e-8;
        public static bool PointsIntersecting(this PointF p1, PointF p2)
        {
            return (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y) <=
                   Vertex.VertexRadius * Vertex.VertexRadius;
        }
    }
}
