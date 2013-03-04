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

		public virtual void Write (INicorepoItem iitem)
		{
			NicorepoItemCommunityLiveBroadcast item = (NicorepoItemCommunityLiveBroadcast)iitem;
			labelUser.Text = item.UserName;
			labelTitle.Text = item.BroadcastTitle;
			labelCommunity.Text = item.CommunityName;
			nicorepowidgetitemsublongago.Write(item.Longago);
			nicorepowidgetitemsubnicoru.Write(item.Nicoru);
			//nicorepowidgetitemsubicon48.Write(item.CommunityThumbnailURL);
		}

		protected Gtk.Label TitleLabel{
			get{
				return GtkLabel;
			}
		}

		protected Gtk.HBox HBoxMain{
			get{
				return hboxMain;
			}
		}

		protected Gtk.Label LabelSan{
			get{
				return labelSan;
			}
		}
	}
}
