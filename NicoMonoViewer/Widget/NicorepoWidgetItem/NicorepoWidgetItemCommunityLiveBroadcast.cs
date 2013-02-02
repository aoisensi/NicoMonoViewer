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
		BackgroundWorker gw;
		Gdk.PixbufLoader pixbuf;

		public NicorepoWidgetItemCommunityLiveBroadcast ()
		{
			this.Build ();
			gw = new BackgroundWorker();
			gw.DoWork += HandleDoWork;
			gw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e) {
				Gtk.Application.Invoke(delegate(object isender, EventArgs ie) {
					imageIcon.Pixbuf = pixbuf.Pixbuf;
				});
			};

		}

		void HandleDoWork (object sender, DoWorkEventArgs e)
		{
			NicorepoItemCommunityLiveBroadcast item = (NicorepoItemCommunityLiveBroadcast)e.Argument;
			Stream st;
			try {
				WebRequest req = WebRequest.Create (item.CommunityThumbnailURL);
				WebResponse res = req.GetResponse ();
				
				st = res.GetResponseStream ();
				
			} catch (WebException ex) {
				if(ex.Status == WebExceptionStatus.ProtocolError){
					Assembly asm = Assembly.GetExecutingAssembly();
					st = asm.GetManifestResourceStream("NicoMonoViewer.noimage.jpg");
				}else{
					throw ex;
				}
			}
			pixbuf = new Gdk.PixbufLoader (st, 48, 48);

		}

		public void Write (INicorepoItem iitem)
		{
			NicorepoItemCommunityLiveBroadcast item = (NicorepoItemCommunityLiveBroadcast)iitem;
			gw.RunWorkerAsync(item);
			labelUser.Text = item.UserName;
			labelTitle.Text = item.BroadcastTitle;
			labelCommunity.Text = item.CommunityName;
			nicorepowidgetitemsublongago.Write(item.Longago);
			nicorepowidgetitemsubnicoru.Write(item.Nicoru);

		}
	}
}
