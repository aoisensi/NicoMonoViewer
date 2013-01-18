
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action FAction;
	private global::Gtk.Action quitAction;
	private global::Gtk.Action SAction;
	private global::Gtk.Action loginAction;
	private global::Gtk.Action themeAction;
	private global::Gtk.VBox vbox;
	private global::Gtk.MenuBar menubar;
	private global::Gtk.Notebook notebook;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.FAction = new global::Gtk.Action ("FAction", global::Mono.Unix.Catalog.GetString ("ファイル(_F)"), null, null);
		this.FAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("ファイル(_F)");
		w1.Add (this.FAction, null);
		this.quitAction = new global::Gtk.Action ("quitAction", global::Mono.Unix.Catalog.GetString ("終了(_X)"), null, "gtk-quit");
		this.quitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("終了(_X)");
		w1.Add (this.quitAction, null);
		this.SAction = new global::Gtk.Action ("SAction", global::Mono.Unix.Catalog.GetString ("設定(_S)"), null, null);
		this.SAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("設定(_S)");
		w1.Add (this.SAction, null);
		this.loginAction = new global::Gtk.Action ("loginAction", global::Mono.Unix.Catalog.GetString ("ログイン(_S)"), null, null);
		this.loginAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("ログイン(_S)");
		w1.Add (this.loginAction, null);
		this.themeAction = new global::Gtk.Action ("themeAction", global::Mono.Unix.Catalog.GetString ("テーマ(_T)"), null, null);
		this.themeAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("テーマ(_T)");
		w1.Add (this.themeAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox = new global::Gtk.VBox ();
		this.vbox.Name = "vbox";
		this.vbox.Spacing = 6;
		// Container child vbox.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar'><menu name='FAction' action='FAction'><menuitem name='quitAction' action='quitAction'/></menu><menu name='SAction' action='SAction'><menuitem name='loginAction' action='loginAction'/><menuitem name='themeAction' action='themeAction'/></menu></menubar></ui>");
		this.menubar = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar")));
		this.menubar.Name = "menubar";
		this.vbox.Add (this.menubar);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox [this.menubar]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox.Gtk.Box+BoxChild
		this.notebook = new global::Gtk.Notebook ();
		this.notebook.CanFocus = true;
		this.notebook.Name = "notebook";
		this.notebook.CurrentPage = -1;
		this.vbox.Add (this.notebook);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox [this.notebook]));
		w3.Position = 1;
		w3.Expand = false;
		w3.Fill = false;
		this.Add (this.vbox);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 571;
		this.DefaultHeight = 300;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.quitAction.Activated += new global::System.EventHandler (this.OnQuitActionActivated);
		this.loginAction.Activated += new global::System.EventHandler (this.OnLoginActionActivated);
		this.themeAction.Activated += new global::System.EventHandler (this.OnThemeActionActivated);
	}
}
