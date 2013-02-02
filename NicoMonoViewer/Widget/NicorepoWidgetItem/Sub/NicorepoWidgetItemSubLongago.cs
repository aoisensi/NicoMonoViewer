using System;

namespace NicoMonoViewer
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class NicorepoWidgetItemSubLongago : Gtk.Bin
	{
		public NicorepoWidgetItemSubLongago ()
		{
			this.Build ();
		}

		public void Write (DateTime datetime)
		{
			TimeSpan span = DateTime.Now - datetime;
			if ((int)span.TotalDays > 0) {
				label.Text = String.Format ("{0}日前", (int)span.TotalDays);
			} else if ((int)span.TotalHours > 0) {
				label.Text = String.Format ("{0}時間前", (int)span.TotalHours);
			} else if ((int)span.TotalMinutes > 0) {
				label.Text = String.Format ("{0}分前", (int)span.TotalMinutes);
			} else if ((int)span.TotalSeconds > 0) {
				label.Text = String.Format ("{0}秒前", (int)span.TotalSeconds);
			} else {
				label.Text = "たった今";
			}
			TooltipText = datetime.ToString();
		}
	}
}

