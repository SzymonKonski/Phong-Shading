
namespace Filler
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pickedLightColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lightColorButton = new System.Windows.Forms.Button();
            this.zTrackBar = new System.Windows.Forms.TrackBar();
            this.animatedLightVersor = new System.Windows.Forms.RadioButton();
            this.constantLightVersorRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.kTrackBar = new System.Windows.Forms.TrackBar();
            this.vectorFileRadioButton = new System.Windows.Forms.RadioButton();
            this.constantVectorRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fillColorVerticesRadioButton = new System.Windows.Forms.RadioButton();
            this.fillColorExactRadioButton = new System.Windows.Forms.RadioButton();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.drawMeshCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.triangulationTrackBar = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pickedObjectColorPictureBox = new System.Windows.Forms.PictureBox();
            this.chooseColorButton = new System.Windows.Forms.Button();
            this.textureRadioButton = new System.Windows.Forms.RadioButton();
            this.colorRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.animatedCamera = new System.Windows.Forms.RadioButton();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickedLightColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.triangulationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickedObjectColorPictureBox)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.animatedCamera);
            this.groupBox4.Controls.Add(this.pickedLightColorPictureBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lightColorButton);
            this.groupBox4.Controls.Add(this.zTrackBar);
            this.groupBox4.Controls.Add(this.animatedLightVersor);
            this.groupBox4.Controls.Add(this.constantLightVersorRadioButton);
            this.groupBox4.Location = new System.Drawing.Point(12, 217);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(201, 145);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Light";
            // 
            // pickedLightColorPictureBox
            // 
            this.pickedLightColorPictureBox.BackColor = System.Drawing.Color.White;
            this.pickedLightColorPictureBox.Location = new System.Drawing.Point(144, 110);
            this.pickedLightColorPictureBox.Name = "pickedLightColorPictureBox";
            this.pickedLightColorPictureBox.Size = new System.Drawing.Size(29, 23);
            this.pickedLightColorPictureBox.TabIndex = 7;
            this.pickedLightColorPictureBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Z";
            // 
            // lightColorButton
            // 
            this.lightColorButton.Location = new System.Drawing.Point(12, 110);
            this.lightColorButton.Name = "lightColorButton";
            this.lightColorButton.Size = new System.Drawing.Size(75, 23);
            this.lightColorButton.TabIndex = 6;
            this.lightColorButton.Text = "Light color";
            this.lightColorButton.UseVisualStyleBackColor = true;
            this.lightColorButton.Click += new System.EventHandler(this.lightColorButton_Click);
            // 
            // zTrackBar
            // 
            this.zTrackBar.Location = new System.Drawing.Point(32, 65);
            this.zTrackBar.Maximum = 100;
            this.zTrackBar.Name = "zTrackBar";
            this.zTrackBar.Size = new System.Drawing.Size(109, 45);
            this.zTrackBar.TabIndex = 2;
            this.zTrackBar.ValueChanged += new System.EventHandler(this.zTrackBar_ValueChanged);
            // 
            // animatedLightVersor
            // 
            this.animatedLightVersor.AutoSize = true;
            this.animatedLightVersor.Location = new System.Drawing.Point(12, 42);
            this.animatedLightVersor.Name = "animatedLightVersor";
            this.animatedLightVersor.Size = new System.Drawing.Size(69, 17);
            this.animatedLightVersor.TabIndex = 1;
            this.animatedLightVersor.TabStop = true;
            this.animatedLightVersor.Text = "Animated";
            this.animatedLightVersor.UseVisualStyleBackColor = true;
            this.animatedLightVersor.CheckedChanged += new System.EventHandler(this.animatedLightVersor_CheckedChanged);
            // 
            // constantLightVersorRadioButton
            // 
            this.constantLightVersorRadioButton.AutoSize = true;
            this.constantLightVersorRadioButton.Checked = true;
            this.constantLightVersorRadioButton.Location = new System.Drawing.Point(12, 19);
            this.constantLightVersorRadioButton.Name = "constantLightVersorRadioButton";
            this.constantLightVersorRadioButton.Size = new System.Drawing.Size(67, 17);
            this.constantLightVersorRadioButton.TabIndex = 0;
            this.constantLightVersorRadioButton.TabStop = true;
            this.constantLightVersorRadioButton.Text = "Constant";
            this.constantLightVersorRadioButton.UseVisualStyleBackColor = true;
            this.constantLightVersorRadioButton.CheckedChanged += new System.EventHandler(this.constantLightVersorRadioButton_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.kTrackBar);
            this.groupBox3.Controls.Add(this.vectorFileRadioButton);
            this.groupBox3.Controls.Add(this.constantVectorRadioButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 368);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(201, 112);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Normal vector";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "K";
            // 
            // kTrackBar
            // 
            this.kTrackBar.LargeChange = 10;
            this.kTrackBar.Location = new System.Drawing.Point(35, 61);
            this.kTrackBar.Maximum = 100;
            this.kTrackBar.Name = "kTrackBar";
            this.kTrackBar.Size = new System.Drawing.Size(104, 45);
            this.kTrackBar.TabIndex = 2;
            this.kTrackBar.TickFrequency = 10;
            this.kTrackBar.Value = 50;
            this.kTrackBar.Scroll += new System.EventHandler(this.kTrackBar_Scroll);
            this.kTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kTrackBar_MouseDown);
            this.kTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.kTrackBar_MouseUp);
            // 
            // vectorFileRadioButton
            // 
            this.vectorFileRadioButton.AutoSize = true;
            this.vectorFileRadioButton.Checked = true;
            this.vectorFileRadioButton.Location = new System.Drawing.Point(89, 29);
            this.vectorFileRadioButton.Name = "vectorFileRadioButton";
            this.vectorFileRadioButton.Size = new System.Drawing.Size(95, 17);
            this.vectorFileRadioButton.TabIndex = 1;
            this.vectorFileRadioButton.TabStop = true;
            this.vectorFileRadioButton.Text = "Vector from file";
            this.vectorFileRadioButton.UseVisualStyleBackColor = true;
            this.vectorFileRadioButton.CheckedChanged += new System.EventHandler(this.vectorFileRadioButton_CheckedChanged);
            // 
            // constantVectorRadioButton
            // 
            this.constantVectorRadioButton.AutoSize = true;
            this.constantVectorRadioButton.Location = new System.Drawing.Point(12, 29);
            this.constantVectorRadioButton.Name = "constantVectorRadioButton";
            this.constantVectorRadioButton.Size = new System.Drawing.Size(67, 17);
            this.constantVectorRadioButton.TabIndex = 0;
            this.constantVectorRadioButton.Text = "Constant";
            this.constantVectorRadioButton.UseVisualStyleBackColor = true;
            this.constantVectorRadioButton.CheckedChanged += new System.EventHandler(this.constantVectorRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fillColorVerticesRadioButton);
            this.groupBox2.Controls.Add(this.fillColorExactRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 494);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 67);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fill Color";
            // 
            // fillColorVerticesRadioButton
            // 
            this.fillColorVerticesRadioButton.AutoSize = true;
            this.fillColorVerticesRadioButton.Location = new System.Drawing.Point(89, 30);
            this.fillColorVerticesRadioButton.Name = "fillColorVerticesRadioButton";
            this.fillColorVerticesRadioButton.Size = new System.Drawing.Size(88, 17);
            this.fillColorVerticesRadioButton.TabIndex = 1;
            this.fillColorVerticesRadioButton.TabStop = true;
            this.fillColorVerticesRadioButton.Text = "From vertices";
            this.fillColorVerticesRadioButton.UseVisualStyleBackColor = true;
            this.fillColorVerticesRadioButton.CheckedChanged += new System.EventHandler(this.fillColorVerticesRadioButton_CheckedChanged);
            // 
            // fillColorExactRadioButton
            // 
            this.fillColorExactRadioButton.AutoSize = true;
            this.fillColorExactRadioButton.Checked = true;
            this.fillColorExactRadioButton.Location = new System.Drawing.Point(15, 30);
            this.fillColorExactRadioButton.Name = "fillColorExactRadioButton";
            this.fillColorExactRadioButton.Size = new System.Drawing.Size(52, 17);
            this.fillColorExactRadioButton.TabIndex = 0;
            this.fillColorExactRadioButton.TabStop = true;
            this.fillColorExactRadioButton.Text = "Exact";
            this.fillColorExactRadioButton.UseVisualStyleBackColor = true;
            this.fillColorExactRadioButton.CheckedChanged += new System.EventHandler(this.fillColorExactRadioButton_CheckedChanged);
            // 
            // kdTrackBar
            // 
            this.kdTrackBar.LargeChange = 10;
            this.kdTrackBar.Location = new System.Drawing.Point(42, 10);
            this.kdTrackBar.Maximum = 100;
            this.kdTrackBar.Name = "kdTrackBar";
            this.kdTrackBar.Size = new System.Drawing.Size(104, 45);
            this.kdTrackBar.TabIndex = 3;
            this.kdTrackBar.TickFrequency = 10;
            this.kdTrackBar.Value = 70;
            this.kdTrackBar.Scroll += new System.EventHandler(this.kdTrackBar_Scroll);
            this.kdTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kdTrackBar_MouseDown);
            this.kdTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.kdTrackBar_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drawMeshCheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.triangulationTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 92);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid";
            // 
            // drawMeshCheckBox
            // 
            this.drawMeshCheckBox.AutoSize = true;
            this.drawMeshCheckBox.Location = new System.Drawing.Point(144, 46);
            this.drawMeshCheckBox.Name = "drawMeshCheckBox";
            this.drawMeshCheckBox.Size = new System.Drawing.Size(51, 17);
            this.drawMeshCheckBox.TabIndex = 7;
            this.drawMeshCheckBox.Text = "Draw";
            this.drawMeshCheckBox.UseVisualStyleBackColor = true;
            this.drawMeshCheckBox.CheckedChanged += new System.EventHandler(this.drawMeshCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dokładność triangulacji";
            // 
            // triangulationTrackBar
            // 
            this.triangulationTrackBar.Location = new System.Drawing.Point(12, 41);
            this.triangulationTrackBar.Maximum = 12;
            this.triangulationTrackBar.Minimum = 4;
            this.triangulationTrackBar.Name = "triangulationTrackBar";
            this.triangulationTrackBar.Size = new System.Drawing.Size(119, 45);
            this.triangulationTrackBar.TabIndex = 0;
            this.triangulationTrackBar.Value = 8;
            this.triangulationTrackBar.ValueChanged += new System.EventHandler(this.triangulationTrackBar_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(219, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 776);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pickedObjectColorPictureBox);
            this.groupBox5.Controls.Add(this.chooseColorButton);
            this.groupBox5.Controls.Add(this.textureRadioButton);
            this.groupBox5.Controls.Add(this.colorRadioButton);
            this.groupBox5.Location = new System.Drawing.Point(12, 110);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(201, 101);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Object color";
            // 
            // pickedObjectColorPictureBox
            // 
            this.pickedObjectColorPictureBox.BackColor = System.Drawing.Color.White;
            this.pickedObjectColorPictureBox.Location = new System.Drawing.Point(144, 64);
            this.pickedObjectColorPictureBox.Name = "pickedObjectColorPictureBox";
            this.pickedObjectColorPictureBox.Size = new System.Drawing.Size(29, 23);
            this.pickedObjectColorPictureBox.TabIndex = 10;
            this.pickedObjectColorPictureBox.TabStop = false;
            // 
            // chooseColorButton
            // 
            this.chooseColorButton.Location = new System.Drawing.Point(18, 64);
            this.chooseColorButton.Name = "chooseColorButton";
            this.chooseColorButton.Size = new System.Drawing.Size(75, 23);
            this.chooseColorButton.TabIndex = 9;
            this.chooseColorButton.Text = "Choose";
            this.chooseColorButton.UseVisualStyleBackColor = true;
            this.chooseColorButton.Click += new System.EventHandler(this.chooseColorButton_Click);
            // 
            // textureRadioButton
            // 
            this.textureRadioButton.AutoSize = true;
            this.textureRadioButton.Checked = true;
            this.textureRadioButton.Location = new System.Drawing.Point(94, 32);
            this.textureRadioButton.Name = "textureRadioButton";
            this.textureRadioButton.Size = new System.Drawing.Size(57, 17);
            this.textureRadioButton.TabIndex = 8;
            this.textureRadioButton.TabStop = true;
            this.textureRadioButton.Text = "texture";
            this.textureRadioButton.UseVisualStyleBackColor = true;
            // 
            // colorRadioButton
            // 
            this.colorRadioButton.AutoSize = true;
            this.colorRadioButton.Location = new System.Drawing.Point(18, 32);
            this.colorRadioButton.Name = "colorRadioButton";
            this.colorRadioButton.Size = new System.Drawing.Size(48, 17);
            this.colorRadioButton.TabIndex = 6;
            this.colorRadioButton.Text = "color";
            this.colorRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.kdTrackBar);
            this.groupBox6.Location = new System.Drawing.Point(12, 567);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(201, 61);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Kd";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ksTrackBar);
            this.groupBox7.Location = new System.Drawing.Point(12, 634);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(201, 65);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Ks";
            // 
            // ksTrackBar
            // 
            this.ksTrackBar.LargeChange = 10;
            this.ksTrackBar.Location = new System.Drawing.Point(52, 14);
            this.ksTrackBar.Maximum = 100;
            this.ksTrackBar.Name = "ksTrackBar";
            this.ksTrackBar.Size = new System.Drawing.Size(104, 45);
            this.ksTrackBar.TabIndex = 7;
            this.ksTrackBar.TickFrequency = 10;
            this.ksTrackBar.Value = 30;
            this.ksTrackBar.Scroll += new System.EventHandler(this.ksTrackBar_Scroll);
            this.ksTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ksTrackBar_MouseDown);
            this.ksTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ksTrackBar_MouseUp);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.mTrackBar);
            this.groupBox8.Location = new System.Drawing.Point(12, 705);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(201, 65);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "M";
            // 
            // mTrackBar
            // 
            this.mTrackBar.Location = new System.Drawing.Point(48, 14);
            this.mTrackBar.Maximum = 100;
            this.mTrackBar.Minimum = 1;
            this.mTrackBar.Name = "mTrackBar";
            this.mTrackBar.Size = new System.Drawing.Size(104, 45);
            this.mTrackBar.TabIndex = 8;
            this.mTrackBar.TickFrequency = 10;
            this.mTrackBar.Value = 10;
            this.mTrackBar.Scroll += new System.EventHandler(this.mTrackBar_Scroll);
            this.mTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mTrackBar_MouseDown);
            this.mTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mTrackBar_MouseUp);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 771);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Ścieta kula";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // animatedCamera
            // 
            this.animatedCamera.AutoSize = true;
            this.animatedCamera.Location = new System.Drawing.Point(92, 19);
            this.animatedCamera.Name = "animatedCamera";
            this.animatedCamera.Size = new System.Drawing.Size(61, 17);
            this.animatedCamera.TabIndex = 8;
            this.animatedCamera.TabStop = true;
            this.animatedCamera.Text = "Camera";
            this.animatedCamera.UseVisualStyleBackColor = true;
            this.animatedCamera.CheckedChanged += new System.EventHandler(this.animatedCamera_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 794);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Gk2";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickedLightColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.triangulationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickedObjectColorPictureBox)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox drawMeshCheckBox;
        private System.Windows.Forms.Button lightColorButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar triangulationTrackBar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar kdTrackBar;
        private System.Windows.Forms.RadioButton fillColorVerticesRadioButton;
        private System.Windows.Forms.RadioButton fillColorExactRadioButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar kTrackBar;
        private System.Windows.Forms.RadioButton vectorFileRadioButton;
        private System.Windows.Forms.RadioButton constantVectorRadioButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar zTrackBar;
        private System.Windows.Forms.RadioButton animatedLightVersor;
        private System.Windows.Forms.RadioButton constantLightVersorRadioButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button chooseColorButton;
        private System.Windows.Forms.RadioButton textureRadioButton;
        private System.Windows.Forms.RadioButton colorRadioButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TrackBar ksTrackBar;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TrackBar mTrackBar;
        private System.Windows.Forms.PictureBox pickedLightColorPictureBox;
        private System.Windows.Forms.PictureBox pickedObjectColorPictureBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton animatedCamera;
    }
}

