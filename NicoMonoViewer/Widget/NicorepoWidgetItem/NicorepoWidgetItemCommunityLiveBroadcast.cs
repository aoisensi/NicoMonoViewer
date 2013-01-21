using System;
using NicoMonoLibrary;

namespace NicoMonoViewer
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class NicorepoWidgetItemCommunityLiveBroadcast : Gtk.Bin , INicorepoWidgetItem
	{
		public NicorepoWidgetItemCommunityLiveBroadcast ()
		{
			this.Build ();
		}

		public void Write(INicorepoItem iitem)
		{
			NicorepoItemCommunityLiveBroadcast item = (NicorepoItemCommunityLiveBroadcast)iitem;
			labelUser.Text = item.UserName;
			labelTitle.Text = item.BroadcastTitle;
			labelCommunity.Text = item.CommunityName;
		}
	}
}

