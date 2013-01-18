using System;
using System.Net;
using CookieGetterMono;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("the cake is a lie");
		ICookieGetter cg = CookieGetter.CreateInstance(BrowserType.Chromium);
		CookieCollection collection = cg.GetCookieCollection(new Uri("http://live.nicovideo.jp/"));
		Cookie cookie = collection["user_session"];

	}
}

