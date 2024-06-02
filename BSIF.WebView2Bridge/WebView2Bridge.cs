namespace BSIF.WebView2Bridge;

using System.Runtime.InteropServices;

[ClassInterface(ClassInterfaceType.AutoDual)]
[ComVisible(true)]
public class WebView2Bridge(WebView2Bridge.SyncCaller pythonSyncCaller, string[] methodNames)
{
	public delegate string SyncCaller(string methodName, string argsJson);
	private readonly SyncCaller syncCaller = pythonSyncCaller;
	public readonly string[] methodNames = methodNames;
	public string SyncCall(string methodName, string argsJson)
	{
		return syncCaller.Invoke(methodName, argsJson);
	}
}