using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Filler.Definitions;
using Filler.Drawing;
using Filler.Properties;

namespace Filler
{
    public partial class Form1
    {

        public Form1()
        {
            InitializeComponent();
            sphereRadius = pictureBox1.Width > pictureBox1.Height ? pictureBox1.Height / 2 - 1 : pictureBox1.Width / 2 - 1;
            grid = new TriangleGrid(sphereRadius, 8, new Vector3(sphereRadius, sphereRadius, 0));
            drawingModule = new DrawingModule(pictureBox1);
            lightSourcePoint = new LightSourcePoint(sphereRadius, new Vector3(sphereRadius, sphereRadius, sphereRadius));
            zTrackBar.Maximum = 2*sphereRadius;
            zTrackBar.Value = sphereRadius;
            lightAnimationTimer = new Timer();
            lightAnimationTimer.Interval = 50;
            lightAnimationTimer.Tick += (sender, e) => { SpiralAnimation(); };
            texture = new Bitmap(Resources.tiles_color);
            normalMap = new Bitmap(Resources.tiles);
            UpdateBackground(ReadOptions());
        }

        private void chooseColorButton_Click(object sender, EventArgs e)
        {
            if (colorRadioButton.Checked)
            {
                texture = null;
                var colorDlg = new ColorDialog();
                if (colorDlg.ShowDialog() == DialogResult.OK)
                {
                    pickedObjectColorPictureBox.BackColor = colorDlg.Color;
                    UpdateBackground(ReadOptions());
                }
                else
                {
                    colorRadioButton.Checked = false;
                }
            }
            else if (textureRadioButton.Checked)
            {
                texture = GetBitmapFromFile();
                if (texture != null)
                {
                    UpdateBackground(ReadOptions());
                }
                else
                {
                    textureRadioButton.Checked = false;
                }
            }
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            var colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                pickedLightColorPictureBox.BackColor = colorDlg.Color;
                UpdateBackground(ReadOptions());
            }
        }

        private void triangulationTrackBar_ValueChanged(object sender, EventArgs e)
        {
            UpdateBackground(ReadOptions());
        }

        private void drawMeshCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBackground(ReadOptions());
        }

        private void fillColorExactRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fillColorExactRadioButton.Checked)
            {
                lightAnimationTimer.Interval = 30;
                UpdateBackground(ReadOptions());
            }
        }

        private void fillColorVerticesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fillColorVerticesRadioButton.Checked )
            {
                lightAnimationTimer.Interval = 100;
                UpdateBackground(ReadOptions());
            }
        }

        private void vectorFileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (vectorFileRadioButton.Checked)
            {
                normalMap = GetBitmapFromFile();
                if (normalMap != null)
                {
                    UpdateBackground(ReadOptions());
                }
                else
                {
                    vectorFileRadioButton.Checked = false;
                }
            }
        }

        private void constantVectorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (constantVectorRadioButton.Checked)
            {
                UpdateBackground(ReadOptions());
            }
        }

        private void animatedLightVersor_CheckedChanged(object sender, EventArgs e)
        {
            if (animatedLightVersor.Checked)
            {
                UpdateBackground(ReadOptions());
            }
        }


        private void animatedCamera_CheckedChanged(object sender, EventArgs e)
        {
            if (animatedCamera.Checked)
            {
                UpdateBackground(ReadOptions());
            }
        }

        private void constantLightVersorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (constantLightVersorRadioButton.Checked)
            {
                UpdateBackground(ReadOptions());
            }
        }


        #region Mouse
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawMeshCheckBox.Checked && selectedVertex != null)
            {
                selectedVertex = null;

                if (fillOptions.LightVectorType == LightVectorType.FromSpiral)
                    lightAnimationTimer.Start();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ModifierKeys == Keys.None && drawMeshCheckBox.Checked)
            {
                var v = grid.FindVertex(new PointF(e.X, e.Y));
                selectedVertex = v;
                lightAnimationTimer.Stop();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawMeshCheckBox.Checked && selectedVertex != null)
            {
                drawingModule.StartDrawing();
                drawingModule.ClearImage();
                selectedVertex.Move(e.X, e.Y);
                DrawBackground();
                drawingModule.StopDrawing();
            }
        }

        #endregion
        
        #region Sliders

        private bool clicked;

        private void kdTrackBar_Scroll(object sender, EventArgs e)
        {
            if (clicked)
                return;
        }

        private void kdTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
        }

        private void kdTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (!clicked)
                return;

            clicked = false;

            UpdateBackground(ReadOptions());
        }

        private void ksTrackBar_Scroll(object sender, EventArgs e)
        {
            if (clicked)
                return;
        }

        private void ksTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
        }

        private void ksTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (!clicked)
                return;

            clicked = false;

            UpdateBackground(ReadOptions());
        }

        private void mTrackBar_Scroll(object sender, EventArgs e)
        {
            if (clicked)
                return;
        }

        private void mTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
        }

        private void mTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (!clicked)
                return;

            clicked = false;

            UpdateBackground(ReadOptions());
        }

        private void kTrackBar_Scroll(object sender, EventArgs e)
        {
            if (clicked)
                return;
        }

        private void kTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
        }

        private void kTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (!clicked)
                return;

            clicked = false;

            UpdateBackground(ReadOptions());
        }

        private void zTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if(lightAnimationTimer == null) return;

            UpdateBackground(ReadOptions());
        }

        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBackground(ReadOptions());
        }

    }
}