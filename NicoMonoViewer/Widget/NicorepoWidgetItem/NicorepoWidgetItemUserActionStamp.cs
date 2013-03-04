using System;
using NicoMonoLibrary;

namespace NicoMonoViewer
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class NicorepoWidgetItemUserActionStamp : Gtk.Bin , INicorepoWidgetItem
	{
		public NicorepoWidgetItemUserActionStamp ()
		{
			this.Build ();
		}

		public virtual void Write (INicorepoItem iitem)
		{
			NicorepoItemUserActionStamp item = (NicorepoItemUserActionStamp)iitem;
			labelUser.Text = item.UserName;
			labelStamp.Text = item.StampName;
			nicorepowidgetitemsublongago.Write(item.Longago);
			nicorepowidgetitemsubnicoru.Write(item.Nicoru);
			//nicorepowidgetitemsubicon48.Write(item.StampImageURL);
		}
	}
}

