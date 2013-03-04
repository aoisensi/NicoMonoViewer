using System;
using Gtk;
using System.ComponentModel;

namespace Test
{
	class MainClass{
		public static void Main (string[] args)	
		{
			var t = typeof(NicoMonoLibrary.Json.NicoruResponse);
			Console.WriteLine(t.ToString());
		}
	}
}
