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
			MessageDialog md = new MessageDialog(this, DialogFlags.Modal, MessageType.Other, ButtonsType.Ok, user.xml);
			md.Run();
			md.Destroy();
		}
	}
	protected void OnThemeActionActivated (object sender, EventArgs e)
	{
		ThemesDialog dialog = new ThemesDialog();
		dialog.Run();
		dialog.Destroy();
	}


}