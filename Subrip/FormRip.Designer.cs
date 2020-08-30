namespace Subrip
{
    partial class FormRip
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDownTop = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLeft = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSizeWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSizeHeight = new System.Windows.Forms.NumericUpDown();
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
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeHeight)).BeginInit();
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
            this.pictureBox1.Location = new System.Drawing.Point(16, 124);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1013, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 29);
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
            this.numericUpDownTop.Location = new System.Drawing.Point(16, 43);
            this.numericUpDownTop.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericUpDownTop.Name = "numericUpDownTop";
            this.numericUpDownTop.Size = new System.Drawing.Size(81, 26);
            this.numericUpDownTop.TabIndex = 2;
            this.numericUpDownTop.Value = new decimal(new int[] {
            1300,
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
            this.numericUpDownLeft.Location = new System.Drawing.Point(105, 45);
            this.numericUpDownLeft.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericUpDownLeft.Name = "numericUpDownLeft";
            this.numericUpDownLeft.Size = new System.Drawing.Size(81, 26);
            this.numericUpDownLeft.TabIndex = 3;
            this.numericUpDownLeft.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // numericUpDownSizeWidth
            // 
            this.numericUpDownSizeWidth.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownSizeWidth.Location = new System.Drawing.Point(194, 45);
            this.numericUpDownSizeWidth.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericUpDownSizeWidth.Name = "numericUpDownSizeWidth";
            this.numericUpDownSizeWidth.Size = new System.Drawing.Size(86, 26);
            this.numericUpDownSizeWidth.TabIndex = 4;
            this.numericUpDownSizeWidth.Value = new decimal(new int[] {
            450,
            0,
            0,
            0});
            // 
            // numericUpDownSizeHeight
            // 
            this.numericUpDownSizeHeight.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownSizeHeight.Location = new System.Drawing.Point(285, 45);
            this.numericUpDownSizeHeight.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericUpDownSizeHeight.Name = "numericUpDownSizeHeight";
            this.numericUpDownSizeHeight.Size = new System.Drawing.Size(86, 26);
            this.numericUpDownSizeHeight.TabIndex = 5;
            this.numericUpDownSizeHeight.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(477, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 29);
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
            this.numericUpDownInterval.Location = new System.Drawing.Point(386, 43);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(84, 26);
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
            this.button3.Location = new System.Drawing.Point(201, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 29);
            this.button3.TabIndex = 9;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(16, 258);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1013, 125);
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
            this.numericUpDownColorMargin.Location = new System.Drawing.Point(593, 43);
            this.numericUpDownColorMargin.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericUpDownColorMargin.Name = "numericUpDownColorMargin";
            this.numericUpDownColorMargin.Size = new System.Drawing.Size(84, 26);
            this.numericUpDownColorMargin.TabIndex = 11;
            this.numericUpDownColorMargin.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Location = new System.Drawing.Point(14, 529);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "X";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(885, 126);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            this.chart2.Location = new System.Drawing.Point(904, 529);
            this.chart2.Name = "chart2";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Name = "Y";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(126, 126);
            this.chart2.TabIndex = 15;
            this.chart2.Text = "chart2";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(291, 78);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 29);
            this.button5.TabIndex = 18;
            this.button5.Text = "Stop";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBoxScreen
            // 
            this.comboBoxScreen.FormattingEnabled = true;
            this.comboBoxScreen.Items.AddRange(new object[] {
            "Main",
            "Secondary"});
            this.comboBoxScreen.Location = new System.Drawing.Point(455, 78);
            this.comboBoxScreen.Name = "comboBoxScreen";
            this.comboBoxScreen.Size = new System.Drawing.Size(154, 28);
            this.comboBoxScreen.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Top";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Left";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Height";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(380, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Interval";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(590, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "Color Margin";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(387, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 31;
            this.label9.Text = "Screen";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(681, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "Distance Th";
            // 
            // numericUpDownDistance
            // 
            this.numericUpDownDistance.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numericUpDownDistance.Location = new System.Drawing.Point(686, 43);
            this.numericUpDownDistance.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownDistance.Name = "numericUpDownDistance";
            this.numericUpDownDistance.Size = new System.Drawing.Size(84, 26);
            this.numericUpDownDistance.TabIndex = 32;
            this.numericUpDownDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(14, 671);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 112);
            this.panel1.TabIndex = 34;
            // 
            // pictureBoxGrouped
            // 
            this.pictureBoxGrouped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGrouped.Location = new System.Drawing.Point(16, 391);
            this.pictureBoxGrouped.Name = "pictureBoxGrouped";
            this.pictureBoxGrouped.Size = new System.Drawing.Size(1013, 125);
            this.pictureBoxGrouped.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGrouped.TabIndex = 35;
            this.pictureBoxGrouped.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(785, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 20);
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
            this.numericUpDownRatioTh.Location = new System.Drawing.Point(788, 43);
            this.numericUpDownRatioTh.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRatioTh.Name = "numericUpDownRatioTh";
            this.numericUpDownRatioTh.Size = new System.Drawing.Size(84, 26);
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
            this.label13.Location = new System.Drawing.Point(877, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 20);
            this.label13.TabIndex = 41;
            this.label13.Text = "Font Size";
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numericUpDownFontSize.Location = new System.Drawing.Point(881, 43);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(84, 26);
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
            this.panel2.Location = new System.Drawing.Point(15, 789);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 112);
            this.panel2.TabIndex = 42;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(894, 982);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(136, 29);
            this.button4.TabIndex = 43;
            this.button4.Text = "Add to Dataset";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(18, 77);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 29);
            this.button6.TabIndex = 44;
            this.button6.Text = "Select";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.VisibleChanged += new System.EventHandler(this.button6_VisibleChanged);
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // FormRip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1036, 1028);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
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
            this.Controls.Add(this.numericUpDownSizeHeight);
            this.Controls.Add(this.numericUpDownSizeWidth);
            this.Controls.Add(this.numericUpDownLeft);
            this.Controls.Add(this.numericUpDownTop);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormRip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SubRip";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeHeight)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numericUpDownSizeWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeHeight;
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
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
    }
}

