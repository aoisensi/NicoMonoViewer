using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	NicoMonoLibrary.User user = null;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnQuitActionActivated (object sender, EventArgs e)
	{
		Application.Quit();
	}

	protected void OnLoginActionActivated (object sender, EventArgs e)
	{
		LoginDialog dialog = new LoginDialog();
		dialog.Response += new ResponseHandler(GetLoginDialogResponse);
		dialog.Run();
		dialog.Destroy();
	}

	protected void GetLoginDialogResponse (object sender, ResponseArgs args)
	{

		if (args.ResponseId == ResponseType.Ok) {
			LoginDialog dialog = (LoginDialog)sender;
			user = dialog.GetUserData();
			this.textview1.Buffer.Text = user.cc.ToString();
		}
	}
	protected void OnThemeActionActivated (object sender, EventArgs e)
	{
		ThemesDialog dialog = new ThemesDialog();
		dialog.Response += new ResponseHandler(GetThemeDialogResponse);
		dialog.Run();
		dialog.Destroy();
	}


	void GetThemeDialogResponse (object sender, ResponseArgs args)
	{
		if (args.ResponseId == ResponseType.Ok) {
			ThemesDialog dialog = (ThemesDialog)sender;
			Gtk.Rc.Parse(dialog.selectedThemePath);
		}
	}
}