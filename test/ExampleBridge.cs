namespace test;

using BSIF.WebView2Bridge;

public class ExampleBridge : WebView2Bridge
{
	private static string ExampleSyncCaller(string methodName, string argsJson)
	{
		Console.WriteLine($"SyncCaller: {methodName}, {argsJson}");
		return "null";
	}
	private static void ExampleAsyncCaller(string methodName, string argsJson, TaskCompletionSource<string> asyncObject)
	{
		Console.WriteLine($"AsyncCaller: {methodName}, {argsJson}");
		asyncObject.SetResult("null");
	}

	public ExampleBridge() : base(ExampleSyncCaller, ExampleAsyncCaller, ["test"])
	{

	}
}