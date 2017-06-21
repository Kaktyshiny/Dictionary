using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Dictionary
{
	class DataServices
	{
		private static readonly DataServices _dataService = new DataServices();
		private HttpClient _client = new HttpClient();
		private readonly HttpClient _httpClient = new HttpClient
		{
			DefaultRequestHeaders = { IfModifiedSince = DateTimeOffset.Now }
		};

		private readonly string _baseUrl = "https://dictionary.yandex.net/api/v1/dicservice.json";
		public static DataServices GetInstance()
		{
			return _dataService;
		}
		private async Task<string> PostAsync(string script, string json)
		{
			try
			{
				var response = await _client.PostAsync($"{_baseUrl}/{script}", new StringContent(json, Encoding.UTF8, "application/json"));

				// Если нужно отправить как содержимое формы 
				//var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("data", json) }); 
				//var response = await _client.PostAsync($"{_baseUrl}/{script}", content); 

				return await response.Content.ReadAsStringAsync();
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}

		public async Task<string> post(string text, string lang)
		{
			var json = new JObject { };
			return await PostAsync("/lookup?key=" + ServiceInformation.Instance._myKey + "&text=" + text + "&lang=" + lang, json.ToString());
		}
	}
}
