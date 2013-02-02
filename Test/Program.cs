using System;
using Gtk;
using System.ComponentModel;

namespace Test
{
	class MainClass{public static void Main (string[] args)	{new Test();}}

	class Test{
		Window window;
		VBox vbox;
		Button button;

		public Test ()
		{
			Application.Init();

			window = new Window("test");
			vbox = new VBox();
			button = new Button(new Label("push"));
			button.Clicked += delegate(object sender, EventArgs e) {
				Application.Invoke(AddButton);
			};
			vbox.Add(button);
			window.Add(vbox);
			window.ShowAll();
			Application.Run();
		}
		void AddButton (object sender, EventArgs e) {
			System.Threading.Thread.Sleep(1000);
			Label label = new Label("pushed");
			vbox.PackEnd(label);
			label.Show();
		}
	}
}
