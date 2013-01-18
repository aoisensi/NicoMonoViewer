using System;


[System.ComponentModel.ToolboxItem(true)]
public partial class NicorepoMainWidget : Gtk.Bin
{
	public NicorepoMainWidget (NicoMonoLibrary.User user)
	{
		this.Build ();
		NicoMonoLibrary.Nicorepo nicorepo = new NicoMonoLibrary.Nicorepo(user);
		textview1.Buffer.Text = nicorepo.result;
	}
}


