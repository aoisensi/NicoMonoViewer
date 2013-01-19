using System;
using System.Threading;

[System.ComponentModel.ToolboxItem(true)]
public partial class NicorepoMainWidget : Gtk.Bin
{
	NicoMonoLibrary.Nicorepo nicorepo;
	Thread thread;
	public NicorepoMainWidget ()
	{
		this.Build ();
	}
	protected void OnShown (object sender, EventArgs a)
	{
		MainWindow window = (MainWindow)(Gtk.Window)Toplevel;
		NicoMonoLibrary.User user = window.user;
		nicorepo = new NicoMonoLibrary.Nicorepo(user);
		//LoadPage();
		thread = new Thread(new ThreadStart(LoadPage));
		thread.Start();
	}

	void LoadPage()
	{
		nicorepo.GetNextPage();
	}
}


