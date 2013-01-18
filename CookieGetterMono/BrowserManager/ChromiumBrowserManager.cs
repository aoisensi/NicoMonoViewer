using System;
using System.Collections.Generic;
using System.Text;

namespace CookieGetterMono
{
	class ChromiumBrowserManager : IBrowserManager
	{

		string GetCookiePath ()
		{
			switch (Environment.OSVersion.Platform) {
			case PlatformID.Win32Windows:
				return "%LOCALAPPDATA%\\Chromium\\User Data\\Default\\Cookies";
			case PlatformID.Unix:
				return "%APPDATA%/chromium/Default/Cookies";
			default:
				throw new Exception("対応してないよ");
			}
		}

		#region IBrowserManager メンバ

		public BrowserType BrowserType
		{
			get { return BrowserType.Chromium; }
		}

		public ICookieGetter CreateDefaultCookieGetter()
		{
			string path = Utility.ReplacePathSymbols(GetCookiePath());

			if (!System.IO.File.Exists(path)) {
				path = null;
			}

			CookieStatus status = new CookieStatus(this.BrowserType.ToString(), path, this.BrowserType, PathType.File);
			return new GoogleChrome3CookieGetter(status);
		}

		public ICookieGetter[] CreateCookieGetters()
		{
			return new ICookieGetter[] { CreateDefaultCookieGetter() };
		}

		public bool IsAbleOS()
		{
			PlatformID p = Environment.OSVersion.Platform;
			return p == PlatformID.Unix || p == PlatformID.Win32Windows;
		}

		#endregion
	}
}
