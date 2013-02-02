
// This file has been generated by the GUI designer. Do not modify.
namespace NicoMonoViewer
{
	public partial class MainWindow
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action FAction;
		private global::Gtk.Action closeAction;
		private global::Gtk.Action OAction;
		private global::Gtk.VBox vbox;
		private global::Gtk.MenuBar menubar;
		private global::NicoMonoViewer.NicorepoWidget nicorepowidget;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget NicoMonoViewer.MainWindow
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.FAction = new global::Gtk.Action ("FAction", global::Mono.Unix.Catalog.GetString ("ファイル(_F)"), null, null);
			this.FAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("ファイル(_F)");
			w1.Add (this.FAction, null);
			this.closeAction = new global::Gtk.Action ("closeAction", global::Mono.Unix.Catalog.GetString ("閉じる(_C)"), null, "gtk-close");
			this.closeAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("閉じる(_C)");
			w1.Add (this.closeAction, null);
			this.OAction = new global::Gtk.Action ("OAction", global::Mono.Unix.Catalog.GetString ("設定(_O)"), null, null);
			this.OAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("設定(_O)");
			w1.Add (this.OAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "NicoMonoViewer.MainWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
			this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-close", global::Gtk.IconSize.Menu);
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child NicoMonoViewer.MainWindow.Gtk.Container+ContainerChild
			this.vbox = new global::Gtk.VBox ();
			this.vbox.Name = "vbox";
			this.vbox.Spacing = 6;
			// Container child vbox.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name='menubar'><menu name='FAction' action='FAction'><menuitem name='closeAction' action='closeAction'/></menu><menu name='OAction' action='OAction'/></menubar></ui>");
			this.menubar = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar")));
			this.menubar.Name = "menubar";
			this.vbox.Add (this.menubar);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox [this.menubar]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox.Gtk.Box+BoxChild
			this.nicorepowidget = new global::NicoMonoViewer.NicorepoWidget ();
			this.nicorepowidget.Events = ((global::Gdk.EventMask)(256));
			this.nicorepowidget.Name = "nicorepowidget";
			this.vbox.Add (this.nicorepowidget);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox [this.nicorepowidget]));
			w3.Position = 1;
			this.Add (this.vbox);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 509;
			this.DefaultHeight = 300;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.closeAction.Activated += new global::System.EventHandler (this.OnCloseActionActivated);
		}
	}
}
