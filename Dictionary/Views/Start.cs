using System;

using Xamarin.Forms;

namespace Dictionary
{
	public class Start : TabbedPage
	{
		public Start()
		{
			var first = new Sasha();
			first.Title = "Sasha";
			var second = new Translate();
			second.Title = "Переводчик";
			Children.Add(first);
			Children.Add(second);
		}
	}
}

