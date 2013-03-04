using System;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Reflection;
using Gdk;

namespace NicoMonoViewer
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class NicorepoWidgetItemSubIcon : Gtk.Bin
	{
		string _url;
		static Stream nst = Assembly.GetExecutingAssembly().GetManifestResourceStream("NicoMonoViewer.noimage.jpg");
		static Pixbuf noimage = new PixbufLoader(nst).Pixbuf;
		public NicorepoWidgetItemSubIcon ()
		{
			this.Build ();
		}
		public void Write(string url){
			_url = url;
			BackgroundWorker gw = new BackgroundWorker();
			gw.DoWork += HandleDoWork;
			gw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e) {
				Gtk.Application.Invoke(delegate(object isender, EventArgs ie) {
					if(e.Result != null){
						image.Pixbuf = ((PixbufLoader)e.Result).Pixbuf;
					}else{
						image.Pixbuf = noimage;
					}
				});
			};
			gw.RunWorkerAsync();
		}

		void HandleDoWork (object sender, DoWorkEventArgs e)
		{
			Stream st;
			try {
				WebRequest req = WebRequest.Create (_url);
				WebResponse res = req.GetResponse ();
				
				st = res.GetResponseStream ();
				e.Result = new Gdk.PixbufLoader (st, 48, 48);
				
			} catch (WebException ex) {
				ex.GetType();
			}
		}
	}
}

