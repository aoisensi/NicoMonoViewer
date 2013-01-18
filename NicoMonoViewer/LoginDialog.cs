using System;

public partial class LoginDialog : Gtk.Dialog
{
	public LoginDialog ()
	{
		this.Build ();
	}

	public NicoMonoLibrary.User GetUserData()
	{
		return new NicoMonoLibrary.User (this.entryMail.Text, this.entryPass.Text);
	}

}


