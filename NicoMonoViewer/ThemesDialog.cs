using System;
using System.IO;

namespace NicoMonoViewer
{
	public partial class ThemesDialog : Gtk.Dialog
	{
		String themesDir;
		public ThemesDialog ()
		{
			this.Build ();
			//get theme list
			comboboxTheme.AppendText("デフォルト");
			themesDir = Gtk.Rc.ThemeDir;
			foreach (string themeDir in Directory.GetDirectories(themesDir,"*",SearchOption.TopDirectoryOnly))
			{
				comboboxTheme.AppendText(System.IO.Path.GetFileName(themeDir));
			}
			comboboxTheme.Active = 0;
		}
		public string selectedThemePath {
			get {
				return System.IO.Path.Combine(themesDir, comboboxTheme.ActiveText);
			}
		}
	}
}
