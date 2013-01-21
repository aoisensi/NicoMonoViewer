using System;
using NicoMonoLibrary;

namespace NicoMonoViewer
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class NicorepoWidgetItemUnknow : Gtk.Bin , INicorepoWidgetItem
	{
		public NicorepoWidgetItemUnknow ()
		{
			this.Build ();
		}

		public void Write(INicorepoItem iitem)
		{
			NicorepoItemUnknow item = (NicorepoItemUnknow)iitem;
			textview1.Buffer.Text = item.Html;
		}
	}
}

