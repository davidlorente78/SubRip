using Segmentation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Subrip
{
	public static class ProjectionService
	{
		public static Projection GenerateProjectionfromFontChar(Char c, Size size, Int32 fontPoints)
		{
			var MaxSize = Math.Max(size.Width, size.Height);
			Bitmap bitmapchar = new Bitmap(Math.Max(size.Width, size.Height), Math.Max(size.Width, size.Height));
			Graphics graphic = Graphics.FromImage(bitmapchar);

			Font f = new Font("DengXian", fontPoints, FontStyle.Regular, GraphicsUnit.World);
			Brush b = Brushes.Black;
			Brush brushwhite = Brushes.White;
			Point p = new Point(0, 0);

			Rectangle rec = new Rectangle(0, 0, Math.Max(size.Width, size.Height), Math.Max(size.Width, size.Height));
			Region reg = new Region(rec);

			graphic.FillRegion(brushwhite, reg);
			graphic.DrawString(c.ToString(), f, b, p);
			Projection projection = ProjectBitmap(bitmapchar);
			return projection;

		}

		private static Projection ProjectBitmap(Bitmap bitmap)
		{
			Int64[] VerticalProjection = new Int64[bitmap.Width];
			Int64[] HorizontalProjection = new Int64[bitmap.Height];

			int R = Color.Black.R;
			int V = Color.Black.G;
			int A = Color.Black.B;

			Color colorIn;

			for (Int32 x = 0; x < bitmap.Width; x++)
			{
				for (Int32 y = 0; y < bitmap.Height; y++)
				{
					colorIn = bitmap.GetPixel(x, y);

					if ((((R == colorIn.R) && (colorIn.G == V) && (A == colorIn.B))))
					{
						VerticalProjection[x] = VerticalProjection[x] + 1;
						HorizontalProjection[y] = HorizontalProjection[y] + 1;
					}
				}
			}

			return new Projection { HorizontalProjection = HorizontalProjection, VerticalProjection = VerticalProjection, Bitmap = bitmap };
		}

		public static Projection ProjectandFilter(Color Color, Int32 Margin, Bitmap bitmap)
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
		
		//Localiza los pasos por cero de la projeccion y retorna los inicios y finales de los segmentos localizados
		//Atencion : Aqui no se determina el valor Maximo y Minimo
		public static List<Segment> ToSegments(Int64[] axisProjection, long bitmapheight)
		{
			List<Segment> Segments = new List<Segment>();

			bool SegmentBegins = true;

			Segment s = new Segment();

			for (int x = 0; x < axisProjection.Length; x++)
			{
				//Si no es el primer valor
				if (x > 0)
				{
					if (((axisProjection[x] == 0) && (axisProjection[x - 1] != 0)) || ((axisProjection[x] != 0) && (axisProjection[x - 1] == 0)))
					{
						if (SegmentBegins)
						{
							s.Starts = x;
							SegmentBegins = false; //Se va alternando el valor de la variable para saber si el cambio es debido a un inicio o a un final
						}
						else
						{
							s.End = x - 1;
							SegmentBegins = true;

							//Inicializa Max y Min del Segmento
							s.MaxValue = 0;
							s.MinValue = bitmapheight;

							Segment Add = new Segment() { Starts = s.Starts, End = s.End };
							Segments.Add(Add);
						}
					}
				}
			}

			return Segments;
		}


		public static Projection MaxMinEvaluation(int bitmapFromScreenheight, Projection projection)
		{
			Projection projectiontoReturn = projection;
			//Para cada segmento se localizan aqui los vertices. Valores maximos y minimo que contienen informacion en el bitmap
			for (int i = 0; i < projection.VerticalSegments.Count; i++)
			{
				projection.VerticalSegments[i].MaxValue = MaxValue(projection.MaxColumnValue, projection.VerticalSegments[i].Starts, projection.VerticalSegments[i].End);
				projection.VerticalSegments[i].MinValue = MinValue(projection.MinColumnValue, projection.VerticalSegments[i].Starts, projection.VerticalSegments[i].End, bitmapFromScreenheight);
			}

			return projectiontoReturn;
		}

		public static long MinValue(int[] MinColumnValue, long starts, long end, long StartMax)
		{
			long Min = StartMax;

			for (int x = Convert.ToInt32(starts); x < end - 1; x++)
			{

				if (MinColumnValue[x] < Min)
				{
					Min = MinColumnValue[x];
				}
			}

			return Min;
		}

		public static long MaxValue(int[] MaxColumnValue, long starts, long end)
		{
			long Max = 0;

			for (int x = Convert.ToInt32(starts); x < end - 1; x++)
			{

				if (MaxColumnValue[x] > Max)
				{
					Max = MaxColumnValue[x];
				}
			}

			return Convert.ToInt64(Max);
		}
	}
}