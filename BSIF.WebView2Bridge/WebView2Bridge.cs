namespace BSIF.WebView2Bridge;

using System.Runtime.InteropServices;

[ClassInterface(ClassInterfaceType.AutoDual)]
[ComVisible(true)]
public class WebView2Bridge(WebView2Bridge.SyncCaller syncCaller, WebView2Bridge.AsyncCaller asyncCaller, string[] methodNames)
{
	public readonly string[] methodNames = methodNames;
	public delegate string SyncCaller(string methodName, string argsJson);
	private readonly SyncCaller syncCaller = syncCaller;
	public string SyncCall(string methodName, string argsJson)
	{
		return syncCaller.Invoke(methodName, argsJson);
	}
	public delegate void AsyncCaller(string methodName, string argsJson, TaskCompletionSource<string> asyncObject);
	private readonly AsyncCaller asyncCaller = asyncCaller;
	public Task<string> AsyncCall(string methodName, string argsJson){
		TaskCompletionSource<string> taskSource = new();
		asyncCaller.Invoke(methodName, argsJson, taskSource);
		return taskSource.Task;
	}
}