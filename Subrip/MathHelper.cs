using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subrip
{
	public static class MathHelper
	{
		public static double[] Correlation(Int32 Maxk, Int64[] Projection1, Int64[] Projection2)
		{
			Int64 C = 0;
			double[] Correlacion = new double[Maxk];

			Int64 FC1 = 0;
			Int64 FC2 = 0;
			double FC = 0;

			//Maxk define el maximo desplazamiento permitido entre las dos projecciones. 
			for (int k = 0; k < Maxk; k++)
			{
				C = 0;
				FC1 = 0;
				FC2 = 0;
				FC = 0;

				for (int x = 0; x < Projection1.Length; x++)
				{
					if ((x + k) < Projection1.Length)
					{
						C = C + (Projection1[x] * Projection2[x + k]);
					}

					FC1 = FC1 + Projection1[x] * Projection1[x];
					FC2 = FC2 + Projection2[x] * Projection2[x];

				}
				C = C / Projection1.Length;

				FC = (Math.Sqrt(Convert.ToDouble(FC1 * FC2))) / Projection1.Length;

				Correlacion[k] = C / FC;
			}

			return Correlacion;

		}

		public  static double BuscarMaximoCorrelation(double[] Correlation)
		{
			double Max = 0;

			for (int x = 0; x < Correlation.Length; x++)
			{

				if (Correlation[x] > Max)
				{
					Max = Correlation[x];
				}
			}

			return Max;
		}
				
		public static Int64 Average(Int64[] sequence)
		{
			Int64 average = 0;
			Int64 Sum = 0;
			for (int x = 0; x < sequence.Length; x++)
			{
				Sum = Sum + sequence[x];
			}

			average = Convert.ToInt64(Sum / sequence.Length);

			return average;
		}

	}
}
