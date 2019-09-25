using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Subrip{
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
					List<Bitmap> cropped = BitmapService.ExtractCropBitmaps(GroupedSegments, bitmapGroupedSegments);

					CroppedBitmapsToScreen(cropped);

				}
				else textBoxProcessInfo.Text = "Line Detected without Vertical Segments";
            }
        }



		private void CroppedBitmapsToScreen(List<Bitmap> cropped)
		{
			foreach (Bitmap bitmap in cropped)
			{
				PictureBox pc = new PictureBox();
				pc.BorderStyle = BorderStyle.FixedSingle;
				pc.Height = Convert.ToInt32(panel1.Height);
				pc.Width = Convert.ToInt32(panel1.Height);
				pc.SizeMode = PictureBoxSizeMode.StretchImage;

				pc.Top = 0;
				pc.Left = numseg * Convert.ToInt32(80); //80 pixels de separacion entre controles
				pc.Image = bitmap;

				this.panel1.Controls.Add(pc);
				numseg++;

			}
		}

		private void Form1_Load(object sender, EventArgs e)
        {
            this.numericUpDownRatioTh.Value = 0.78m; //Determinado mediante pruebas
            numericUpDownCorrelatiopnTh.Value = 0.90m;
            numericUpDownFontSize.Maximum = 300;
            numericUpDownFontSize.Value = 32; //Debe estar relacionado con el tamaño de Heigh de Captura

            textBox3.Text = CaracterToDetect.ToString ();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Name = textBoxFile.Text;
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
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Char[] ch = textBox3.Text.ToCharArray();

            if (ch.Length != 0) CaracterToDetect = ch[0];

        }
      
        //public Bitmap ResizeImage(Image pImagen, Int32 fontPoints)
        //      {

        //          Rectangle sourceRectangleOut = new Rectangle(0, 0, pImagen.Width, pImagen.Height);
        //          Rectangle destRectangleOut = new Rectangle((Convert.ToInt32(pImagen.Width - fontPoints) / 2), (Convert.ToInt32(pImagen.Height - fontPoints) / 2), fontPoints, fontPoints);

        //          //creamos un bitmap con el nuevo tamaño
        //          Int32 SquareNormalizedSize = Math.Max(pImagen.Width, pImagen.Height);

        //          //Añado Pixel Format
        //          Bitmap vBitmap = new Bitmap(SquareNormalizedSize, SquareNormalizedSize, PixelFormat.Format64bppArgb );

        //          //creamos un graphics tomando como base el nuevo Bitmap
        //          using (Graphics vGraphics = Graphics.FromImage((Image)vBitmap))
        //          {            
        //              vGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //              vGraphics.DrawImage(pImagen, destRectangleOut);
        //          }      

        //          return vBitmap;
        //      }

      

      
    }
}
