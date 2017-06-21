using System;
using System.Collections.Generic;

namespace Dictionary
{
	public class APImodel
	{
		public object head { get; set; }
		public List<defclass> def { get; set; }
	}

	public class defclass
	{
		public string text { get; set; }
		public string pos { get; set; } //часть речи - noun
		public string ts { get; set; } //транскрипция - kat
		public List<trclass> tr { get; set; }
	}

	public class trclass
	{
		public string text { get; set; } // кошка
		public string pos { get; set; } //noun
		public string gen { get; set; } //  ж
		public List<synclass> syn { get; set; }
		public List<meanclass> mean { get; set; }
		public List<exclass> ex { get; set; }

	}

	public class synclass
	{
		public string text { get; set; }
		public string pos { get; set; }
		public string gen { get; set; }
	}

	public class meanclass
	{
		public string text { get; set; }
	}

	public class exclass
	{
		public string text { get; set; }
		public List<trclasstwo> tr { get; set; }
	}

	public class trclasstwo
	{
		public string text { get; set; }
	}
}
