using System;
using NicoMonoLibrary;
using System.ComponentModel;

namespace NicoMonoViewer
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class NicorepoWidget : Gtk.Bin
	{
		NicoMonoLibrary.Nicorepo nicorepo;
		BackgroundWorker bw;
		public NicorepoWidget ()
		{
			this.Build ();
		}

		protected void OnShown (object sender, EventArgs a)
		{
			MainWindow window = (MainWindow)(Gtk.Window)Toplevel;
			NicoMonoLibrary.NicoUser user = window.user;
			nicorepo = new NicoMonoLibrary.Nicorepo(user);
			bw = new BackgroundWorker();
			bw.DoWork += HandleDoWork;
			bw.RunWorkerCompleted += HandleRunWorkerCompleted;
			bw.RunWorkerAsync();
		}

		void HandleDoWork (object sender, DoWorkEventArgs e)
		{
			nicorepo.GetNextPage();
		}

		void HandleRunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error == null) {
				Gtk.Application.Invoke (
			delegate(object dsender, EventArgs de) {
					foreach (INicorepoItem item in nicorepo.Items) {
						if (item is NicorepoItemCommunityLiveBroadcast) {
							NicorepoWidgetItemCommunityLiveBroadcast widget = new NicorepoWidgetItemCommunityLiveBroadcast ();
							vboxMain.PackStart (widget);
							widget.Write (item);
							widget.Show ();
						} else if (item is NicorepoItemUnknow) {
							//continue;
							NicorepoWidgetItemUnknow widget = new NicorepoWidgetItemUnknow();
							widget.Write(item);
							vboxMain.PackStart(widget);
							widget.Show();
						}
					}
					button.Sensitive = true;
					button.Label = "更に読み込む";
				});
			} else {
				Console.WriteLine(e.Error.Message);
				Console.WriteLine(e.Error.Source);
			}
		}

		protected void OnButtonClicked (object sender, EventArgs e)
		{
			button.Sensitive = false;
			button.Label = "ロード中...";
			bw.RunWorkerAsync();
		}
	}
}

