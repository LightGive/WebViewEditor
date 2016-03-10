using UnityEngine;
using UnityEditor;
using System.Reflection;

public class WebViewEditor:EditorWindow
{
	public static WebViewEditor window;
	public static BindingFlags Flags = BindingFlags.Public | BindingFlags.Static;
	public static System.Type type;

	private const string DEFAULT_MENU = "Window";
	private string urlStr = "https://www.google.co.jp/";


	[MenuItem(DEFAULT_MENU+"/WebView/Google")]
	public static void OpenWeb_Google()
	{
		OpenWebPage("https://www.google.co.jp/");
	}

	[MenuItem(DEFAULT_MENU+"/WebView/Youtube")]
	public static void OpenWeb_Youtube()
	{
		OpenWebPage("https://www.youtube.com/");
	}

	[MenuItem(DEFAULT_MENU+"/WebView/Codic")]
	public static void OpenWeb_Codic()
	{
		OpenWebPage("https://codic.jp/engine");
	}

	[MenuItem(DEFAULT_MENU+"/WebView/Weblio")]
	public static void OpenWeb_Weblio()
	{
		OpenWebPage("http://ejje.weblio.jp/");
	}

	[MenuItem(DEFAULT_MENU+"/WebView/CustomPage...")]
	public static void OpenWindow()
	{
		window = GetWindow<WebViewEditor>();
	}


	public static void OpenWebPage(string str)
	{
		type = Types.GetType("UnityEditor.Web.WebViewEditorWindow", "UnityEditor.dll");
		var methodInfo = type.GetMethod("Create", Flags);
		methodInfo = methodInfo.MakeGenericMethod(typeof(WebViewEditor));
		methodInfo.Invoke(null, new object[]{
			"WebViewEditor",
			str,
			200, 530, 800, 600
		});
	}

    void OnGUI()
	{
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("URL : ", GUILayout.Width(50));
		urlStr = EditorGUILayout.TextField( urlStr);
		EditorGUILayout.EndHorizontal();


		if (GUILayout.Button("OpenPage")) {
			OpenWebPage(urlStr);
			window.Close();
        }
	}
}
