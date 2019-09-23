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
        Color SelectedColor = Color.White;
        Int64 [] Ranges = new Int64[1000];
       
        Int32 numseg = 0; //Cursor para pintar en el panel 1 los detectados

        public Form1()
        {
            InitializeComponent();        
                      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.numericUpDownRatioTh.Value = 0.78m; //Determinado mediante pruebas
            numericUpDownCorrelatiopnTh.Value = 0.90m;
            numericUpDownFontSize.Maximum = 300;
            numericUpDownFontSize.Value = 32; //Debe estar relacionado con el tamaño de Heigh de Captura

            textBox3.Text = CaracterToDetect.ToString ();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Procesar();
        }

		private void button2_Click(object sender, EventArgs e)
		{
			colorDialog1.ShowDialog();
			SelectedColor = colorDialog1.Color;
		}
		      

        //Localiza los pasos por cero de la projeccion y retorna los inicios y finales de los segmentos localizados
        //Atencion : Aqui no se determina el valor Maximo y Minimo
        private List< Segment> ProcessProjection(Int64[] axisProjection, Bitmap bitmap) {

            List<Segment> Segments = new List<Segment>();

            bool InicioSegmento = true;           
           
            Segment s = new Segment();

            for (int x=0; x< axisProjection.Length; x++) {

               
                //Si no es el primer valor
                if (x>0)
                {
                    if (((axisProjection[x] == 0)&&(axisProjection [x-1]!=0))|| ((axisProjection[x] != 0) && (axisProjection[x - 1] == 0))) {

                       
                        if (InicioSegmento) { s.Starts = x;
                            InicioSegmento = false; //Se va alternando el valor de la variable para saber si el cambio es debido a un inicio o a un final
                        }

                        else
                        {
                            s.End = x-1;
                            InicioSegmento = true;

                            //Inicializa Max y Min del Segmento
                            s.MaxValue = 0;
                            s.MinValue = bitmap.Height ;                        

                            Segment Add = new Segment();
                          
                            Add.Starts = s.Starts;
                            Add.End = s.End;
                        
                            Segments.Add(Add);
                        }
                        
                    }
                    
                }

                
            }
            

            return Segments;
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


        private void timer1_Tick(object sender, EventArgs e)
        {
            Procesar();

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

        private void CropCaracteres(Bitmap BitOut, List<Segment> GroupedSegments)
        {
            this.panel1.Controls.Clear();

            numseg = 0;

            try
            {
				//Para cada segmento agrupado
				foreach (Segment GroupedSeg in GroupedSegments)
				{
					//Prueba con el primer segmento detectado
					//Segmento GroupedSeg = GroupedSegments[0];


					//Igual que cuando se dibujan los rectangulos alrededor de los segmentos
					Point p = new Point(Convert.ToInt32(GroupedSeg.Starts), Convert.ToInt32(GroupedSeg.MinValue));

					Size size = new Size(Convert.ToInt32(GroupedSeg.End - GroupedSeg.Starts), Convert.ToInt32(GroupedSeg.MaxValue - GroupedSeg.MinValue));
					Rectangle sourceRectangle = new Rectangle(p, size);

					Int32 fontPoints = Convert.ToInt32(numericUpDownFontSize.Value);
					//El metodo Clone si se realiza fuera de los limites del Bitmap da mensaje de OUT of Memory
					Bitmap CropCaracter = BitOut.Clone(sourceRectangle, PixelFormat.Format64bppArgb);

					Bitmap bitmapNormalized = new Bitmap(CambiarTamanoImagen(CropCaracter, fontPoints));

					Color WhiteTest = Color.White;

					Int64[] NormalizedCaracterVerticalProjection = new Int64[bitmapNormalized.Width];
					Int64[] NormalizedCaracterHorizontalProjection = new Int64[bitmapNormalized.Height];
					Int32[] outMaxColumnValue = new Int32[bitmapNormalized.Width];
					Int32[] outMinColumnValue = new Int32[bitmapNormalized.Width];


					GenerarProyeccionesdeBitMapCrop(bitmapNormalized);



					Int32 SquareNormalizedSize = Math.Max(Size.Width, Size.Height);


					Int64[] outVerticalProjectionCaracter = new Int64[bitmapNormalized.Width];
					Int64[] outHorizontalProjectionCaracter = new Int64[bitmapNormalized.Width];


					//Char c = '晚';

					Projection projectionBitmapChar = Projector.GenerateProjectionfromFontChar(CaracterToDetect, size, fontPoints);


					Int32 Desplazamiento = fontPoints / 2;


					double[] CorrelationTest = MathHelper.Correlation(Desplazamiento, NormalizedCaracterVerticalProjection, NormalizedCaracterVerticalProjection);
					double MaxTest = BuscarMaximoCorrelation(CorrelationTest);

					double[] CorrelationV1 = MathHelper.Correlation(Desplazamiento, outVerticalProjectionCaracter, NormalizedCaracterVerticalProjection);
					double[] CorrelationV2 = MathHelper.Correlation(Desplazamiento, NormalizedCaracterVerticalProjection, outVerticalProjectionCaracter);
					double[] CorrelationH1 = MathHelper.Correlation(Desplazamiento, outHorizontalProjectionCaracter, NormalizedCaracterHorizontalProjection);
					double[] CorrelationH2 = MathHelper.Correlation(Desplazamiento, NormalizedCaracterHorizontalProjection, outHorizontalProjectionCaracter);

					double MaxV1 = BuscarMaximoCorrelation(CorrelationV1);
					double MaxV2 = BuscarMaximoCorrelation(CorrelationV2);

					double MaxH1 = BuscarMaximoCorrelation(CorrelationH1);
					double MaxH2 = BuscarMaximoCorrelation(CorrelationH2);


					double MaxV = Math.Max(MaxV1, MaxV2);
					double MaxH = Math.Max(MaxH1, MaxH2);


					bool MachCorrelationV1 = SearchThresholdInCorrelationSerial(CorrelationV1);
					bool MachCorrelationV2 = SearchThresholdInCorrelationSerial(CorrelationV2);
					bool MachCorrelationH1 = SearchThresholdInCorrelationSerial(CorrelationH1);
					bool MachCorrelationH2 = SearchThresholdInCorrelationSerial(CorrelationH2);


					this.pictureBox3.Image = projectionBitmapChar.Bitmap;
					toolTip1.SetToolTip(this.pictureBox6, "BitmapChar");



					if ((MachCorrelationV1 || MachCorrelationV2) && (MachCorrelationH1 || MachCorrelationH2))


					{
						PictureBox pc = new PictureBox();

						pc.BorderStyle = BorderStyle.FixedSingle;

						pc.Height = Convert.ToInt32(panel1.Height - 5); //Este es el ancho seleccionado para el scanner de una linea
						pc.Width = Convert.ToInt32(panel1.Height - 5);
						pc.SizeMode = PictureBoxSizeMode.StretchImage; //Pongo en Autosize para ver que esta pasando


						//pc.Tooltip para informacion de proceso
						pc.Top = 0;
						pc.Left = numseg * Convert.ToInt32(80); //80 pixels de separacion entre controles

						pc.Image = bitmapNormalized;
						toolTip1.SetToolTip(pc, "MaxV:" + MaxV + "MaxH:" + MaxH);
						this.panel1.Controls.Add(pc);
						numseg++;

					}


					else
					{

						PictureBox pc = new PictureBox();

						pc.BorderStyle = BorderStyle.None;
						pc.Height = Convert.ToInt32(panel1.Height - 5); //Este es el ancho seleccionado para el scanner de una linea
						pc.Width = Convert.ToInt32(panel1.Height - 5);
						pc.SizeMode = PictureBoxSizeMode.StretchImage; //POngo en Autosize para ver que esta pasando

						//pc.Tooltip para informacion de proceso
						pc.Top = 0;
						pc.Left = numseg * Convert.ToInt32(80); //80 pixels de separacion entre controles

						pc.Image = bitmapNormalized;
						toolTip1.SetToolTip(pc, "MaxV:" + MaxV + "MaxH:" + MaxH);
						this.panel1.Controls.Add(pc);

						numseg++;

					}

				} //Fin foreach

            }

            catch (Exception e){

                string Message = e.Message;
                //this.textBoxProcessInfo.Text = "Exception @ " + numseg.ToString() + " " ;
            }

         
        }


        public Bitmap CambiarTamanoImagen(Image pImagen, Int32 fontPoints)
        {

            Rectangle sourceRectangleOut = new Rectangle(0, 0, pImagen.Width, pImagen.Height);
            Rectangle destRectangleOut = new Rectangle((Convert.ToInt32(pImagen.Width - fontPoints) / 2), (Convert.ToInt32(pImagen.Height - fontPoints) / 2), fontPoints, fontPoints);


            //creamos un bitmap con el nuevo tamaño
            Int32 SquareNormalizedSize = Math.Max(pImagen.Width, pImagen.Height);

            //Añado Pixel Format
            Bitmap vBitmap = new Bitmap(SquareNormalizedSize, SquareNormalizedSize, PixelFormat.Format64bppArgb );

            //creamos un graphics tomando como base el nuevo Bitmap

            using (Graphics vGraphics = Graphics.FromImage((Image)vBitmap))

            {
                //especificamos el tipo de transformación, se escoge esta para no perder calidad.

                vGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //Se dibuja la nueva imagen

                //vGraphics.DrawImage(pImagen, destRectangleOut, sourceRectangleOut, GraphicsUnit.World);

                vGraphics.DrawImage(pImagen, destRectangleOut);
            }
      
            return vBitmap;

        }



		private bool SearchThresholdInCorrelationSerial(double[] correlation)
		{
			for (int x = 0; x < correlation.Length; x++)
			{
				if (correlation[x] > Convert.ToDouble(numericUpDownCorrelatiopnTh.Value)) return true;
			}

			return false;
		}

        private bool SubtitlesDetected(List<Segment> HorizontalSegments)
        {
            return (HorizontalSegments.Count == 1);
        }

        private Int64 BuscarMaximo(int[] MaxColumnValue, long starts, long end)
        {
            long Max = 0;

            for (int x = Convert.ToInt32(starts); x < end -1 ; x++)
            {
               
                if  (MaxColumnValue[x]>Max)
                {
                   Max =  MaxColumnValue[x] ;
                }
            }

            return Convert.ToInt64(Max);
        }



        private double BuscarMaximoCorrelation(double[] Correlation)
        {
            double Max = 0;

            for (int x = 0; x < Correlation.Length ; x++)
            {

                if (Correlation[x] > Max)
                {
                    Max = Correlation[x];
                }
            }

            return Max;
        }

        //Parece ser que los minimos son siempre 0 ¿?

        private long BuscarMinimo(int[] MinColumnValue, long starts, long end,long StartMax)
        {
            long Min = StartMax;

            for (int x = Convert.ToInt32(starts); x < end - 1; x++)
            {

                if  (MinColumnValue[x] < Min)
                {
                    Min = MinColumnValue[x];
                }
            }

            return Min;
        }

        private List<Segment> GroupSegments(List<Segment> verticalSegments)
        {
            List<Segment> GroupedSegments = new List<Segment>();

            double ThresholdRatio = 1 - Convert.ToDouble(numericUpDownRatioTh.Value);
            string Ratios = "";

            for (Int32 x = 0; x < verticalSegments.Count - 1; x++)
            {
                Ratios = Ratios + "[" + x.ToString() + "," + verticalSegments[x].CalculateRatio() + " ] ";
            }

            textBoxProcessInfo.Text = textBoxProcessInfo.Text + Ratios;
			
            for (Int32 x = 0; x < verticalSegments.Count ; x++)
            {
                double Ratio = verticalSegments[x].Ratio;

                double JoinedNextRatio = 0;

                if (x + 1 < verticalSegments.Count) verticalSegments[x].CalculateRatiowithNextSegmentJoined(verticalSegments[x + 1]);
              
                if ((Math.Abs(1 - Ratio) < ThresholdRatio) || (Math.Abs(1 - 1 / Ratio) < ThresholdRatio))
                {
                    GroupedSegments.Add(verticalSegments[x]);
                }

                //No se considera fusionar nunca el ultimo segmento
                else if ((x != verticalSegments.Count - 1) && ((Math.Abs(1 - JoinedNextRatio) < Math.Abs(1 - Ratio)) || (Math.Abs(1 - 1 / JoinedNextRatio) < Math.Abs(1 - 1 / Ratio))))
                {
                    GroupedSegments.Add(JoinSegments(verticalSegments[x], verticalSegments[x + 1]));
                    x++; //Para no considerar el siguiente segmento
                }
            }

           return GroupedSegments;
        }

        private Segment JoinSegments(Segment segment1, Segment segment2)
        {
            Segment Joined = new Segment();
            Joined.Starts = segment1.Starts;
            Joined.End = segment2.End;
            Joined.MaxValue = Math.Max(segment1.MaxValue, segment2.MaxValue);
            Joined.MinValue = Math.Min(segment1.MinValue, segment2.MinValue);            

            return Joined;

        }

        private Projection ProcesarBitmap(Color Color, Int32 Margin, Bitmap bitmap)
        {
			Projection projection = new Projection();

            Bitmap bitmapOut = new Bitmap(bitmap.Size.Width, bitmap.Size.Height);

            Int64[] VerticalProjection = new Int64[bitmap.Width];
            Int64[] HorizontalProjection = new Int64[bitmap.Height];
            Int32[] MaxColumnValue = new Int32[bitmap.Width];
            Int32[] MinColumnValue = new Int32[bitmap.Width];
          
            int UoR = Color.R - Margin;
            int UoV = Color.G - Margin;
            int UoA = Color.B - Margin;

            int UfR = Color.R + Margin;
            int UfV = Color.G + Margin;
            int UfA = Color.B + Margin;

			Color colorIn;

            for (Int32 x = 0; x < bitmap.Width; x++)
            {
                //Se inicializar los maximos y minimos
                MaxColumnValue[x] = 0;
                MinColumnValue[x] = bitmap.Height;

                for (Int32 y = 0; y < bitmap.Height; y++)
                {
                    colorIn = bitmap.GetPixel(x, y);

                    if ((((UoR < colorIn.R) && (colorIn.R < UfR) && (UoV < colorIn.G) && (colorIn.G < UfV) && (UoA < colorIn.B) && (colorIn.B < UfA))))
                    {
                        bitmapOut.SetPixel(x, y, Color.Black);
                        VerticalProjection[x] = VerticalProjection[x] + 1;
                        HorizontalProjection[y] = HorizontalProjection[y] + 1;
                       
                        if (MaxColumnValue[x] < y)
                        {
                            MaxColumnValue[x] = y;
                        }
                      
                        if (MinColumnValue[x] > y)
                        {
                            MinColumnValue[x] = y;
                        }
                    }                   
                }
            }

            PixelFormat px = bitmapOut.PixelFormat;

			projection.Bitmap = bitmapOut;
			projection.HorizontalProjection = HorizontalProjection;
			projection.VerticalProjection = VerticalProjection;
			projection.MaxColumnValue = MaxColumnValue;
			projection.MinColumnValue = MinColumnValue;

			return projection;


        }



        private Projection GenerarProyeccionesdeBitMapCrop(Bitmap bitmap)
		{
			Projection projection = new Projection();
			Point p = new Point(0,0);

            Size size = new Size(bitmap.Width,bitmap.Height );
            Rectangle sourceRectangle = new Rectangle(p, size);
          
            Bitmap newClone = bitmap.Clone( sourceRectangle,PixelFormat.Format64bppArgb);

            Int64[] VerticalProjection = new Int64[bitmap.Width];
            Int64[] HorizontalProjection = new Int64[bitmap.Height];

            Int32[] MaxColumnValue = new Int32[bitmap.Width];
            Int32[] MinColumnValue = new Int32[bitmap.Width];

            //Cuando se procesa el Crop de los caracteres los pixeles con informacion son siempre negros independientemente del color del subtitulo
            
            Color colorIn;
          
            int z = 0;

            for (Int32 x = 0; x < newClone.Width; x++)
            {
                //Se inicializar los maximos y minimos
                MaxColumnValue[x] = 0;
                MinColumnValue[x] = bitmap.Height;

                for (Int32 y = 0; y < newClone.Height; y++)
                {
                    colorIn = newClone.GetPixel(x, y);

                    if (colorIn.A != 0)
                    {
                        VerticalProjection[x] = VerticalProjection[x] + 1;
                        HorizontalProjection[y] = HorizontalProjection[y] + 1;

                        if (MaxColumnValue[x] < y)
                        {
                            MaxColumnValue[x] = y;
                        }

                        if (MinColumnValue[x] > y)
                        {
                            MinColumnValue[x] = y;
                        }

                    }
                }
            }

			projection.Bitmap = bitmap;
			projection.HorizontalProjection = HorizontalProjection;
			projection.VerticalProjection = VerticalProjection;
			projection.MaxColumnValue = MaxColumnValue;
			projection.MinColumnValue = MinColumnValue;

			return projection;

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
            if (Convert.ToInt32 (textBoxIndex.Text) ==0)  Index = 0 ;
        }

     
        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void checkBoxSubtitles_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Procesar()
        {

            this.textBoxProcessInfo.Text = "";
            Index++;
            textBoxIndex.Text = Index.ToString();

            Bitmap bitmap = BitmapFromScreen();					   			         

            pictureBox1.Image = bitmap;
            

            Int64[] outVerticalProjection = new Int64[bitmap.Width];
            Int64[] outHorizontalProjection = new Int64[bitmap.Height];

            Int32[] outMaxColumnValue = new Int32[bitmap.Width];
            Int32[] outMinColumnValue = new Int32[bitmap.Width];

            Projection projectionBitOut = ProcesarBitmap(SelectedColor, Convert.ToInt32(this.numericUpDownColorMargin.Value), bitmap);

            chart1.Series["X"].Points.Clear();
            chart2.Series["Y"].Points.Clear();

            //En este punto estan calculadas las projecciones horizontal y vertical
            for (Int32 x = 0; x < outVerticalProjection.Length; x++)
            {

                chart1.Series["X"].Points.AddXY(Convert.ToDouble(x), Convert.ToDouble(outVerticalProjection[x]));
            }

            chart1.Series["X"].ChartType = SeriesChartType.FastLine;
            chart1.Series["X"].Color = Color.Red;

            for (Int32 y = 0; y < outHorizontalProjection.Length; y++)
            {

                chart2.Series["Y"].Points.AddXY(Convert.ToDouble(y), Convert.ToDouble(outHorizontalProjection[y]));
            }

            chart2.Series["Y"].ChartType = SeriesChartType.FastLine;
            chart2.Series["Y"].Color = Color.Black;
            
          
            this.pictureBox2.Image = projectionBitOut.Bitmap;

            //Se realizan dos copias del bitmap procesado en blanco y negro. Uno para cada fase de la agrupación de los segmentos

            Bitmap BitmapForSegmentInitial = (Bitmap)projectionBitOut.Bitmap.Clone();
            Bitmap BitmapForGroupedSegments = (Bitmap)projectionBitOut.Bitmap.Clone();

            //Se procesa la proyeccion Horizontal del Bitmap obtenido. 
            List<Segment> HorizontalSegments = ProcessProjection(outHorizontalProjection, projectionBitOut.Bitmap);
            List<Segment> VerticalSegments = new List<Segment>();

          
            Int64 AverageValue = 0;


            //TODO Si este tiene un solo segmento se entiende que es una linea de subtitulos. 
            //Añadir condicion Range y cambio de Average Threshold
            if (SubtitlesDetected(HorizontalSegments))
            {

                //Este es el ancho de la linea de Subtitulos
                Int64 Range = HorizontalSegments[0].End - HorizontalSegments[0].Starts;
                Ranges[Index] = Range;
                Int64 AverageRange = MathHelper.AverageRange(Ranges);

                VerticalSegments = ProcessProjection(outVerticalProjection, projectionBitOut.Bitmap);
                

                if (VerticalSegments.Count != 0)
                {

                    //Para cada segmento se localizan aqui los vertices. Valores maximos y minimo que contienen informacion en el bitmap
                    for (int i = 0; i < VerticalSegments.Count; i++)
                    {

                        VerticalSegments[i].MaxValue = BuscarMaximo(outMaxColumnValue, VerticalSegments[i].Starts, VerticalSegments[i].End);
                        VerticalSegments[i].MinValue = BuscarMinimo(outMinColumnValue, VerticalSegments[i].Starts, VerticalSegments[i].End, bitmap.Height);

                    }




                    //Se deben agrupar los segmento una vez se han establecido los vertices. De otro modo todos estan inicializados a 0

                    List<Segment> GroupedSegments = GroupSegments(VerticalSegments);

                    AverageValue = MathHelper.AverageValue(outHorizontalProjection);


                    //Antes de pintarrajear el Bitmap hacemos una copia para poder hacer el CROP Limpio
                    Bitmap forCropBitmap = (Bitmap)projectionBitOut.Bitmap.Clone();

                    DrawSegmentsinBitmap(VerticalSegments, BitmapForSegmentInitial, Brushes.DarkRed, this.pictureBox2);
                    DrawSegmentsinBitmap(GroupedSegments, BitmapForGroupedSegments, Brushes.Orange, this.pictureBoxGrouped);


                    CropCaracteres(forCropBitmap, GroupedSegments);
                    textBoxProcessInfo.Text = this.textBoxProcessInfo.Text + VerticalSegments.Count.ToString() + " -> " + GroupedSegments.Count.ToString();

                    textBoxHorizontalInfo.Text = " R : " + Range.ToString() + " Av : " + AverageValue.ToString() + " Media Av " + AverageRange.ToString();
                }

                else textBoxProcessInfo.Text = "Line Detected without Vertical Segments";
            } //Fin Subtitles Detected


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            Char [] ch = textBox3.Text.ToCharArray();

            if (ch.Length != 0) CaracterToDetect = ch[0];

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
