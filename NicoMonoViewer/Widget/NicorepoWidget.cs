using System;
using System.Threading;
using NicoMonoLibrary;

namespace NicoMonoViewer
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class NicorepoWidget : Gtk.Bin
	{
		NicoMonoLibrary.Nicorepo nicorepo;
		public NicorepoWidget ()
		{
			this.Build ();
		}
		protected void OnShown (object sender, EventArgs a)
		{
			MainWindow window = (MainWindow)(Gtk.Window)Toplevel;
			NicoMonoLibrary.NicoUser user = window.user;
			nicorepo = new NicoMonoLibrary.Nicorepo(user);
			BeginAsyncWork(Callback);
		}

		void BeginAsyncWork (AsyncCallback callback)
		{
			Action async = AsyncWork;
			async.BeginInvoke(callback, null);
		}

		void AsyncWork()
		{
			nicorepo.GetNextPage();
		}

		INicorepoWidgetItem GetWidget (INicorepoItem item)
		{

			return null;
		}

		void Callback (IAsyncResult r)
		{
			foreach (INicorepoItem item in nicorepo.Items) {
				if (item is NicorepoItemCommunityLiveBroadcast) {
					NicorepoWidgetItemCommunityLiveBroadcast widget = new NicorepoWidgetItemCommunityLiveBroadcast();
					widget.Write(item);
					vboxMain.PackEnd(widget,true,true,100);
				} else if(item is NicorepoItemUnknow){
					NicorepoWidgetItemUnknow widget = new NicorepoWidgetItemUnknow();
					widget.Write(item);
					vboxMain.PackEnd(widget,true,true,100);
				}
			}
		}
	}
}


