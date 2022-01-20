using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Filler.Definitions;

namespace Filler.Drawing
{
    public class TriangleInterpolation
    {
        public Color VertexColor1;
        public Color VertexColor2;
        public Color VertexColor3;
        public PointF Vertex1;
        public PointF Vertex2;
        public PointF Vertex3;
        public float TriangleDenominator;
    }

    public class ColorGenerator
    {
        private readonly Options options;
        private readonly BmpPixelSnoop texture;
        private readonly BmpPixelSnoop normalMap;
        private readonly int radius;

        public ColorGenerator(Options options, BmpPixelSnoop texture, BmpPixelSnoop normalMap, int radius)
        {
            this.options = options;
            this.texture = texture;
            this.normalMap = normalMap;
            this.radius = radius;
        }

        public TriangleInterpolation Interpolate(List<Vertex> polygon)
        {
            var v1 = new PointF(polygon[0].X, polygon[0].Y);
            var v2 = new PointF(polygon[1].X, polygon[1].Y);
            var v3 = new PointF(polygon[2].X, polygon[2].Y);

            var triangleDenominator = (v2.Y - v3.Y) * (v1.X - v3.X) + (v3.X - v2.X) * (v1.Y - v3.Y);
            if (triangleDenominator == 0)
                triangleDenominator = 1;

            var vertexColor1 = GetExactColorForPixel((int)v1.X, (int)v1.Y, polygon, options);
            var vertexColor2 = GetExactColorForPixel((int)v2.X, (int)v2.Y, polygon, options);
            var vertexColor3 = GetExactColorForPixel((int)v3.X, (int)v3.Y, polygon, options);

            return new TriangleInterpolation()
            {
                Vertex1 = v1,
                Vertex2 = v2,
                Vertex3 = v3,
                TriangleDenominator = triangleDenominator,
                VertexColor1 = vertexColor1,
                VertexColor2 = vertexColor2,
                VertexColor3 = vertexColor3
            };
        }

        public Color ComputeColor(List<Vertex> polygon, double x, double y, TriangleInterpolation interpolation, Options options)
        {
            if (options.FillColorType == FillColorType.Exact)
            {
                return GetExactColorForPixel((int)x, (int)y - 1, polygon, options);
            }
            else
            {
                return GetInterpolatedColorForPixel(interpolation, (int)x, (int)y - 1);
            }
        }

        private Color GetInterpolatedColorForPixel(TriangleInterpolation inter, int x, int y)
        {
            var B1 = ((inter.Vertex2.Y - inter.Vertex3.Y) * (x - inter.Vertex3.X) + 
                      (inter.Vertex3.X - inter.Vertex2.X) * (y - inter.Vertex3.Y)) / inter.TriangleDenominator;
            var B2 = ((inter.Vertex3.Y - inter.Vertex1.Y) * (x - inter.Vertex3.X) + 
                      (inter.Vertex1.X - inter.Vertex3.X) * (y - inter.Vertex3.Y)) / inter.TriangleDenominator;
            var B3 = 1 - B1 - B2;

            float red = (int)(B1 * inter.VertexColor1.R + B2 * inter.VertexColor2.R + B3 * inter.VertexColor3.R);
            float green = (int)(B1 * inter.VertexColor1.G + B2 * inter.VertexColor2.G + B3 * inter.VertexColor3.G);
            float blue = (int)(B1 * inter.VertexColor1.B + B2 * inter.VertexColor2.B + B3 * inter.VertexColor3.B);

            return Color.FromArgb(Round_To_0_255(red), Round_To_0_255(green), Round_To_0_255(blue));
        }

        private Color GetExactColorForPixel(int x, int y, List<Vertex> polygon, Options options)
        {
            var pointInWorld = PointInWorld(x, y, polygon);
            var normalSphereVector = CalculateNormalSphereVector(pointInWorld, new Vector3(radius, radius, 0), options);
            Vector3 N;
            Vector3 L;
            Color Io;
            var LightPoint = options.LightPoint;
            var Il = options.LightColor;

            Vector3 B;
            if(normalSphereVector.X == 0 &&  normalSphereVector.Y == 0 && (int)normalSphereVector.Z == 1)
            {
                B = new Vector3(0, 1, 0);
            }
            else
            {
                B = Vector3.Cross(normalSphereVector, new Vector3(0, 0, 1));
                B = Vector3.Normalize(B);
            }

            Vector3 T = Vector3.Normalize(Vector3.Cross(B, normalSphereVector));

            if (options.NormalVectorType == NormalVectorType.FromTexture && normalMap != null)
            {
                var text = GetNormalVectorFromTexture(x, y);
                var m1 = T.X * text.X + B.X * text.Y + normalSphereVector.X * text.Z;
                var m2 = T.Y * text.X + B.Y * text.Y + normalSphereVector.Y * text.Z;
                var m3 = T.Z * text.X + B.Z * text.Y + normalSphereVector.Z * text.Z;
                var MxTeksture = new Vector3(m1, m2, m3);

                N = normalSphereVector * options.K + MxTeksture * (1 - options.K);
                N = Vector3.Normalize(N);
            }
            else
            {
                N = normalSphereVector * options.K;
                N = Vector3.Normalize(N);
            }

            if (options.LightVectorType == LightVectorType.FromSpiral)
            {
                L = Vector3.Normalize(new Vector3(LightPoint.X - pointInWorld.X,  (LightPoint.Y - y), LightPoint.Z - pointInWorld.Z));
            }
            else
            {
                L = Vector3.Normalize(new Vector3(radius - pointInWorld.X, radius - pointInWorld.Y, radius + options.Z - pointInWorld.Z));
            }

            if (options.ObjectColorType == ObjectColorType.Constant)
            {
                Io = options.ObjectColor;
            }
            else if (options.ObjectColorType == ObjectColorType.FromTexture && options.Texture != null)
            {
                Io = texture.GetPixel(x, y);
            }
            else
            {
                Io = Color.Gray;
            }

            Vector3 V = new Vector3(0, 0, 1);
            if (options.LightVectorType == LightVectorType.AnimatedCamera)
            {
                V = new Vector3(options.V.X - pointInWorld.X, options.V.Y - pointInWorld.Y, options.V.Z - pointInWorld.Z);
                V = Vector3.Normalize(V);
            }

            return CalculateColor(N, L, Il, Io, V);
        }

        private Color CalculateColor(Vector3 N, Vector3 L, Color Il, Color Io, Vector3 V)
        {
            var R = 2 * Vector3.Dot(N, L) * N - L;

            var kd = options.Kd;
            var ks = options.Ks;
            var m = options.M;

            var cos1 = Vector3.Dot(N, L);
            cos1 = cos1 < 0 ? 0 : cos1;

            var cos2 = Vector3.Dot(V, R);
            cos2 = cos2 < 0 ? 0 : cos2;

            var red = CalculateComponent(Il.R, Io.R, kd, ks, m, cos1, cos2);
            var green = CalculateComponent(Il.G, Io.G, kd, ks, m, cos1, cos2);
            var blue = CalculateComponent(Il.B, Io.B, kd, ks, m, cos1, cos2);

            return Color.FromArgb(red, green, blue);
        }
        
        private int CalculateComponent(int Il, int Io, float kd, float ks, int m, float cos1, float cos2)
        {
            var part1 = kd * Scale_From_0_255_To_0_1(Il) * Scale_From_0_255_To_0_1(Io) * cos1;
            var part2 = ks * Scale_From_0_255_To_0_1(Il) * Scale_From_0_255_To_0_1(Io) * Math.Pow(cos2, m);
            var c = (float) (part1 + part2);

            return ScaleFrom_0_1_To_0_255(c);
        }

        private Vector3 GetNormalVectorFromTexture(int x, int y)
        {
            if (normalMap == null)
                return new Vector3(0, 0, 1);

            var vector = normalMap.GetPixel(x, y);
            return new Vector3(Scale_From_0_255_To_Minus1_1(vector.R), Scale_From_0_255_To_Minus1_1(vector.G), Scale_From_0_255_To_0_1(vector.B));
        }

        private int ScaleFrom_0_1_To_0_255(float c)
        {
            var result = (int)(c * 255);
            if (result > 255) return 255;
            if (result < 0) return 0;
            return result;
        }

        private float Scale_From_0_255_To_Minus1_1(float c)
        {
            var ret = c / 255 * 2 - 1;
            if (ret > 1) return 1;
            if (ret < -1) return -1;
            return ret;
        }

        private float Scale_From_0_255_To_0_1(float c)
        {
            var res = c / 255;
            if (res > 1) return 1;
            if (res < 0) return 0;
            return res;
        }

        private int Round_To_0_255(float c)
        {
            if (c > 255) return 255;
            if (c < 0) return 0;
            return (int)c;
        }

        private Vector3 PointInWorld(int x, int y, List<Vertex> triangle)
        {
            var x1 = triangle[0].X;
            var x2 = triangle[1].X;
            var x3 = triangle[2].X;
            var y1 = triangle[0].Y;
            var y2 = triangle[1].Y;
            var y3 = triangle[2].Y;
            var z1 = triangle[0].Z;
            var z2 = triangle[1].Z;
            var z3 = triangle[2].Z;

            var z = z1 +
                (((x2 - x1) * (z3 - z1) - (x3 - x1) * (z2 - z1)) / ((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1))) *
                (y - y1) - (x - x1) * (((y2 - y1) * (z3 - z1) - (y3 - y1) * (z2 - z1)) /
                                       ((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1)));

            return new Vector3(x, y, z);
        }

        private Vector3 CalculateNormalSphereVector(Vector3 pointInWorld, Vector3 sphereCenter, Options Options)
        {
            int height = 300;

            if (pointInWorld.Z > height && Options.TruncatedSphere)
            {
                return new Vector3(0, 0, 1);

            }
            else
            {
                Vector3 v = new Vector3(pointInWorld.X - sphereCenter.X, pointInWorld.Y - sphereCenter.Y, pointInWorld.Z - sphereCenter.Z);
                return Vector3.Normalize(v);
            }
        }
    }
}
