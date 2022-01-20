using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Filler.Definitions
{
    public class TriangleGrid
    {
        public List<List<Vertex>> Triangles { get; } = new();

        private readonly int verticesNumber;
        public readonly int Radius;
        private readonly List<(int v1, int v2, int v3)> triangles;
        private readonly Vertex[] vertices;
        public Vector3 SphereCenter;

        public TriangleGrid(int radius, int quantity, Vector3 sphereCenter)
        {
            Radius = radius;
            SphereCenter = sphereCenter;
            verticesNumber = quantity * quantity * 4 + 1;
            vertices = new Vertex[verticesNumber];
            triangles = new List<(int v1, int v2, int v3)>();
            InitializeSphere(Radius, sphereCenter.X, sphereCenter.Y, quantity);
        }

        private void InitializeSphere(int radius, float centerX, float centerY, int quantity)
        {
            var vertexIndex = 0;
            var trianglesNumberOnFirstLevel = quantity * 4;

            for (var l = 0; l < quantity; l++)
            {
                for (var t = 0; t < trianglesNumberOnFirstLevel; t++)
                {
                    var longitude = 2 * Math.PI * (t + l * 0.5f) / trianglesNumberOnFirstLevel;
                    var latitude = 2 * Math.PI * l / trianglesNumberOnFirstLevel;
                    var px = Math.Cos(latitude) * Math.Cos(longitude) * radius + centerX;
                    var py = Math.Cos(latitude) * Math.Sin(longitude) * radius + centerY;
                    var pz = Math.Sin(latitude) * radius;
                    vertices[vertexIndex] = new Vertex((int)px, (int)py, (int)pz);
                    var highestLevel = quantity - 1;

                    if (l < highestLevel)
                    {
                        var trianglesNumberOnLevel = l * trianglesNumberOnFirstLevel;
                        var v1 = t + trianglesNumberOnLevel;
                        var v2 = (t + 1) % trianglesNumberOnFirstLevel + trianglesNumberOnLevel;
                        var v3 = t + (l + 1) * trianglesNumberOnFirstLevel;
                        
                        triangles.Add((v1, v2, v3));
                        triangles.Add((v2, (t + 1) % trianglesNumberOnFirstLevel + (l + 1) * trianglesNumberOnFirstLevel, v3));
                    }

                    vertexIndex++;
                }
            }

            var centerVertex = new Vertex(centerX, centerY, radius);
            vertices[verticesNumber-1] = centerVertex;
            AddTrianglesOnLowestLevel(quantity);

            foreach (var t in triangles)
            {
                Triangles.Add(new List<Vertex>
                {
                    vertices[t.v1],
                    vertices[t.v2],
                    vertices[t.v3]
                });
            }
        }

        private void AddTrianglesOnLowestLevel(int quantity)
        {
            var trianglesNumberOnFirstLevel = quantity * 4;
            
            for (var t = 0; t < trianglesNumberOnFirstLevel; t++)
            {
                var v1 = t + (quantity - 1) * trianglesNumberOnFirstLevel;
                var v2 = (t + 1) % trianglesNumberOnFirstLevel + (quantity - 1) * trianglesNumberOnFirstLevel;
                var v3 = quantity * trianglesNumberOnFirstLevel;

                triangles.Add((v1, v2, v3));
            }
        }

        public Vertex FindVertex(PointF pos)
        {
            foreach (var triangle in Triangles)
            {
                if (pos.PointsIntersecting(triangle[0])) return triangle[0];
                if (pos.PointsIntersecting(triangle[1])) return triangle[1];
                if (pos.PointsIntersecting(triangle[2])) return triangle[2];
            }

            return null;
        }
    }
}
