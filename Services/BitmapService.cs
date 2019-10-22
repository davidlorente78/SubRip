using Segmentation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace SubripServices
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

		public static Bitmap ResizeImage(Bitmap segmentCrop, Int32 fontPoints)
		{

			Bitmap animage = new Bitmap(fontPoints, fontPoints);
			using (Graphics gr = Graphics.FromImage(animage))
			{
				gr.SmoothingMode = SmoothingMode.HighQuality;
				gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
				gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
				gr.CompositingQuality = CompositingQuality.HighQuality;
				gr.DrawImage(segmentCrop, new Rectangle(0, 0, fontPoints, fontPoints));
			}
			return animage;
		}

		

		public static Bitmap GenerateCenteredBitmapfromCropped(Bitmap bitmap, int size)
		{
			Bitmap bitmapwhite = new Bitmap(size, size);		
			Graphics graphic = Graphics.FromImage(bitmapwhite);
			Point p = new Point((size - bitmap.Width ) / 2, (size - bitmap.Height) / 2);
			graphic.DrawImage(bitmap, p);
			return bitmapwhite;

		}


	}
}
