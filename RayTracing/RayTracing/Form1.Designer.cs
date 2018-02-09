namespace RayTracing
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chrtTimeTaken = new LiveCharts.WinForms.CartesianChart();
            this.txtbxLog = new System.Windows.Forms.RichTextBox();
            this.btnRayTracer = new System.Windows.Forms.Button();
            this.chckbxThreaded = new System.Windows.Forms.CheckBox();
            this.numOfThreads = new System.Windows.Forms.NumericUpDown();
            this.txtbxPicHeight = new System.Windows.Forms.TextBox();
            this.txtbxPicWidth = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.chrtSubTimes = new LiveCharts.WinForms.CartesianChart();
            this.txtbxFrames = new System.Windows.Forms.TextBox();
            this.lblFrames = new System.Windows.Forms.Label();
            this.lblThreads = new System.Windows.Forms.Label();
            this.SettingsBox = new System.Windows.Forms.GroupBox();
            this.lblFps = new System.Windows.Forms.Label();
            this.txtbxFps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBxOptimzation = new System.Windows.Forms.ComboBox();
            this.SphereDataGrid = new System.Windows.Forms.DataGridView();
            this.btnUpdateData = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Graphs = new System.Windows.Forms.TabPage();
            this.Images = new System.Windows.Forms.TabPage();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPng = new System.Windows.Forms.Button();
            this.btnBmp = new System.Windows.Forms.Button();
            this.btnJpeg = new System.Windows.Forms.Button();
            this.pctbxRender = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnVideo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numOfThreads)).BeginInit();
            this.SettingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SphereDataGrid)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Graphs.SuspendLayout();
            this.Images.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxRender)).BeginInit();
            this.SuspendLayout();
            // 
            // chrtTimeTaken
            // 
            this.chrtTimeTaken.Location = new System.Drawing.Point(0, 5);
            this.chrtTimeTaken.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chrtTimeTaken.Name = "chrtTimeTaken";
            this.chrtTimeTaken.Size = new System.Drawing.Size(982, 445);
            this.chrtTimeTaken.TabIndex = 0;
            this.chrtTimeTaken.Text = "Time Taken";
            // 
            // txtbxLog
            // 
            this.txtbxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbxLog.Location = new System.Drawing.Point(1002, 14);
            this.txtbxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbxLog.Name = "txtbxLog";
            this.txtbxLog.ReadOnly = true;
            this.txtbxLog.Size = new System.Drawing.Size(648, 446);
            this.txtbxLog.TabIndex = 2;
            this.txtbxLog.Text = "Welcome to the Ray Tracer App\n";
            // 
            // btnRayTracer
            // 
            this.btnRayTracer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRayTracer.Location = new System.Drawing.Point(1490, 478);
            this.btnRayTracer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRayTracer.Name = "btnRayTracer";
            this.btnRayTracer.Size = new System.Drawing.Size(488, 100);
            this.btnRayTracer.TabIndex = 5;
            this.btnRayTracer.Text = "Ray Tracer";
            this.btnRayTracer.UseVisualStyleBackColor = true;
            this.btnRayTracer.Click += new System.EventHandler(this.btnRayTracer_Click);
            // 
            // chckbxThreaded
            // 
            this.chckbxThreaded.AutoSize = true;
            this.chckbxThreaded.Checked = true;
            this.chckbxThreaded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckbxThreaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.chckbxThreaded.Location = new System.Drawing.Point(72, 48);
            this.chckbxThreaded.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chckbxThreaded.Name = "chckbxThreaded";
            this.chckbxThreaded.Size = new System.Drawing.Size(166, 33);
            this.chckbxThreaded.TabIndex = 6;
            this.chckbxThreaded.Text = "Threaded?";
            this.chckbxThreaded.UseVisualStyleBackColor = true;
            // 
            // numOfThreads
            // 
            this.numOfThreads.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numOfThreads.Location = new System.Drawing.Point(142, 106);
            this.numOfThreads.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numOfThreads.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numOfThreads.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numOfThreads.Name = "numOfThreads";
            this.numOfThreads.Size = new System.Drawing.Size(120, 35);
            this.numOfThreads.TabIndex = 7;
            this.numOfThreads.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // txtbxPicHeight
            // 
            this.txtbxPicHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtbxPicHeight.Location = new System.Drawing.Point(142, 198);
            this.txtbxPicHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbxPicHeight.Name = "txtbxPicHeight";
            this.txtbxPicHeight.Size = new System.Drawing.Size(100, 35);
            this.txtbxPicHeight.TabIndex = 8;
            // 
            // txtbxPicWidth
            // 
            this.txtbxPicWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtbxPicWidth.Location = new System.Drawing.Point(142, 245);
            this.txtbxPicWidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbxPicWidth.Name = "txtbxPicWidth";
            this.txtbxPicWidth.Size = new System.Drawing.Size(100, 35);
            this.txtbxPicWidth.TabIndex = 9;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblHeight.Location = new System.Drawing.Point(52, 202);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(89, 29);
            this.lblHeight.TabIndex = 10;
            this.lblHeight.Text = "Height:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblWidth.Location = new System.Drawing.Point(57, 249);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(80, 29);
            this.lblWidth.TabIndex = 11;
            this.lblWidth.Text = "Width:";
            // 
            // chrtSubTimes
            // 
            this.chrtSubTimes.Location = new System.Drawing.Point(2, 478);
            this.chrtSubTimes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chrtSubTimes.Name = "chrtSubTimes";
            this.chrtSubTimes.Size = new System.Drawing.Size(982, 418);
            this.chrtSubTimes.TabIndex = 12;
            this.chrtSubTimes.Text = "Time Taken";
            // 
            // txtbxFrames
            // 
            this.txtbxFrames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtbxFrames.Location = new System.Drawing.Point(142, 151);
            this.txtbxFrames.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbxFrames.Name = "txtbxFrames";
            this.txtbxFrames.Size = new System.Drawing.Size(100, 35);
            this.txtbxFrames.TabIndex = 13;
            // 
            // lblFrames
            // 
            this.lblFrames.AutoSize = true;
            this.lblFrames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblFrames.Location = new System.Drawing.Point(40, 155);
            this.lblFrames.Name = "lblFrames";
            this.lblFrames.Size = new System.Drawing.Size(101, 29);
            this.lblFrames.TabIndex = 14;
            this.lblFrames.Text = "Frames:";
            // 
            // lblThreads
            // 
            this.lblThreads.AutoSize = true;
            this.lblThreads.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblThreads.Location = new System.Drawing.Point(33, 109);
            this.lblThreads.Name = "lblThreads";
            this.lblThreads.Size = new System.Drawing.Size(109, 29);
            this.lblThreads.TabIndex = 16;
            this.lblThreads.Text = "Threads:";
            // 
            // SettingsBox
            // 
            this.SettingsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsBox.Controls.Add(this.lblFps);
            this.SettingsBox.Controls.Add(this.txtbxFps);
            this.SettingsBox.Controls.Add(this.label1);
            this.SettingsBox.Controls.Add(this.cmbBxOptimzation);
            this.SettingsBox.Controls.Add(this.chckbxThreaded);
            this.SettingsBox.Controls.Add(this.lblFrames);
            this.SettingsBox.Controls.Add(this.txtbxFrames);
            this.SettingsBox.Controls.Add(this.lblThreads);
            this.SettingsBox.Controls.Add(this.numOfThreads);
            this.SettingsBox.Controls.Add(this.lblWidth);
            this.SettingsBox.Controls.Add(this.txtbxPicHeight);
            this.SettingsBox.Controls.Add(this.lblHeight);
            this.SettingsBox.Controls.Add(this.txtbxPicWidth);
            this.SettingsBox.Location = new System.Drawing.Point(1658, 15);
            this.SettingsBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.SettingsBox.Name = "SettingsBox";
            this.SettingsBox.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.SettingsBox.Size = new System.Drawing.Size(320, 446);
            this.SettingsBox.TabIndex = 17;
            this.SettingsBox.TabStop = false;
            this.SettingsBox.Text = "Settings";
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblFps.Location = new System.Drawing.Point(71, 345);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(66, 29);
            this.lblFps.TabIndex = 20;
            this.lblFps.Text = "FPS:";
            // 
            // txtbxFps
            // 
            this.txtbxFps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtbxFps.Location = new System.Drawing.Point(142, 339);
            this.txtbxFps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbxFps.Name = "txtbxFps";
            this.txtbxFps.Size = new System.Drawing.Size(100, 35);
            this.txtbxFps.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(21, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "Efficiency:";
            // 
            // cmbBxOptimzation
            // 
            this.cmbBxOptimzation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbBxOptimzation.FormattingEnabled = true;
            this.cmbBxOptimzation.Location = new System.Drawing.Point(142, 289);
            this.cmbBxOptimzation.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbBxOptimzation.Name = "cmbBxOptimzation";
            this.cmbBxOptimzation.Size = new System.Drawing.Size(136, 37);
            this.cmbBxOptimzation.TabIndex = 17;
            // 
            // SphereDataGrid
            // 
            this.SphereDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SphereDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SphereDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SphereDataGrid.Location = new System.Drawing.Point(1002, 585);
            this.SphereDataGrid.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.SphereDataGrid.Name = "SphereDataGrid";
            this.SphereDataGrid.RowTemplate.Height = 24;
            this.SphereDataGrid.Size = new System.Drawing.Size(974, 338);
            this.SphereDataGrid.TabIndex = 18;
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Location = new System.Drawing.Point(1002, 478);
            this.btnUpdateData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(482, 100);
            this.btnUpdateData.TabIndex = 19;
            this.btnUpdateData.Text = "Update Data";
            this.btnUpdateData.UseVisualStyleBackColor = true;
            this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Graphs);
            this.tabControl1.Controls.Add(this.Images);
            this.tabControl1.Location = new System.Drawing.Point(2, -5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(994, 943);
            this.tabControl1.TabIndex = 20;
            // 
            // Graphs
            // 
            this.Graphs.Controls.Add(this.chrtTimeTaken);
            this.Graphs.Controls.Add(this.chrtSubTimes);
            this.Graphs.Location = new System.Drawing.Point(4, 29);
            this.Graphs.Name = "Graphs";
            this.Graphs.Padding = new System.Windows.Forms.Padding(3);
            this.Graphs.Size = new System.Drawing.Size(986, 910);
            this.Graphs.TabIndex = 0;
            this.Graphs.Text = "Graphs";
            this.Graphs.UseVisualStyleBackColor = true;
            // 
            // Images
            // 
            this.Images.Controls.Add(this.btnVideo);
            this.Images.Controls.Add(this.btnPause);
            this.Images.Controls.Add(this.btnPng);
            this.Images.Controls.Add(this.btnBmp);
            this.Images.Controls.Add(this.btnJpeg);
            this.Images.Controls.Add(this.pctbxRender);
            this.Images.Location = new System.Drawing.Point(4, 29);
            this.Images.Name = "Images";
            this.Images.Padding = new System.Windows.Forms.Padding(3);
            this.Images.Size = new System.Drawing.Size(986, 910);
            this.Images.TabIndex = 1;
            this.Images.Text = "Images";
            this.Images.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(8, 838);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(150, 65);
            this.btnPause.TabIndex = 7;
            this.btnPause.Text = "Load";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPng
            // 
            this.btnPng.Location = new System.Drawing.Point(574, 839);
            this.btnPng.Name = "btnPng";
            this.btnPng.Size = new System.Drawing.Size(200, 65);
            this.btnPng.TabIndex = 5;
            this.btnPng.Text = "PNG";
            this.btnPng.UseVisualStyleBackColor = true;
            this.btnPng.Click += new System.EventHandler(this.btnPng_Click);
            // 
            // btnBmp
            // 
            this.btnBmp.Location = new System.Drawing.Point(164, 839);
            this.btnBmp.Name = "btnBmp";
            this.btnBmp.Size = new System.Drawing.Size(200, 65);
            this.btnBmp.TabIndex = 5;
            this.btnBmp.Text = "BMP";
            this.btnBmp.UseVisualStyleBackColor = true;
            this.btnBmp.Click += new System.EventHandler(this.btnBmp_Click);
            // 
            // btnJpeg
            // 
            this.btnJpeg.Location = new System.Drawing.Point(370, 838);
            this.btnJpeg.Name = "btnJpeg";
            this.btnJpeg.Size = new System.Drawing.Size(200, 65);
            this.btnJpeg.TabIndex = 4;
            this.btnJpeg.Text = "JPEG";
            this.btnJpeg.UseVisualStyleBackColor = true;
            this.btnJpeg.Click += new System.EventHandler(this.btnJpeg_Click);
            // 
            // pctbxRender
            // 
            this.pctbxRender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctbxRender.Location = new System.Drawing.Point(6, 3);
            this.pctbxRender.Name = "pctbxRender";
            this.pctbxRender.Size = new System.Drawing.Size(978, 829);
            this.pctbxRender.TabIndex = 0;
            this.pctbxRender.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnVideo
            // 
            this.btnVideo.Location = new System.Drawing.Point(780, 839);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(200, 65);
            this.btnVideo.TabIndex = 8;
            this.btnVideo.Text = "Make Video";
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1990, 938);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnUpdateData);
            this.Controls.Add(this.SphereDataGrid);
            this.Controls.Add(this.SettingsBox);
            this.Controls.Add(this.btnRayTracer);
            this.Controls.Add(this.txtbxLog);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "Ray Tracer";
            ((System.ComponentModel.ISupportInitialize)(this.numOfThreads)).EndInit();
            this.SettingsBox.ResumeLayout(false);
            this.SettingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SphereDataGrid)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Graphs.ResumeLayout(false);
            this.Images.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctbxRender)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private LiveCharts.WinForms.CartesianChart chrtTimeTaken;
        private System.Windows.Forms.RichTextBox txtbxLog;
        private System.Windows.Forms.Button btnRayTracer;
        private System.Windows.Forms.CheckBox chckbxThreaded;
        private System.Windows.Forms.NumericUpDown numOfThreads;
        private System.Windows.Forms.TextBox txtbxPicHeight;
        private System.Windows.Forms.TextBox txtbxPicWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private LiveCharts.WinForms.CartesianChart chrtSubTimes;
        private System.Windows.Forms.TextBox txtbxFrames;
        private System.Windows.Forms.Label lblFrames;
        private System.Windows.Forms.Label lblThreads;
        private System.Windows.Forms.GroupBox SettingsBox;
        private System.Windows.Forms.DataGridView SphereDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBxOptimzation;
        private System.Windows.Forms.Button btnUpdateData;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Graphs;
        private System.Windows.Forms.TabPage Images;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPng;
        private System.Windows.Forms.Button btnBmp;
        private System.Windows.Forms.Button btnJpeg;
        private System.Windows.Forms.PictureBox pctbxRender;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.TextBox txtbxFps;
        private System.Windows.Forms.Button btnVideo;
    }
}

