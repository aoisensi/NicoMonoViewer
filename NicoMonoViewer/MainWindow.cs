using System;
using Gtk;
using NicoMonoLibrary;
using CookieGetterMono;
using System.Net;

namespace NicoMonoViewer
{
	public partial class MainWindow: Gtk.Window
	{	
		NicoUser _user;
		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
			ICookieGetter cg = CookieGetter.CreateInstance(BrowserType.Chromium);
			Cookie cookie = cg.GetCookie(new Uri("http://live.nicovideo.jp/"),"user_session");
			_user = new NicoUser(cookie);
			Build ();
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
		protected void OnCloseActionActivated (object sender, EventArgs e)
		{
			Application.Quit ();
		}

		public NicoUser user {
			get {
				return _user;
			}
		}
	}
}