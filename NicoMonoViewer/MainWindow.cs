using System;
using Gtk;

namespace NicoMonoViewer
{
	public partial class MainWindow: Gtk.Window
	{	
		public NicoMonoLibrary.NicoUser user;

		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
			if (user == null) {
				OnLoginActionActivated(null, null);
			}
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
				//ThemesDialog dialog = (ThemesDialog)sender;
			}
		}
	}
}