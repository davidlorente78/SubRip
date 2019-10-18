﻿using Segmentation;
using SubripServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Subrip
{
	public partial class Form1 : Form
    {
        Char CaracterToDetect = '晚';
        Color SelectedColor = Color.Black;
        Int64 [] Ranges = new Int64[1000];
       
        Int32 numseg = 0; //Cursor para pintar en el panel 1 los detectados
        public Form1()
        {
            InitializeComponent();                              
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Process();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process();
			
        }

        private void Process()
        {    
            Bitmap bitmapFromScreen = BitmapService.BitmapFromScreen(Convert.ToInt32(this.numericUpDownSizex.Value),Convert.ToInt32(this.numericUpDownSizey.Value),Convert.ToInt32(this.numericUpDownLeft.Value),Convert.ToInt32(this.numericUpDownTop.Value));
            pictureBox1.Image = bitmapFromScreen;

            Projection projectionBitMapFilter = ProjectionService.ProjectandFilter(SelectedColor, Convert.ToInt32(this.numericUpDownColorMargin.Value), bitmapFromScreen);
            ProjectionsToChartSeries(projectionBitMapFilter);
            this.pictureBox2.Image = projectionBitMapFilter.Bitmap;

			projectionBitMapFilter.HorizontalSegments = ProjectionService.ToSegments(projectionBitMapFilter.HorizontalProjection, projectionBitMapFilter.Bitmap.Height);
            projectionBitMapFilter.VerticalSegments = new List<Segment>();

			if (SubtitlesDetected(projectionBitMapFilter.HorizontalSegments))
            {                
                long Range = projectionBitMapFilter.HorizontalSegments[0].End - projectionBitMapFilter.HorizontalSegments[0].Starts;             
                Int64 AverageRange = MathHelper.Average(Ranges);

				projectionBitMapFilter.VerticalSegments = ProjectionService.ToSegments(projectionBitMapFilter.VerticalProjection, projectionBitMapFilter.Bitmap.Height);

                if (projectionBitMapFilter.VerticalSegments.Count != 0)
				{
					projectionBitMapFilter = ProjectionService.MaxMinEvaluation(bitmapFromScreen.Height, projectionBitMapFilter);

					List<Segment> GroupedSegments = SegmentationService.GroupSegments(projectionBitMapFilter.VerticalSegments);

					Bitmap bitmapInitialSegments = (Bitmap)projectionBitMapFilter.Bitmap.Clone();
					Bitmap bitmapGroupedSegments = (Bitmap)projectionBitMapFilter.Bitmap.Clone();

					this.pictureBox2.Image = BitmapService.DrawSegmentsinBitmap(projectionBitMapFilter.VerticalSegments, bitmapInitialSegments, Brushes.DarkRed);
					this.pictureBoxGrouped.Image = BitmapService.DrawSegmentsinBitmap(GroupedSegments, bitmapGroupedSegments, Brushes.Orange);
					List<Bitmap> cropped = BitmapService.ExtractCropBitmaps(GroupedSegments, projectionBitMapFilter.Bitmap);


					

					CroppedBitmapsToScreen(cropped);

				}
				
            }
        }



		private void CroppedBitmapsToScreen(List<Bitmap> cropped)
		{
			foreach (Bitmap bitmap in cropped)
			{
				
				PictureBox pc = new PictureBox
				{
					BorderStyle = BorderStyle.None,
					Height = Convert.ToInt32(32),
					Width = Convert.ToInt32(32),
					SizeMode = PictureBoxSizeMode.Normal,

					Top = 0,
					Left = numseg * Convert.ToInt32(34), //80 pixels de separacion entre controles
					Image = BitmapService.ResizeImage(bitmap, 32)
				};

				this.panel1.Controls.Add(pc);
				numseg++;

			}
		}

		private void Form1_Load(object sender, EventArgs e)
        {
            this.numericUpDownRatioTh.Value = 0.78m; //Determinado mediante pruebas          
            numericUpDownFontSize.Maximum = 300;
            numericUpDownFontSize.Value = 32; //Debe estar relacionado con el tamaño de Heigh de Captura

          
        }
              

		private void button2_Click(object sender, EventArgs e)
		{
			colorDialog1.ShowDialog();
			SelectedColor = colorDialog1.Color;
		}

        //Dado un Bitmap y los segmentos localizados en el, traza los rectangulos que enmarcan los segmentos con el Brush y lo vuelca en pb que se pasa como parametro. 
      
        private bool SubtitlesDetected(List<Segment> HorizontalSegments)
        {
            return (HorizontalSegments.Count == 1);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.numericUpDownInterval.Value) != 0)
                timer1.Interval = Convert.ToInt32(this.numericUpDownInterval.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

      
        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void ProjectionsToChartSeries(Projection projectionBitOut)
        {
            chart1.Series["X"].Points.Clear();
            chart2.Series["Y"].Points.Clear();

            //En este punto estan calculadas las projecciones horizontal y vertical
            for (Int32 x = 0; x < projectionBitOut.VerticalProjection.Length; x++)
            {
                chart1.Series["X"].Points.AddXY(Convert.ToDouble(x), Convert.ToDouble(projectionBitOut.VerticalProjection[x]));
            }

            chart1.Series["X"].ChartType = SeriesChartType.FastLine;
            chart1.Series["X"].Color = Color.Red;

            for (Int32 y = 0; y < projectionBitOut.HorizontalProjection.Length; y++)
            {
                chart2.Series["Y"].Points.AddXY(Convert.ToDouble(y), Convert.ToDouble(projectionBitOut.HorizontalProjection[y]));
            }

            chart2.Series["Y"].ChartType = SeriesChartType.FastLine;
            chart2.Series["Y"].Color = Color.Black;
        }
       
    }
}
