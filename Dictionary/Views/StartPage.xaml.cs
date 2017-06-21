using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Dictionary
{
	public partial class StartPage : ContentPage
	{
		Handler _viewModel;
		public StartPage()
		{
			InitializeComponent();
			this.Stacktoeditor.Padding = new Thickness(5, 10);
			this.BindingContext = _viewModel = new Handler(this);
			this.first.Text = ServiceInformation.Instance._langOne;
			this.second.Text = ServiceInformation.Instance._langTwo;

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				Device.OpenUri(new Uri("https://tech.yandex.ru/dictionary/"));
			};
			this.YandexText.GestureRecognizers.Add(tapGestureRecognizer);
		}

		//protectes void Traslate(object sender)
		//{
			
		//}

		protected void ChangeLanguage(object sender, System.EventArgs e)
		{
			var k = ServiceInformation.Instance._langOne;
			ServiceInformation.Instance.GetLangOne(ServiceInformation.Instance._langTwo);
			ServiceInformation.Instance.GetLangTwo(k);
			this.first.Text = ServiceInformation.Instance._langOne;
			this.second.Text = ServiceInformation.Instance._langTwo;
		}
	}
}
