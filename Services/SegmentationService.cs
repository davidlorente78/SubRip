using Segmentation;
using System;
using System.Collections.Generic;

namespace SubripServices
{
	public static class SegmentationService
    {
        public static List<Segment> GroupSegments(List<Segment> verticalSegments)
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

        private static Segment JoinSegments(Segment segment1, Segment segment2)
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
