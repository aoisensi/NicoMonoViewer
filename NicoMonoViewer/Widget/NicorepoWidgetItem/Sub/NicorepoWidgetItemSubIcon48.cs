using System;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Reflection;
using Gdk;

namespace NicoMonoViewer
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class NicorepoWidgetItemSubIcon48 : Gtk.Bin
	{
		string _url;
		public NicorepoWidgetItemSubIcon48 ()
		{
			this.Build ();
		}
		public void Write(string url){
			_url = url;
			BackgroundWorker gw = new BackgroundWorker();
			gw.DoWork += HandleDoWork;
			gw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e) {
				Gtk.Application.Invoke(delegate(object isender, EventArgs ie) {
					image.Pixbuf = ((PixbufLoader)e.Result).Pixbuf;
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
				
			} catch (WebException ex) {
				if(ex.Status == WebExceptionStatus.ProtocolError){
					Assembly asm = Assembly.GetExecutingAssembly();
					st = asm.GetManifestResourceStream("NicoMonoViewer.noimage.jpg");
				}else{
					throw ex;
				}
			}
			e.Result = new Gdk.PixbufLoader (st, 48, 48);
		}
	}
}

