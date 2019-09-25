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

	

	}
}
