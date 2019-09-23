using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subrip
{
    public class Segment
    {
        private int order;
        private Int64 starts;
        private Int64 end;
        private Int64 maxValue;
        private Int64 minValue;
        private double ratio;

        private bool Avalaible = true;
    
        public Int64 Starts {  get 
        {
           return starts; 
        }
        set 
        {
           starts = value; 
        }}

        public Int64 End {  get 
        {
           return end; 
        }
        set 
        {
           end = value; 
        }}

        public Int64 MaxValue {  get 
        {
           return maxValue; 
        }
        set 
        {
           maxValue = value; 
        }}

        public Int64 MinValue {  get 
        {
           return minValue ; 
        }
        set 
        {
           minValue = value; 
        }}

        public double Ratio
        {
            get
            {
                return this.CalculateRatio () ;
            }
            set
            {
                ratio = value;
            }
        }        

        public double CalculateRatio()
        {
            double bas = this.end - this.starts;
            double altura = this.maxValue - this.minValue;
            ratio = bas / altura;

            return ratio;
        }

		public double CalculateRatiowithNextSegmentJoined(Segment End) {

			Segment JoinedSegment = new Segment();
			JoinedSegment.End = End.End;
			JoinedSegment.Starts = this.Starts;

			if (this.MinValue < End.minValue)
			{
				JoinedSegment.MinValue = this.MinValue;
			}
			else
			{
				JoinedSegment.MinValue = End.MinValue;
			}

			if (this.MaxValue > End.maxValue)
			{
				JoinedSegment.MaxValue = this.MaxValue;
			}
			else
			{
				JoinedSegment.MaxValue = End.MaxValue;
			}

            return JoinedSegment.CalculateRatio ();
        }

		public  List<Segment> GroupSegments(List<Segment> verticalSegments)
		{
			List<Segment> GroupedSegments = new List<Segment>();

			double ThresholdRatio = 1 - Convert.ToDouble(0.78m);
			string Ratios = "";

			for (Int32 x = 0; x < verticalSegments.Count - 1; x++)
			{
				Ratios = Ratios + "[" + x.ToString() + "," + verticalSegments[x].CalculateRatio() + " ] ";
			}
				

			for (Int32 x = 0; x < verticalSegments.Count; x++)
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

	}
}
