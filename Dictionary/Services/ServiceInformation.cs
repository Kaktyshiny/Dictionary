using System;
namespace Dictionary
{
	public class ServiceInformation
	{
		public static ServiceInformation Instance = new ServiceInformation();
		public string _langOne = "Русский";
		public string _langTwo = "Английский";
		public string _myKey = "dict.1.1.20170621T113537Z.381f95b942e985ea.8d5e1e70f78e526a6b43101b5169ff7335b00f31";

		public void GetLangOne(string LangOne)
		{
			_langOne = LangOne;
		}

		public void GetLangTwo(string LangTwo)
		{
			_langTwo = LangTwo;
		}

		public ServiceInformation()
		{
		}
	}
}
