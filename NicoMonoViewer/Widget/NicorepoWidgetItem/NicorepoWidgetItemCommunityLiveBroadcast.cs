using System;
using NicoMonoLibrary;
using System.Net;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace NicoMonoViewer
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class NicorepoWidgetItemCommunityLiveBroadcast : Gtk.Bin , INicorepoWidgetItem
	{

		public NicorepoWidgetItemCommunityLiveBroadcast ()
		{
			this.Build ();

		}

		public void Write (INicorepoItem iitem)
		{
			NicorepoItemCommunityLiveBroadcast item = (NicorepoItemCommunityLiveBroadcast)iitem;
			labelUser.Text = item.UserName;
			labelTitle.Text = item.BroadcastTitle;
			labelCommunity.Text = item.CommunityName;
			nicorepowidgetitemsublongago.Write(item.Longago);
			nicorepowidgetitemsubnicoru.Write(item.Nicoru);
			nicorepowidgetitemsubicon48.Write(item.CommunityThumbnailURL);
		}
	}
}
