using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SubripServices
{
	public static class PredictionService
	{
		/// <summary>
		/// Will return "我在这里" as a discovery service
		/// </summary>
		/// <returns></returns>
		public static char Index()
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44333/");
				//HTTP GET
				var responseTask = client.GetAsync("Index");
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{

					var readTask = result.Content.ReadAsStringAsync();
					readTask.Wait();

					var predicted = readTask.Result;
					return predicted.ToCharArray()[0];

				}
			}

			return ' ';




		}

		public static char Predict(string data)
		{
			data = data.Replace(",","");
			data = data.Replace(" ", "");


			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44333/");
				
				//HTTP GET
				var responseTask = client.GetAsync("Predict?data=" + data);
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{

					var readTask = result.Content.ReadAsStringAsync();
					readTask.Wait();

					var predicted = readTask.Result;
					return predicted.ToCharArray()[0];

				}
			}

			return ' ';




		}
	}
}

