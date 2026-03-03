namespace test;

using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

public class Program
{
	private static readonly Application App = new();

	[STAThread]
	static void Main(string[] args)
	{
		Window mainWindow = new()
		{
			Title = "test",
			Width = 800,
			Height = 600,
			WindowStartupLocation = WindowStartupLocation.CenterScreen,
			// AllowsTransparency = true,
			// Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0)),
			// WindowStyle = WindowStyle.None
		};
		DockPanel layout = new();
		WebView2 webview = new()
		{
			CreationProperties = new CoreWebView2CreationProperties()
			{
				IsInPrivateModeEnabled = false,
				UserDataFolder = (Environment.GetEnvironmentVariable("TEMP") ?? ".") + "/Microsoft WebView",
				AdditionalBrowserArguments = "--disable-features=ElasticOverscroll"
			},
			Source = new Uri("https://bspr0002.github.io")
		};
		webview.CoreWebView2InitializationCompleted += OnWebViewReadyAsync;
		layout.Children.Add(webview);
		mainWindow.Content = layout;
		App.Run(mainWindow);
	}

	private static async void OnWebViewReadyAsync(object webview, CoreWebView2InitializationCompletedEventArgs args)
	{
		if (!args.IsSuccess)
		{
			Console.Error.Write(args.InitializationException);
			return;
		}
		CoreWebView2 core = ((WebView2)webview).CoreWebView2;
		CoreWebView2Settings settings = core.Settings;
		settings.AreBrowserAcceleratorKeysEnabled = settings.AreDefaultContextMenusEnabled = settings.AreDevToolsEnabled = true;
		settings.AreDefaultScriptDialogsEnabled = true;
		settings.IsBuiltInErrorPageEnabled = true;
		settings.IsScriptEnabled = true;
		settings.IsWebMessageEnabled = true;
		settings.IsStatusBarEnabled = false;
		settings.IsSwipeNavigationEnabled = false;
		settings.IsZoomControlEnabled = false;
		// core.AddHostObjectToScript("bridge", new ApiTest());
		core.RemoveScriptToExecuteOnDocumentCreated("1");
		await core.AddScriptToExecuteOnDocumentCreatedAsync("console.log('script execute')");
		core.OpenDevToolsWindow();
	}
}
