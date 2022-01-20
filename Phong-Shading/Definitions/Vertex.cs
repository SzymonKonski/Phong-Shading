using System.Drawing;

namespace Filler.Definitions
{
    public class Vertex
    {
        public const int VertexRadius = 3;

        public Vertex(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public static implicit operator PointF(Vertex v)
        {
            return new PointF(v.X, v.Y);
        }

        public void Move(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
