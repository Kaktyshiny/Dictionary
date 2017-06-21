using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Dictionary
{
	public partial class Translate : ContentPage
	{
		Label LabelOne = new Label();
		Label LabelThree = new Label();
		StackLayout TranslatedText = new StackLayout();
		Entry EntryOne = new Entry
		{
			TextColor = Color.Black,
		};

		public string lang = "en-ru";

		public Translate()
		{
			InitializeComponent();
			this.BindingContext = new Handler(this);

			Grid grid = new Grid
			{
				RowDefinitions =
					{
						new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					},
				ColumnDefinitions =
					{
						new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
						new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
						new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
					}
			};

			LabelOne.Text = "Русский";
			LabelOne.TextColor = Color.Black;
			LabelOne.FontSize = 20;

			//Label LabelTwo = new Label();
			//LabelTwo.Text = "⇔";
			//LabelTwo.HorizontalOptions = LayoutOptions.Center;
			//LabelTwo.TextColor = Color.Black;
			//LabelTwo.FontSize = 25;

			Button ButtonTwo = new Button
			{
				Text = "⇔",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
				TextColor = Color.Black,
				BorderWidth = 0,
				BackgroundColor = Color.White,
			};
			ButtonTwo.Clicked += ChangeLanguage;

			LabelThree.Text = "Английский";
			LabelThree.TextColor = Color.Black;
			LabelThree.FontSize = 20;
			LabelThree.HorizontalOptions = LayoutOptions.End;

			grid.Children.Add(LabelOne, 0, 0);
			grid.Children.Add(ButtonTwo, 1, 0);
			grid.Children.Add(LabelThree, 2, 0);


			Button ButtonTranslate = new Button
			{
				BackgroundColor = Color.FromHex("#FFCC00"),
				Text = "Перевести",
				TextColor = Color.Black,
			};
			ButtonTranslate.Clicked += TranslateText;


			this.Content = new StackLayout
			{
				Children =
				{
					grid,
					EntryOne,
					ButtonTranslate,
					TranslatedText,
				}
			};
		}

		protected void ChangeLanguage(object sender, System.EventArgs e)
		{
			var k = ServiceInformation.Instance._langOne;
			ServiceInformation.Instance.GetLangOne(ServiceInformation.Instance._langTwo);
			ServiceInformation.Instance.GetLangTwo(k);
			LabelOne.Text = ServiceInformation.Instance._langOne;
			LabelThree.Text = ServiceInformation.Instance._langTwo;
		}

		protected async void TranslateText(object sender, System.EventArgs e)
		{
			if (ServiceInformation.Instance._langOne == "Русский")
			{
				lang = "ru-en";
			}

			var i = 1;
			var response = await DataServices.GetInstance().post(EntryOne.Text, lang);
			var translatetext = JsonConvert.DeserializeObject<APImodel>(response);

			TranslatedText.Children.Add(new Label { Text = translatetext.def[0].text, TextColor = Color.Black, });
			TranslatedText.Children.Add(new Label { Text = "[" +translatetext.def[0].ts + "]", TextColor = Color.Gray, });

			foreach (var def in translatetext.def)
			{
				
				foreach (var tr in def.tr)
				{
					if (tr.pos == "noun")
					{
						TranslatedText.Children.Add(new Label { Text = "Существительное" });
					}
					if (tr.pos == "adjective")
					{
						TranslatedText.Children.Add(new Label { Text = "Прилагательное" });
					}
					if (tr.pos == "verb")
					{
						TranslatedText.Children.Add(new Label { Text = "Глагол" });
					}
					var trtext = i + tr.text + " (" + tr.gen + ")";

					if (tr.syn != null)
					{

						foreach (var syn in tr.syn)
						{
							trtext += ", " + syn.text + " (" + syn.gen + ")";
						}

					}
					TranslatedText.Children.Add(new Label { Text =  trtext });



					if (tr.mean != null)
					{
						var meantext = "";
						var k = 0;
						foreach (var mean in tr.mean)
						{
							if (k != 0) meantext += ", ";
							meantext += mean.text;
							k = 1;
						}
						TranslatedText.Children.Add(new Label { Text = "(" + meantext + ")" });
					}


					if (tr.ex != null)
					{
						foreach (var ex in tr.ex)
						{
							TranslatedText.Children.Add(new Label { Text = ex.text + " - " + ex.tr[0].text, TextColor = Color.Gray, });
						}
					}

					i++;
				}
				//TranslatedText.Children.Add(new Label { Text =  });
			}
			                            
		}
	}
}
