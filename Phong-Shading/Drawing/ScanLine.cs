using System;
using System.Collections.Generic;
using Filler.Definitions;

namespace Filler.Drawing
{
    public static class ScanLine
    {
        public static void FillPolygon(List<Vertex> polygon, ColorGenerator generator, BmpPixelSnoop bitmap, TriangleInterpolation interpolation, Options options)
        {
            var P = polygon;
            var sortedVertices = polygon.ConvertAll(v => v);
            sortedVertices.Sort((p,q) => p.Y.CompareTo(q.Y));
            var ind = sortedVertices.ConvertAll(polygon.IndexOf);
            var AET = new List<AetItem>();
            var yMin = P[ind[0]].Y;
            var yMax = P[ind[ind.Count - 1]].Y;
            var k = 0;

            for (var y = yMin + 1; y <= yMax + 1; y++)
            {
                while (k < ind.Count && Math.Abs(P[ind[k]].Y - (y - 1)) < Library.Eps)
                {
                    var i = ind[k];
                    var prevInd = i - 1 >= 0 ? i - 1 : P.Count - 1;
                    var nextInd = i + 1 < P.Count ? i + 1 : 0;

                    if (P[prevInd].Y >= P[i].Y)
                    {
                        var dx = P[prevInd].X - P[i].X;
                        var dy = P[prevInd].Y - P[i].Y;

                        if (dy != 0)
                            AET.Add(new AetItem(P[prevInd], P[i], P[i].X, dx / dy));
                    }
                    else
                    {
                        AET.RemoveAll(aetItem => aetItem.Start == P[prevInd] && aetItem.End == P[i]);
                    }

                    if (P[nextInd].Y >= P[i].Y)
                    {
                        var dx = P[i].X - P[nextInd].X;
                        var dy = P[i].Y - P[nextInd].Y;

                        if (dy != 0)
                            AET.Add(new AetItem(P[i], P[nextInd], P[i].X, dx / dy));
                    }
                    else
                    {
                        AET.RemoveAll(aetItem => aetItem.Start == P[i] && aetItem.End == P[nextInd]);
                    }

                    k++;
                }

                AET.Sort((p,q) => p.X.CompareTo(q.X));

                for (var i = 0; i < AET.Count - 1; i += 2)
                {
                    for (var x = AET[i].X; x <= AET[i + 1].X; x++)
                    {
                        var color = generator.ComputeColor(polygon, x, y, interpolation, options);
                        bitmap.SetPixel((int)x, (int)y - 1, color);
                    }
                }
                
                foreach (var v in AET) 
                    v.X += v.ReverseM;
            }
        }
    }

    public class AetItem
    {
        public Vertex Start;
        public Vertex End;
        public float ReverseM;
        public float X;

        public AetItem(Vertex start, Vertex end, float x, float reverseM)
        {
            X = x;
            ReverseM = reverseM;
            Start = start;
            End = end;
        }
    }
}