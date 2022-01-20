using System.Drawing;
using System.Numerics;

namespace Filler.Definitions
{
    public class Options
    {
        public ObjectColorType ObjectColorType { get; set; }
        public NormalVectorType NormalVectorType { get; set; }
        public LightVectorType LightVectorType { get; set; }
        public FillColorType FillColorType { get; set; }
        public float K { get; set; }
        public int Quantity { get; set; }
        public float Kd { get; set; }
        public float Z { get; set; }
        public float Ks { get; set; }
        public int M { get; set; }
        public Color LightColor { get; set; }
        public Color ObjectColor { get; set; }
        public Bitmap Texture { get; set; }
        public Bitmap NormalMap { get; set; }
        public Vector3 LightPoint { get; set; }
        public bool IsGridVisible { get; set; }
        public bool TruncatedSphere { get; set; }
        public Vector3 V { get; set; }
    }

    public enum ObjectColorType
    {
        Constant,
        FromTexture
    }

    public enum NormalVectorType
    {
        FromSphere,
        FromTexture
    }

    public enum LightVectorType
    {
        Default,
        FromSpiral,
        AnimatedCamera
    }

    public enum FillColorType
    {
        Exact,
        Interpolated
    }
}