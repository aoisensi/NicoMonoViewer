using System;
using NicoMonoLibrary;
using System.ComponentModel;
using System.Reflection;
using System.IO;
using Gdk;

namespace NicoMonoViewer
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class NicorepoWidgetItemSubNicoru : Gtk.Bin
	{
		Nicoru _nicoru;
		Pixbuf buf;
		Pixbuf[] icon;
		bool canClick;
		public NicorepoWidgetItemSubNicoru ()
		{
			this.Build ();
			Assembly asm = Assembly.GetExecutingAssembly();
			Stream st = asm.GetManifestResourceStream("NicoMonoViewer.nicoru_icon.png");
			buf = new PixbufLoader(st).Pixbuf;
			st.Close();
			icon = new Pixbuf[5];
			for(int i=0;i<5;++i){
				icon[i] = new Pixbuf(buf,i*20,0,20,20);
			}
			image.Pixbuf = icon[1];
		}
		int nicorare;
		public void Write(Nicoru nicoru){
			_nicoru = nicoru;
			BackgroundWorker bw = new BackgroundWorker();
			bw.DoWork += delegate(object sender, DoWorkEventArgs e) {
				nicorare = nicoru.Nicorare(((MainWindow)Toplevel).user).Result.Items[0].Count;
			};
			bw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e) {
				Gtk.Application.Invoke(delegate(object dsender, EventArgs de) {
					label.Text = nicorare.ToString();
					image.Pixbuf = icon[0];
					button.EnterNotifyEvent += HandleEnterNotifyEvent;
					button.LeaveNotifyEvent += HandleLeaveNotifyEvent;
					canClick = true;
				});
			};
			bw.RunWorkerAsync();
		}

		void HandleEnterNotifyEvent (object o, Gtk.EnterNotifyEventArgs args)
		{
			if (image.Pixbuf.Equals (icon [0]) || image.Pixbuf.Equals(icon[4])) {
				label.Text = "ニコる!";
			}else{
				label.Text = "ニコった!";
			}
		}

		void HandleLeaveNotifyEvent (object o, Gtk.LeaveNotifyEventArgs args)
		{
			if(image.Pixbuf.Equals(icon[4])){
				label.Text = "失敗!";
			}else{
				label.Text = nicorare.ToString();
			}
		}

		protected void OnButtonClicked (object sender, EventArgs e)
		{
			if (canClick) {
				BackgroundWorker bw = new BackgroundWorker ();
				bw.DoWork += delegate(object dsender, DoWorkEventArgs de) {
					_nicoru.DoNicoru (((MainWindow)Toplevel).user);
				};
				bw.RunWorkerCompleted += delegate(object dsender, RunWorkerCompletedEventArgs de) {
					Gtk.Application.Invoke (delegate(object isender, EventArgs ie) {
						if (de.Error == null) {
							image.Pixbuf = icon [3];
						} else {
							Console.WriteLine(de.Error.InnerException.Message);
							image.Pixbuf = icon [4];
							canClick = true;
						}
					});
				};
				bw.RunWorkerAsync();
				image.Pixbuf = icon [2];
				canClick = false;
			}
		}
	}
}

