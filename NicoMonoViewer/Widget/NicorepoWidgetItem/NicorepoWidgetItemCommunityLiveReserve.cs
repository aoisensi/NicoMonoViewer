using System;
using NicoMonoLibrary;

namespace NicoMonoViewer
{
	public class NicorepoWidgetItemCommunityLiveReserve : NicorepoWidgetItemCommunityLiveBroadcast
	{
		Gtk.Label labelTime;
		Gtk.Label labelNi;
		public NicorepoWidgetItemCommunityLiveReserve () : base()
		{
			LabelSan.Text = "さんが";                                                     

			TitleLabel.LabelProp = "<b>コミュニティ放送予約通知</b>";

			labelNi = new Gtk.Label("に 生放送を予約しました。");
			HBoxMain.PackEnd(labelNi);
			labelNi.Show();

			labelTime = new Gtk.Label("嘘!ケーキ");
			HBoxMain.PackEnd(labelTime);
			labelTime.Show();
		}

		public override void Write(INicorepoItem iitem){
			base.Write(iitem);
			var item = (NicorepoItemCommunityLiveReserve)iitem;
			labelTime.Text = item.BroadcastTime.ToString("yy年MM月dd日 HH:mm");
		}
	}
}

