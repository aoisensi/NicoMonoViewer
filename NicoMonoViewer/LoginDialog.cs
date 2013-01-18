using System;
using CookieGetterMono;
using System.Net;

public partial class LoginDialog : Gtk.Dialog
{
	ICookieGetter[] cgs = CookieGetter.CreateInstances (true);

	public LoginDialog ()
	{
		this.Build ();
		comboboxBrowser.Sensitive = radiobuttonBrowser.Active;
		table.Sensitive = radiobuttonLogin.Active;
		LoadBrowserList();
	}

	public NicoMonoLibrary.User GetUserData ()
	{
		if (radiobuttonBrowser.Active) {
			ICookieGetter cg = cgs[comboboxBrowser.Active];
			CookieCollection collection = cg.GetCookieCollection(new Uri("http://live.nicovideo.jp/"));
			Cookie cookie = collection["user_session"];
			return new NicoMonoLibrary.User (cookie);
		} else {
			return new NicoMonoLibrary.User (this.entryMail.Text, this.entryPass.Text);
		}
	}
	
	protected void OnRadiobuttonBrowserToggled (object sender, EventArgs e)
	{
		comboboxBrowser.Sensitive = radiobuttonBrowser.Active;
	}

	protected void OnRadiobuttonLoginToggled (object sender, EventArgs e)
	{
		table.Sensitive = radiobuttonLogin.Active;
	}
	
	void LoadBrowserList ()
	{
		if (cgs.Length == 0) {
			comboboxBrowser.AppendText("対応ブラウザがありません");
			radiobuttonLogin.Active = true;
			radiobuttonBrowser.Sensitive = false;
			return;
		}
		foreach(ICookieGetter cg in cgs)
		{
			comboboxBrowser.AppendText(cg.Status.Name);
		}
		comboboxBrowser.Active = 0;
	}
}


