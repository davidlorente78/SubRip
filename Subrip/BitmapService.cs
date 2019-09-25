using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subrip
{
	public static class BitmapService
	{
		public static Bitmap BitmapFromScreen(int sizex, int sizey,int left, int top)
		{
			Rectangle region = Screen.AllScreens[0].Bounds;
			Bitmap bitmap = new Bitmap(sizex,sizey, PixelFormat.Format64bppArgb);

			Graphics graphic = Graphics.FromImage(bitmap);
			Size s = new Size(sizex, sizey);

			graphic.CopyFromScreen(left, top, 0, 0, s);
			PixelFormat px = bitmap.PixelFormat;

			return bitmap;
		}

		public static Bitmap DrawSegmentsinBitmap(List<Segment> Segments, Bitmap bitmap, Brush color)
		{
			Pen pen = new Pen(color);
			Graphics graphic = Graphics.FromImage(bitmap);
			foreach (Segment s in Segments)
			{
				Point p = new Point(Convert.ToInt32(s.Starts), Convert.ToInt32(s.MinValue));
				Size size = new Size(Convert.ToInt32(s.End - s.Starts), Convert.ToInt32(Convert.ToInt32(s.MaxValue - s.MinValue)));
				Rectangle rec = new Rectangle(p, size);
				graphic.DrawRectangle(pen, rec);
			}

			return bitmap;
		}

		public static List<Bitmap> ExtractCropBitmaps(List<Segment> Segments, Bitmap bitmap)
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


	}
}
