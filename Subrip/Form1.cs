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

namespace Subrip
{
    public partial class Form1 : Form
    {
        Char CaracterToDetect = '晚';

        Int32 Index = 0;
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
            this.textBoxProcessInfo.Text = "";
            Index++;
            textBoxIndex.Text = Index.ToString();

            Bitmap bitmapFromScreen = BitmapFromScreen();
            pictureBox1.Image = bitmapFromScreen;

            Projection projectionBitMapFilter = ProjectionService.ProjectandFilter(SelectedColor, Convert.ToInt32(this.numericUpDownColorMargin.Value), bitmapFromScreen);
            ProjectionsToChartSeries(projectionBitMapFilter);
            this.pictureBox2.Image = projectionBitMapFilter.Bitmap;

            List<Segment> HorizontalSegments = ProjectionService.ToSegments(projectionBitMapFilter.HorizontalProjection, projectionBitMapFilter.Bitmap.Height);
            List<Segment> VerticalSegments = new List<Segment>();

            Int64 AverageValue = 0;


            if (SubtitlesDetected(HorizontalSegments))
            {
                //Este es el ancho de la linea de Subtitulos
                long Range = HorizontalSegments[0].End - HorizontalSegments[0].Starts;
                Ranges[Index] = Range;
                Int64 AverageRange = MathHelper.AverageRange(Ranges);

                VerticalSegments = ProjectionService.ToSegments(projectionBitMapFilter.VerticalProjection, projectionBitMapFilter.Bitmap.Height);

                if (VerticalSegments.Count != 0)
                {
                    //Para cada segmento se localizan aqui los vertices. Valores maximos y minimo que contienen informacion en el bitmap
                    for (int i = 0; i < VerticalSegments.Count; i++)
                    {
                        VerticalSegments[i].MaxValue = MathHelper.MaxValue(projectionBitMapFilter.MaxColumnValue, VerticalSegments[i].Starts, VerticalSegments[i].End);
                        VerticalSegments[i].MinValue = MathHelper.MinValue(projectionBitMapFilter.MinColumnValue, VerticalSegments[i].Starts, VerticalSegments[i].End, bitmapFromScreen.Height);
                    }

                    List<Segment> GroupedSegments = SegmentationService.GroupSegments(VerticalSegments);

                    AverageValue = MathHelper.AverageValue(projectionBitMapFilter.HorizontalProjection);


                    Bitmap forCropBitmap = (Bitmap)projectionBitMapFilter.Bitmap.Clone();
                    Bitmap bitmapInitialSegments = (Bitmap)projectionBitMapFilter.Bitmap.Clone();
                    Bitmap bitmapGroupedSegments = (Bitmap)projectionBitMapFilter.Bitmap.Clone();

                    DrawSegmentsinBitmap(VerticalSegments, bitmapInitialSegments, Brushes.DarkRed, this.pictureBox2);
                    DrawSegmentsinBitmap(GroupedSegments, bitmapGroupedSegments, Brushes.Orange, this.pictureBoxGrouped);
                    List<Bitmap> cropped = ExtractCropBitmaps(GroupedSegments, bitmapGroupedSegments);


                    CropCaracteres(forCropBitmap, GroupedSegments);

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

                    textBoxProcessInfo.Text = this.textBoxProcessInfo.Text + VerticalSegments.Count.ToString() + " -> " + GroupedSegments.Count.ToString();

                    textBoxHorizontalInfo.Text = " R : " + Range.ToString() + " Av : " + AverageValue.ToString() + " Media Av " + AverageRange.ToString();
                }

                else textBoxProcessInfo.Text = "Line Detected without Vertical Segments";
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
        private void DrawSegmentsinBitmap(List<Segment> Segments, Bitmap bitmap, Brush color,PictureBox pb)
        {
            Pen pen = new Pen(color);

            Graphics graphic = Graphics.FromImage(bitmap);
                      
            foreach (Segment s in Segments)
            {
                Point p = new Point(Convert.ToInt32(s.Starts), Convert.ToInt32( s.MinValue));                               
                Size size = new Size(Convert.ToInt32(s.End - s.Starts), Convert.ToInt32(Convert.ToInt32(s.MaxValue - s.MinValue)));
                Rectangle rec = new Rectangle(p, size);                        
                graphic.DrawRectangle(pen, rec);                               
            }
            
            pb.Image = bitmap;

        }

		private List<Bitmap> ExtractCropBitmaps(List<Segment> Segments, Bitmap bitmap)
		{
			List<Bitmap> cropped = new List<Bitmap>();

			foreach (Segment s in Segments)
			{
				Point p = new Point(Convert.ToInt32(s.Starts), Convert.ToInt32(s.MinValue));
				Size size = new Size(Convert.ToInt32(s.End - s.Starts), Convert.ToInt32(Convert.ToInt32(s.MaxValue - s.MinValue)));
				Rectangle rec = new Rectangle(p, size);

				cropped.Add(bitmap.Clone(rec, PixelFormat.Format64bppArgb));
			}

			return cropped;
		}
       

        private Bitmap BitmapFromScreen()
        {
            Rectangle region = Screen.AllScreens[0].Bounds;
            Bitmap bitmap = new Bitmap(Convert.ToInt32(numericUpDownSizex.Value), Convert.ToInt32(numericUpDownSizey.Value), PixelFormat.Format64bppArgb);

            Graphics graphic = Graphics.FromImage(bitmap);
			Size s = new Size(Convert.ToInt32(numericUpDownSizex.Value), Convert.ToInt32(numericUpDownSizey.Value));

            graphic.CopyFromScreen(Convert.ToInt32(this.numericUpDownLeft.Value), Convert.ToInt32(numericUpDownTop.Value), 0, 0, s);
            PixelFormat px = bitmap.PixelFormat;
                
           return bitmap;
        }

        private List<Bitmap> CropCaracteres(Bitmap BitOut, List<Segment> GroupedSegments)
        {
            this.panel1.Controls.Clear();

			List<Bitmap> croppedBitmaps = new List<Bitmap>();

		   numseg = 0;

			try
			{
				//Para cada segmento agrupado
				foreach (Segment GroupedSeg in GroupedSegments)
				{
					Point p = new Point(Convert.ToInt32(GroupedSeg.Starts), Convert.ToInt32(GroupedSeg.MinValue));					
					Size size = new Size(Convert.ToInt32(GroupedSeg.End - GroupedSeg.Starts), Convert.ToInt32(GroupedSeg.MaxValue - GroupedSeg.MinValue));
					Rectangle sourceRectangle = new Rectangle(p, size);					
					Bitmap CropCaracter = BitOut.Clone(sourceRectangle, PixelFormat.Format64bppArgb);
					croppedBitmaps.Add(CropCaracter);                  

                                       
     //             Int32 fontPoints = Convert.ToInt32(numericUpDownFontSize.Value);
					
					////////EVALUATE
					//Bitmap bitmapNormalized = new Bitmap(ResizeImage(CropCaracter, fontPoints));								

					//Int64[] NormalizedCaracterVerticalProjection = new Int64[bitmapNormalized.Width];
					//Int64[] NormalizedCaracterHorizontalProjection = new Int64[bitmapNormalized.Height];
					//Int32[] outMaxColumnValue = new Int32[bitmapNormalized.Width];
					//Int32[] outMinColumnValue = new Int32[bitmapNormalized.Width];
					
					//Projection projectionNormalized = GenerarProyeccionesdeBitMapCrop(bitmapNormalized);
					
					//Int64[] outVerticalProjectionCaracter = new Int64[bitmapNormalized.Width];
					//Int64[] outHorizontalProjectionCaracter = new Int64[bitmapNormalized.Width];

					//Projection projectionBitmapChar = ProjectionService.GenerateProjectionfromFontChar('晚', size, fontPoints);
                                       
     //               //Modificado Normalized por Crop
					//bool result = Evaluate(fontPoints, CropCaracter, NormalizedCaracterVerticalProjection, NormalizedCaracterHorizontalProjection, projectionBitmapChar);
					//numseg++;
				} 

			}

			catch (Exception e)
			{
				string Message = e.Message;
			}

			return croppedBitmaps;         
        }

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

        private void textBoxIndex_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxIndex.Text) == 0) Index = 0;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void checkBoxSubtitles_CheckedChanged(object sender, EventArgs e)
        {

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
        //private bool Evaluate(int fontPoints, Bitmap bitmap, long[] NormalizedCaracterVerticalProjection, long[] NormalizedCaracterHorizontalProjection,  Projection projectionCaracter)
        //{
        //	Int32 Desplazamiento = fontPoints / 2;


        //	double[] CorrelationTest = MathHelper.Correlation(Desplazamiento, NormalizedCaracterVerticalProjection, NormalizedCaracterVerticalProjection);
        //	double MaxTest = MathHelper.BuscarMaximoCorrelation(CorrelationTest);

        //	double[] CorrelationV1 = MathHelper.Correlation(Desplazamiento, projectionCaracter.VerticalProjection, NormalizedCaracterVerticalProjection);
        //	double[] CorrelationV2 = MathHelper.Correlation(Desplazamiento, NormalizedCaracterVerticalProjection, projectionCaracter.VerticalProjection);
        //	double[] CorrelationH1 = MathHelper.Correlation(Desplazamiento, projectionCaracter.HorizontalProjection, NormalizedCaracterHorizontalProjection);
        //	double[] CorrelationH2 = MathHelper.Correlation(Desplazamiento, NormalizedCaracterHorizontalProjection, projectionCaracter.HorizontalProjection);

        //	double MaxV1 = MathHelper.BuscarMaximoCorrelation(CorrelationV1);
        //	double MaxV2 = MathHelper.BuscarMaximoCorrelation(CorrelationV2);

        //	double MaxH1 = MathHelper.BuscarMaximoCorrelation(CorrelationH1);
        //	double MaxH2 = MathHelper.BuscarMaximoCorrelation(CorrelationH2);

        //	double MaxV = Math.Max(MaxV1, MaxV2);
        //	double MaxH = Math.Max(MaxH1, MaxH2);

        //	bool MachCorrelationV1 = SearchThresholdInCorrelationSerial(CorrelationV1);
        //	bool MachCorrelationV2 = SearchThresholdInCorrelationSerial(CorrelationV2);
        //	bool MachCorrelationH1 = SearchThresholdInCorrelationSerial(CorrelationH1);
        //	bool MachCorrelationH2 = SearchThresholdInCorrelationSerial(CorrelationH2);


        //	this.pictureBox3.Image = projectionCaracter.Bitmap;
        //	toolTip1.SetToolTip(this.pictureBox6, "BitmapChar");

        //	if ((MachCorrelationV1 || MachCorrelationV2) && (MachCorrelationH1 || MachCorrelationH2))

        //	{
        //		PictureBox pc = new PictureBox();

        //		pc.BorderStyle = BorderStyle.FixedSingle;

        //		pc.Height = Convert.ToInt32(panel1.Height); //Este es el ancho seleccionado para el scanner de una linea
        //		pc.Width = Convert.ToInt32(panel1.Height);
        //		pc.SizeMode = PictureBoxSizeMode.StretchImage; //Pongo en Autosize para ver que esta pasando


        //		//pc.Tooltip para informacion de proceso
        //		pc.Top = 0;
        //		pc.Left = numseg * Convert.ToInt32(80); //80 pixels de separacion entre controles

        //		pc.Image = bitmap;
        //		toolTip1.SetToolTip(pc, "MaxV:" + MaxV + "MaxH:" + MaxH);
        //		this.panel1.Controls.Add(pc);

        //		return true;				

        //	}
        //	else
        //	{

        //		PictureBox pc = new PictureBox();

        //		pc.BorderStyle = BorderStyle.None;
        //		pc.Height = Convert.ToInt32(panel1.Height); //Este es el ancho seleccionado para el scanner de una linea
        //		pc.Width = Convert.ToInt32(panel1.Height);
        //		pc.SizeMode = PictureBoxSizeMode.StretchImage; //POngo en Autosize para ver que esta pasando

        //		//pc.Tooltip para informacion de proceso
        //		pc.Top = 0;
        //		pc.Left = numseg * Convert.ToInt32(80); //80 pixels de separacion entre controles

        //		pc.Image = bitmap;
        //		toolTip1.SetToolTip(pc, "MaxV:" + MaxV + "MaxH:" + MaxH);
        //		this.panel1.Controls.Add(pc);

        //		return false; 
        //	}
        //}

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

        //private bool SearchThresholdInCorrelationSerial(double[] correlation)
        //{
        //	for (int x = 0; x < correlation.Length; x++)
        //	{
        //		if (correlation[x] > Convert.ToDouble(numericUpDownCorrelatiopnTh.Value)) return true;
        //	}

        //	return false;
        //}



        //      private Projection GenerarProyeccionesdeBitMapCrop(Bitmap bitmap)
        //{
        //	Projection projection = new Projection();
        //	Point p = new Point(0,0);

        //          Size size = new Size(bitmap.Width,bitmap.Height );
        //          Rectangle sourceRectangle = new Rectangle(p, size);

        //          Bitmap newClone = bitmap.Clone( sourceRectangle,PixelFormat.Format64bppArgb);

        //          Int64[] VerticalProjection = new Int64[bitmap.Width];
        //          Int64[] HorizontalProjection = new Int64[bitmap.Height];

        //          Int32[] MaxColumnValue = new Int32[bitmap.Width];
        //          Int32[] MinColumnValue = new Int32[bitmap.Width];

        //          //Cuando se procesa el Crop de los caracteres los pixeles con informacion son siempre negros independientemente del color del subtitulo

        //          Color colorIn;        

        //          for (Int32 x = 0; x < newClone.Width; x++)
        //          {               
        //              MaxColumnValue[x] = 0;
        //              MinColumnValue[x] = bitmap.Height;

        //              for (Int32 y = 0; y < newClone.Height; y++)
        //              {
        //                  colorIn = newClone.GetPixel(x, y);

        //                  if (colorIn.A != 0)
        //                  {
        //                      VerticalProjection[x] = VerticalProjection[x] + 1;
        //                      HorizontalProjection[y] = HorizontalProjection[y] + 1;

        //                      if (MaxColumnValue[x] < y)
        //                      {
        //                          MaxColumnValue[x] = y;
        //                      }

        //                      if (MinColumnValue[x] > y)
        //                      {
        //                          MinColumnValue[x] = y;
        //                      }

        //                  }
        //              }
        //          }

        //	projection.Bitmap = bitmap;
        //	projection.HorizontalProjection = HorizontalProjection;
        //	projection.VerticalProjection = VerticalProjection;
        //	projection.MaxColumnValue = MaxColumnValue;
        //	projection.MinColumnValue = MinColumnValue;

        //	return projection;

        //}	        


    }
}
