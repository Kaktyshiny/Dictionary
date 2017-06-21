using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dictionary
{
	public class Handler
	{
		public ICommand GiveTranslate { get; set; }
		private Page _page;
		public string TranslateText { get; set; }
		public string lang = "en-ru";

		
		public Handler(Page page)
		{
			_page = page;
		}


		//public async Task Translate()
		//{
		//	if (ServiceInformation.Instance._langOne == "Русский")
		//	{
		//		lang = "ru-en";
		//	}

		//	var response = await DataServices.GetInstance().post(TranslateText,lang);
		//	var translatetext = JsonConvert.DeserializeObject<APImodel>(response);
		//}
	}
}
