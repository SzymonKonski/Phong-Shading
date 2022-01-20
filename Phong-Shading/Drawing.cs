using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using Filler.Definitions;
using Filler.Drawing;

namespace Filler
{
    public partial class Form1 : Form
    {
        private LightSourcePoint lightSourcePoint;
        private readonly DrawingModule drawingModule;
        private Options fillOptions;
        private TriangleGrid grid;
        private readonly Timer lightAnimationTimer;
        private Vertex selectedVertex;
        private readonly int sphereRadius;
        private Bitmap texture;
        private Bitmap normalMap;
        private float cameraAngle;

        public void UpdateBackground(Options options)
        {
            fillOptions = options;
            drawingModule.ClearImage();
            grid = new TriangleGrid(sphereRadius, fillOptions.Quantity, new Vector3(sphereRadius, sphereRadius, 0));
            lightSourcePoint = new LightSourcePoint(sphereRadius, new Vector3(sphereRadius, sphereRadius, fillOptions.Z));
            cameraAngle = 0;
            fillOptions.V = new Vector3(sphereRadius * (float)Math.Cos(cameraAngle) + sphereRadius, sphereRadius * (float)Math.Sin(cameraAngle) + sphereRadius, fillOptions.Z);

            if (fillOptions.LightVectorType == LightVectorType.FromSpiral || fillOptions.LightVectorType == LightVectorType.AnimatedCamera)
            {
                fillOptions.LightPoint = new Vector3(lightSourcePoint.X, lightSourcePoint.Y, lightSourcePoint.Z);
                fillOptions.V = new Vector3(sphereRadius * (float)Math.Cos(cameraAngle) + sphereRadius, sphereRadius * (float)Math.Sin(cameraAngle) + sphereRadius, fillOptions.V.Z);
                lightAnimationTimer.Start();
            }
            else
            {
                lightAnimationTimer.Stop();
                drawingModule.ClearImage();
                DrawBackground();
            }
        }

        private void DrawBackground()
        {
            var currentlyDrawing = drawingModule.CurrentlyDrawing;

            if (currentlyDrawing == false) 
                drawingModule.StartDrawing();

            drawingModule.FillGrid(grid, fillOptions);

            if (fillOptions.IsGridVisible)
                drawingModule.DrawGrid(grid);

            if (currentlyDrawing == false)
                drawingModule.StopDrawing();
        }

        private void SpiralAnimation()
        {
            drawingModule.StartDrawing();
            drawingModule.ClearLightPoint(lightSourcePoint.X, lightSourcePoint.Y, LightSourcePoint.LightSourceRadius);
            lightSourcePoint.UpdateLightSource();
            fillOptions.LightPoint = new Vector3(lightSourcePoint.X, lightSourcePoint.Y, lightSourcePoint.Z);
            cameraAngle += (float)0.1;
            if (cameraAngle >= 2 * Math.PI) cameraAngle = 0;
            fillOptions.V = new Vector3(sphereRadius * (float)Math.Cos(cameraAngle) + sphereRadius, sphereRadius * (float)Math.Sin(cameraAngle) + sphereRadius, fillOptions.V.Z);
            drawingModule.ClearImage();
            drawingModule.DrawLightPoint(lightSourcePoint.X, lightSourcePoint.Y, LightSourcePoint.LightSourceRadius);
            DrawBackground();
            drawingModule.DrawLightPoint(lightSourcePoint.X, lightSourcePoint.Y, LightSourcePoint.LightSourceRadius);
            drawingModule.StopDrawing();
        }

        private Options ReadOptions()
        {

            LightVectorType type = LightVectorType.Default;
            if (constantLightVersorRadioButton.Checked)
            {
                type = LightVectorType.Default;
            }
            else if (animatedLightVersor.Checked)
            {
                type = LightVectorType.FromSpiral;
            }
            else if(animatedCamera.Checked)
            {
                type = LightVectorType.AnimatedCamera;
            }


            return new Options
            {
                ObjectColorType = colorRadioButton.Checked ? ObjectColorType.Constant : ObjectColorType.FromTexture,
                NormalVectorType = constantVectorRadioButton.Checked ? NormalVectorType.FromSphere : NormalVectorType.FromTexture,
                LightVectorType = type,
                FillColorType = fillColorExactRadioButton.Checked ? FillColorType.Exact : FillColorType.Interpolated,
                ObjectColor = colorRadioButton.Checked ? pickedObjectColorPictureBox.BackColor : Color.Gray,
                LightColor = pickedLightColorPictureBox.BackColor,
                Kd = (float)kdTrackBar.Value / 100,
                Ks = (float)ksTrackBar.Value / 100,
                M = mTrackBar.Value,
                K = (float)kTrackBar.Value / 100,
                Z = zTrackBar.Value,
                Texture = textureRadioButton.Checked ? texture : null,
                NormalMap = vectorFileRadioButton.Checked ? normalMap : null,
                Quantity = triangulationTrackBar.Value,
                IsGridVisible = drawMeshCheckBox.Checked,
                TruncatedSphere = checkBox1.Checked
            };
        }

        private Bitmap GetBitmapFromFile()
        {
            using var ofd = new OpenFileDialog { Filter = @"Images (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg;*.jpeg;*.jpe;*.jfif;*.png" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var img = new Bitmap(ofd.FileName);
                return img;
            }

            return null;
        }
    }
}