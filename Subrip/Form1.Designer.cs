namespace Subrip
{
    partial class Form1
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.numericUpDownTop = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownLeft = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownSizex = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownSizey = new System.Windows.Forms.NumericUpDown();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.button2 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
			this.button3 = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.numericUpDownColorMargin = new System.Windows.Forms.NumericUpDown();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.button5 = new System.Windows.Forms.Button();
			this.comboBoxScreen = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.numericUpDownDistance = new System.Windows.Forms.NumericUpDown();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBoxGrouped = new System.Windows.Forms.PictureBox();
			this.label11 = new System.Windows.Forms.Label();
			this.numericUpDownRatioTh = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeft)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizey)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownColorMargin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrouped)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRatioTh)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(11, 129);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(450, 82);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(11, 55);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(56, 19);
			this.button1.TabIndex = 1;
			this.button1.Text = "Capture";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// numericUpDownTop
			// 
			this.numericUpDownTop.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.numericUpDownTop.Location = new System.Drawing.Point(11, 28);
			this.numericUpDownTop.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownTop.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.numericUpDownTop.Name = "numericUpDownTop";
			this.numericUpDownTop.Size = new System.Drawing.Size(54, 20);
			this.numericUpDownTop.TabIndex = 2;
			this.numericUpDownTop.Value = new decimal(new int[] {
            900,
            0,
            0,
            0});
			// 
			// numericUpDownLeft
			// 
			this.numericUpDownLeft.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.numericUpDownLeft.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.numericUpDownLeft.Location = new System.Drawing.Point(70, 29);
			this.numericUpDownLeft.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownLeft.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.numericUpDownLeft.Name = "numericUpDownLeft";
			this.numericUpDownLeft.Size = new System.Drawing.Size(54, 20);
			this.numericUpDownLeft.TabIndex = 3;
			// 
			// numericUpDownSizex
			// 
			this.numericUpDownSizex.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.numericUpDownSizex.Location = new System.Drawing.Point(129, 29);
			this.numericUpDownSizex.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownSizex.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.numericUpDownSizex.Name = "numericUpDownSizex";
			this.numericUpDownSizex.Size = new System.Drawing.Size(57, 20);
			this.numericUpDownSizex.TabIndex = 4;
			this.numericUpDownSizex.Value = new decimal(new int[] {
            450,
            0,
            0,
            0});
			// 
			// numericUpDownSizey
			// 
			this.numericUpDownSizey.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.numericUpDownSizey.Location = new System.Drawing.Point(190, 29);
			this.numericUpDownSizey.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownSizey.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.numericUpDownSizey.Name = "numericUpDownSizey";
			this.numericUpDownSizey.Size = new System.Drawing.Size(57, 20);
			this.numericUpDownSizey.TabIndex = 5;
			this.numericUpDownSizey.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(318, 28);
			this.button2.Margin = new System.Windows.Forms.Padding(2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(56, 19);
			this.button2.TabIndex = 6;
			this.button2.Text = "Color";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// numericUpDownInterval
			// 
			this.numericUpDownInterval.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.numericUpDownInterval.Location = new System.Drawing.Point(257, 28);
			this.numericUpDownInterval.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownInterval.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.numericUpDownInterval.Name = "numericUpDownInterval";
			this.numericUpDownInterval.Size = new System.Drawing.Size(56, 20);
			this.numericUpDownInterval.TabIndex = 7;
			this.numericUpDownInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownInterval.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(71, 55);
			this.button3.Margin = new System.Windows.Forms.Padding(2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(56, 19);
			this.button3.TabIndex = 9;
			this.button3.Text = "Start";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox2.Location = new System.Drawing.Point(11, 216);
			this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(450, 82);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 10;
			this.pictureBox2.TabStop = false;
			// 
			// numericUpDownColorMargin
			// 
			this.numericUpDownColorMargin.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.numericUpDownColorMargin.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.numericUpDownColorMargin.Location = new System.Drawing.Point(12, 100);
			this.numericUpDownColorMargin.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownColorMargin.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.numericUpDownColorMargin.Name = "numericUpDownColorMargin";
			this.numericUpDownColorMargin.Size = new System.Drawing.Size(56, 20);
			this.numericUpDownColorMargin.TabIndex = 11;
			this.numericUpDownColorMargin.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			this.chart1.Location = new System.Drawing.Point(9, 392);
			this.chart1.Margin = new System.Windows.Forms.Padding(2);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Name = "X";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(363, 82);
			this.chart1.TabIndex = 13;
			this.chart1.Text = "chart1";
			// 
			// chart2
			// 
			chartArea2.Name = "ChartArea1";
			this.chart2.ChartAreas.Add(chartArea2);
			this.chart2.Location = new System.Drawing.Point(377, 392);
			this.chart2.Margin = new System.Windows.Forms.Padding(2);
			this.chart2.Name = "chart2";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Name = "Y";
			this.chart2.Series.Add(series2);
			this.chart2.Size = new System.Drawing.Size(84, 82);
			this.chart2.TabIndex = 15;
			this.chart2.Text = "chart2";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(131, 55);
			this.button5.Margin = new System.Windows.Forms.Padding(2);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(56, 19);
			this.button5.TabIndex = 18;
			this.button5.Text = "Stop";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// comboBoxScreen
			// 
			this.comboBoxScreen.FormattingEnabled = true;
			this.comboBoxScreen.Items.AddRange(new object[] {
            "Screen 1",
            "Screen 2"});
			this.comboBoxScreen.Location = new System.Drawing.Point(240, 55);
			this.comboBoxScreen.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxScreen.Name = "comboBoxScreen";
			this.comboBoxScreen.Size = new System.Drawing.Size(104, 21);
			this.comboBoxScreen.TabIndex = 22;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 7);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Top";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(124, 7);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "Width";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(65, 7);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(25, 13);
			this.label3.TabIndex = 25;
			this.label3.Text = "Left";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(186, 7);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 26;
			this.label4.Text = "Height";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(253, 6);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 13);
			this.label5.TabIndex = 27;
			this.label5.Text = "Interval";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 79);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 13);
			this.label6.TabIndex = 28;
			this.label6.Text = "Color Margin";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(195, 58);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(41, 13);
			this.label9.TabIndex = 31;
			this.label9.Text = "Screen";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(71, 79);
			this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(65, 13);
			this.label10.TabIndex = 33;
			this.label10.Text = "Distance Th";
			// 
			// numericUpDownDistance
			// 
			this.numericUpDownDistance.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.numericUpDownDistance.Location = new System.Drawing.Point(74, 100);
			this.numericUpDownDistance.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownDistance.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.numericUpDownDistance.Name = "numericUpDownDistance";
			this.numericUpDownDistance.Size = new System.Drawing.Size(56, 20);
			this.numericUpDownDistance.TabIndex = 32;
			this.numericUpDownDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(9, 484);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(452, 73);
			this.panel1.TabIndex = 34;
			// 
			// pictureBoxGrouped
			// 
			this.pictureBoxGrouped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxGrouped.Location = new System.Drawing.Point(11, 302);
			this.pictureBoxGrouped.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBoxGrouped.Name = "pictureBoxGrouped";
			this.pictureBoxGrouped.Size = new System.Drawing.Size(450, 82);
			this.pictureBoxGrouped.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxGrouped.TabIndex = 35;
			this.pictureBoxGrouped.TabStop = false;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(140, 79);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 13);
			this.label11.TabIndex = 37;
			this.label11.Text = "Ratio Th";
			// 
			// numericUpDownRatioTh
			// 
			this.numericUpDownRatioTh.DecimalPlaces = 2;
			this.numericUpDownRatioTh.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.numericUpDownRatioTh.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDownRatioTh.Location = new System.Drawing.Point(142, 100);
			this.numericUpDownRatioTh.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownRatioTh.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownRatioTh.Name = "numericUpDownRatioTh";
			this.numericUpDownRatioTh.Size = new System.Drawing.Size(56, 20);
			this.numericUpDownRatioTh.TabIndex = 36;
			this.numericUpDownRatioTh.Value = new decimal(new int[] {
            95,
            0,
            0,
            131072});
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(201, 78);
			this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(51, 13);
			this.label13.TabIndex = 41;
			this.label13.Text = "Font Size";
			// 
			// numericUpDownFontSize
			// 
			this.numericUpDownFontSize.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.numericUpDownFontSize.Location = new System.Drawing.Point(204, 100);
			this.numericUpDownFontSize.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.numericUpDownFontSize.Name = "numericUpDownFontSize";
			this.numericUpDownFontSize.Size = new System.Drawing.Size(56, 20);
			this.numericUpDownFontSize.TabIndex = 40;
			this.numericUpDownFontSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
			// 
			// toolTip1
			// 
			this.toolTip1.IsBalloon = true;
			// 
			// panel2
			// 
			this.panel2.Location = new System.Drawing.Point(10, 561);
			this.panel2.Margin = new System.Windows.Forms.Padding(2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(452, 73);
			this.panel2.TabIndex = 42;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(473, 639);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.numericUpDownFontSize);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.numericUpDownRatioTh);
			this.Controls.Add(this.pictureBoxGrouped);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.numericUpDownDistance);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxScreen);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.chart2);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.numericUpDownColorMargin);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.numericUpDownInterval);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.numericUpDownSizey);
			this.Controls.Add(this.numericUpDownSizex);
			this.Controls.Add(this.numericUpDownLeft);
			this.Controls.Add(this.numericUpDownTop);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SubRip";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeft)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizey)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownColorMargin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrouped)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRatioTh)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDownTop;
        private System.Windows.Forms.NumericUpDown numericUpDownLeft;
        private System.Windows.Forms.NumericUpDown numericUpDownSizex;
        private System.Windows.Forms.NumericUpDown numericUpDownSizey;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownColorMargin;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBoxScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownDistance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxGrouped;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownRatioTh;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Panel panel2;
	}
}

