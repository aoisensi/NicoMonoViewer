using System;


[System.ComponentModel.ToolboxItem(true)]
public partial class NicorepoMainWidget : Gtk.Bin
{
	public NicorepoMainWidget ()
	{
		this.Build ();
		textview1.Buffer.Text = "a";
	}
	protected void OnShown (object sender, EventArgs a)
	{
		MainWindow window = (MainWindow)(Gtk.Window)Toplevel;
		NicoMonoLibrary.User user = window.user;
		NicoMonoLibrary.Nicorepo nicorepo = new NicoMonoLibrary.Nicorepo(user);
		textview1.Buffer.Text = nicorepo.result;
	}
}


