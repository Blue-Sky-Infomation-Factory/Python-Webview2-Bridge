namespace BSIF.WebView2Bridge;

using System.Runtime.InteropServices;

[ClassInterface(ClassInterfaceType.AutoDual)]
[ComVisible(true)]
public class WebView2Bridge(WebView2Bridge.Caller pythonCaller, string[] methodNames)
{
	public delegate string Caller(string methodName, string argsJson);
	private readonly Caller caller = pythonCaller;
	public readonly string[] methodNames = methodNames;
	public string Call(string methodName, string argsJson)
	{
		return caller.Invoke(methodName, argsJson);
	}
}