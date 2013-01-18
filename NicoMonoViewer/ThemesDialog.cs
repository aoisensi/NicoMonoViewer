using System;
using MonoDevelop.Core;

public partial class ThemesDialog : Gtk.Dialog
{
	public ThemesDialog ()
	{
		this.Build ();
		Load();
	}

	void Load ()
	{
		comboboxTheme.AppendText("デフォルト");
	}
}

