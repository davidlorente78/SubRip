using System;
using System.Drawing;
namespace Subrip
{
	public static class Projector
	{
		public static Projection GenerateProjectionfromFontChar(Char c, Size bitmapSize, Int32 fontPoints)
		{
			var MaxSize = Math.Max(bitmapSize.Width, bitmapSize.Height);
			Bitmap bitmapchar = new Bitmap(Math.Max(bitmapSize.Width, bitmapSize.Height), Math.Max(bitmapSize.Width, bitmapSize.Height));
			Graphics graphic = Graphics.FromImage(bitmapchar);

			//Ajustar fuente a SquareSize TODO
			Font f = new Font("DengXian", fontPoints, FontStyle.Regular, GraphicsUnit.World);
			Brush b = Brushes.Black;
			Brush brushwhite = Brushes.White;
			Point p = new Point(0, 0);

			Rectangle rec = new Rectangle(0, 0, Math.Max(bitmapSize.Width, bitmapSize.Height), Math.Max(bitmapSize.Width, bitmapSize.Height));
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
	}

}