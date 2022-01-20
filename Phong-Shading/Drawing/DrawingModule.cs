using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using Filler.Definitions;

namespace Filler.Drawing
{
    public class DrawingModule
    {
        private readonly PictureBox pictureBox;
        public bool CurrentlyDrawing;
        private readonly Bitmap drawArea;

        public DrawingModule(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            drawArea = new Bitmap(pictureBox.Width, pictureBox.Height, PixelFormat.Format32bppArgb);
            pictureBox.Image = drawArea;
        }

        public void DrawGrid(TriangleGrid grid)
        {
            using (var graphics = Graphics.FromImage(drawArea))
            {
                foreach (var triangle in grid.Triangles)
                {
                    graphics.DrawLine(Pens.Black, triangle[0], triangle[2]);
                    graphics.DrawLine(Pens.Black, triangle[0], triangle[1]);
                    graphics.DrawLine(Pens.Black, triangle[1], triangle[2]);
                }
            }
        }

        public void FillGrid(TriangleGrid grid, Options options)
        {
            BmpPixelSnoop texture = null;
            BmpPixelSnoop normalMap = null;

            if (options.Texture != null && options.ObjectColorType == ObjectColorType.FromTexture)
            {
                var source = ScaleImage(options.Texture);
                texture = new BmpPixelSnoop(source);
            }

            if (options.NormalMap != null && options.NormalVectorType == NormalVectorType.FromTexture)
            {
                var source = ScaleImage(options.NormalMap);
                normalMap = new BmpPixelSnoop(source);
            }

            using (var wrapper = new BmpPixelSnoop(drawArea))
            {
                var generator = new ColorGenerator(options, texture, normalMap, grid.Radius);

                Parallel.ForEach(grid.Triangles, triangle =>
                {
                    TriangleInterpolation interpolation = null;

                    if (options.FillColorType == FillColorType.Interpolated)
                    {
                        interpolation = generator.Interpolate(triangle);
                    }

                    ScanLine.FillPolygon(triangle, generator, wrapper, interpolation, options);
                });
            }
        }

        public void DrawLightPoint(float x, float y, float r)
        {
            using (var graphics = Graphics.FromImage(drawArea))
            {
                graphics.FillEllipse(Brushes.Green, (int) (x - r), (int) (y - r), 2 * (int) r, 2 * (int) r);
            }
        }

        public void ClearLightPoint(float x, float y, float r)
        {
            using (var graphics = Graphics.FromImage(drawArea))
            {
                using (var b = new SolidBrush(Color.White))
                {
                    graphics.FillEllipse(b, (int)(x - r), (int)(y - r), 2 * (int)r, 2 * (int)r);
                }
            }
        }

        public void ClearImage()
        {
            Graphics g = Graphics.FromImage(drawArea);
            g.Clear(Color.White);
        }

        private Bitmap ScaleImage(Bitmap image)
        {
            var source = ConvertToTargetPixelFormat(image);
            var destRect = new Rectangle(0, 0, drawArea.Width, drawArea.Height);
            var destImage = new Bitmap(drawArea.Width, drawArea.Height);
            destImage.SetResolution(source.HorizontalResolution, source.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(source, destRect, 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private Bitmap ConvertToTargetPixelFormat(Bitmap bitmap)
        {
            if (bitmap.PixelFormat != PixelFormat.Format32bppPArgb)
            {
                var clone = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppPArgb);
                using var gr = Graphics.FromImage(clone);
                gr.DrawImage(bitmap, new Rectangle(0, 0, clone.Width, clone.Height));

                return clone;
            }

            return bitmap;
        }

        public void StartDrawing()
        {
            if (CurrentlyDrawing == false) 
                CurrentlyDrawing = true;
        }

        public void StopDrawing()
        {
            if (CurrentlyDrawing)
            {
                CurrentlyDrawing = false;
                pictureBox.Refresh();
            }
        }
    }
}